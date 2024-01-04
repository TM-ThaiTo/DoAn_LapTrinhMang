﻿using Client.App.Class_ThongTinUser;
using Client.App;
using System;
using System.Windows.Forms;
using Client.App.MaHoa;
using System.Net.Sockets;
using System.Threading;
using Client.App.Class_GuiYeuCau;
using NAudio.Wave;
using System.IO;

namespace Client
{
    public partial class Form_Chat_Group_Main : Form
    {
        #region Biến
        string id_User;
        string id_Group;
        string name_Group;
        string pass_Group;

        // TCP client
        private TcpClient client;

        // file
        private string selectedFilePath;

        // Biến ghi âm
        private WaveIn waveIn;
        private WaveFileWriter waveWriter;
        private string recordedFilePath;
        private bool isRecording = false;
        #endregion

        #region Hàm xữ lý chỉnh sửa thông tin nhóm
        private void LamMoi()
        {
            Load_Member();
            LoadMess();

            txt_TenNhom.Text = name_Group;
            txt_Pass.Text = pass_Group;

            txt_TenNhom.ReadOnly = true;
            txt_Pass.ReadOnly = true;

            btn_Luu.Enabled = false;
        }
        private void chinhSua()
        {
            txt_Pass.ReadOnly = false;
            txt_TenNhom.ReadOnly = false;
            btn_Luu.Enabled = true;
        }
        private bool kiemTraNhap()
        {
            if(string.IsNullOrEmpty(txt_TenNhom.Text) ||
                string.IsNullOrEmpty(txt_Pass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhóm!!");
                return false;
            }
            return true;
        }
        private void luuThongTin()
        {
            if(kiemTraNhap() == false)
            {
                return;
            }
            string new_nameGroup = txt_TenNhom.Text;
            string new_passGroup = txt_Pass.Text;

            //[Update_Group]${idGr}${newName}${newPass}
            string yeuCau = $"[Update_Group]${id_Group}${new_nameGroup.MaHoa()}${new_passGroup.MaHoa()}";
            string ketQua = Result.Instance.Request(yeuCau);
            
            if (string.IsNullOrEmpty(ketQua))
            {
                return;
            }
            else if (ketQua == "[OK]")
            {
                MessageBox.Show("Cập nhật thông tin nhóm thành công!!");
                name_Group = txt_TenNhom.Text;
                pass_Group = txt_Pass.Text;
                LamMoi();
                return;
            }// OK khi cập nhật thông tin thành công
            else if (ketQua == "[NULL]")
            {
                MessageBox.Show("Tên phòng bị trùng vui lòng lấy tên khác");
                return;
            }// NULL khi tên phòng bị trùng
            else
            {
                return;
            }
        }
        private void giaiTanNhom()
        {
            DialogResult result = MessageBox.Show("Bạn chắn chắn muốn xóa hành động này không thể hồi phục nội dung trong nhóm!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //[Update_Group]${idGr}${newName}${newPass}
                string yeuCau = $"[Del_Group]${id_Group}";
                string ketQua = Result.Instance.Request(yeuCau);

                if (string.IsNullOrEmpty(ketQua))
                {
                    return;
                }
                else if (ketQua == "[OK]")
                {
                    MessageBox.Show("Đã xóa Group thành công!!");
                    this.Close();
                    return;
                }// OK khi xóa thành công
                else if (ketQua == "[NULL]")
                {
                    MessageBox.Show("Lỗi xóa group vui lòng đợi một thời gian!!");
                    return;
                }// NULL khi lỗi xóa group
                else
                {
                    return;
                }
            } else
            {
                return;
            }
        }
        private void Load_Member()
        {
            // $"[Load_Member]$idGr
            string nd = $"[Load_Member]${id_Group}";
            string ketQua = Result.Instance.Request(nd);
            if(ketQua != "[NULL]")
            {
                Add_Load_Member(ketQua);
            }
            else { return; }
        }
        private void Add_Load_Member(string ketQua)
        {
            dgv_ThanhVien.Rows.Clear(); // Xóa tất cả các hàng hiện tại
            string[] parts = ketQua.Split('$');
            // Thêm dữ liệu từ các phần tách được vào DataTable
            for (int i = 1; i < parts.Length; i += 2)
            {
                if (parts[i] != UserInfo.Instance.Id && parts[i + 1] != UserInfo.Instance.Name)
                {
                    string id = parts[i];
                    string hoTen = parts[i + 1].GiaiMa();
                    dgv_ThanhVien.Rows.Add(id, hoTen);
                }
            }
        }
        #endregion

        #region TCP gửi tin nhắn
        // hàm kết nối
        private void Connect()
        {
            client = new TcpClient();
            try
            {
                string svIP = InfoServer.Instance.ServerIP;
                client.Connect(svIP, InfoServer.Instance.PortTCP_ChatUser);
                Thread receiveThread = new Thread(Receive);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch
            {
                MessageBox.Show("Không thể kết nổi serve!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // hàm đóng client
        private void CloseClient()
        {
            client.Close();
        }

        // hàm nhận thông tin từ server
        private void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.GetStream().Read(data, 0, data.Length);
                    string message = (string)Result.Instance.Deserialize(data);

                    if (message.StartsWith("[File_Message_Group]"))
                    {
                        // Xử lý thông điệp file
                        HandleFileMessage(message);
                    }
                    else if (message.StartsWith("[Chat_Group]"))
                    {
                        // Xử lý thông điệp văn bản
                        AddMessage(message);
                    }
                    else if (message.StartsWith("[Voice_Message_Group]"))
                    {
                        HandleFileVoiceMessage(message);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        // hàm thêm tin vào listView
        private void AddMessage(string message)
        {
            if (lsv_MessGroup.InvokeRequired)
            {
                lsv_MessGroup.Invoke(new MethodInvoker(() => AddMessage(message)));
            }
            else
            {
                // Tách thông tin từ message : [Chat_Group]$id_Gr$id_Gui$HoTenGui$Mess
                string[] parts = message.Split('$');
                string id_Gr = parts[1];
                string id_NgGui = parts[2];
                string name_NgGui = parts[3];
                string mess = parts[4].GiaiMa();

                // Kiểm tra xem có ít nhất một phần tử hay không
                if (parts.Length > 0 && id_Gr == id_Group)
                {
                    // Sử dụng phần tử đầu tiên (parts[0]) làm Text cho ListViewItem
                    string mess_add = name_NgGui + ": " + mess;
                    lsv_MessGroup.Items.Add(new ListViewItem() { Text = mess_add });
                }
                else
                {
                    return;
                }
            }
        }
        
        // hàm gửi
        private void Send()
        {
            if (txt_Mess.Text != string.Empty)
            {
                // [Chat_Group]$id_Gr$id_Gui$HoTenGui$Mess
                string id_Gui_Gr = UserInfo.Instance.Id;
                string name_Gui = UserInfo.Instance.Name;
                string mess = txt_Mess.Text;

                // gửi đến server => gửi đến các client khác và client này
                string noiDung = $"[Chat_Group]${id_Group}${id_Gui_Gr}${name_Gui}${mess.MaHoa()}";
                string gui = $"{noiDung}";
                byte[] data = Result.Instance.Serialize(gui);
                client.GetStream().Write(data, 0, data.Length);

                // gửi đến server => lưu
                // $"[New_Mess_Group]$idGr$idGui$mess
                string nd = $"[New_Mess_Group]${id_Group}${id_Gui_Gr}${mess.MaHoa()}";
                string ketQua = Result.Instance.Request(nd);
                if (ketQua == "[OK]")
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi lưu tin nhắn!!");
                    return;
                }
            }
        }

        // hàm load tin nhắn cũ
        private void LoadMess()
        {
            // $"[Load_Mess_Group]$idGr
            string nd = $"[Load_Mess_Group]${id_Group}";
            string ketQua = Result.Instance.Request(nd);
            if (ketQua == "[NULL]")
            {
                return;
            }
            
            if (string.IsNullOrEmpty(ketQua) || ketQua.Equals("[NULL]"))
            {
                return;
            }

            lsv_MessGroup.Items.Clear();
            string[] parts = ketQua.Split('$');

            for (int i = 1; i < parts.Length - 1; i += 2)
            {
                string userName = parts[i].GiaiMa();
                string content = parts[i + 1].GiaiMa();

                string noidungMess = userName + ": " + content;
                lsv_MessGroup.Items.Add(noidungMess);
            }
        }
        #endregion

        #region Gui file
        // gửi file
        private void SendFile()
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Vui lòng chọn một file để gửi.");
                return;
            }

            try
            {
                // Đọc dữ liệu từ file
                byte[] fileData = File.ReadAllBytes(selectedFilePath);

                // Tạo một thông điệp để gửi thông tin file
                // [File_Message_Group]${id_Gr}${id_Gui}${name_Gui}${ten_File}${kichThuoc}${noiDung}
                string fileName = Path.GetFileName(selectedFilePath);
                string message = $"[File_Message_Group]${id_Group}${UserInfo.Instance.Id}${UserInfo.Instance.Name}${fileName}${fileData.Length}${Convert.ToBase64String(fileData)}";

                // Gửi thông điệp tới server
                byte[] data = Result.Instance.Serialize(message);
                client.GetStream().Write(data, 0, data.Length);

                MessageBox.Show("File đã được gửi thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi file: {ex.Message}");
            }
        }
        private void chonFile()
        {
            // Tạo một đối tượng OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Đặt các thuộc tính cho OpenFileDialog
            openFileDialog.Title = "Chọn file";
            openFileDialog.Filter = "All Files|*.*"; // Bạn có thể thay đổi định dạng file ở đây

            // Hiển thị hộp thoại chọn file và kiểm tra kết quả
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Lấy đường dẫn của file được chọn
                selectedFilePath = openFileDialog.FileName;

            }
        }
        private void HandleFileMessage(string fileMessage)
        {
            // // [File_Message_Group]${id_Gr}${id_Gui}${name_Gui}${ten_File}${kichThuoc}${noiDung}
            string[] parts = fileMessage.Split('$');
            string id_gr = parts[1];
            string id_NgGui = parts[2];
            string name_ngGui = parts[3];
            string fileName = parts[4];
            int fileSize = int.Parse(parts[5]);
            byte[] fileData = Convert.FromBase64String(parts[6]);

            // Kiểm tra xem có phải là file được gửi đến cho client hiện tại không
            if (id_gr == id_Group && id_NgGui != UserInfo.Instance.Id)
            {
                // Hiển thị hộp thoại hỏi người dùng có muốn nhận file không
                DialogResult result = MessageBox.Show($"Thành viên {name_ngGui} vừa gửi file có tên {fileName} bạn có nhận không?", "Nhận file", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Lưu file vào máy
                    SaveFile(fileName, fileData);
                }
                else
                {
                    return;
                }
            }
        }
        private void SaveFile(string fileName, byte[] fileData)
        {
            try
            {
                // Tạo đường dẫn đầy đủ tới thư mục "SaveFile" trong thư mục chứa ứng dụng
                string saveFolderPath = Path.Combine(Application.StartupPath, "SaveFile");

                // Kiểm tra xem thư mục đã tồn tại chưa, nếu chưa thì tạo mới
                if (!Directory.Exists(saveFolderPath))
                {
                    Directory.CreateDirectory(saveFolderPath);
                }

                // Tạo đường dẫn đầy đủ tới file trong thư mục "SaveFile"
                string savePath = Path.Combine(saveFolderPath, fileName);

                // Lưu dữ liệu vào file
                File.WriteAllBytes(savePath, fileData);

                MessageBox.Show($"Đã lưu file vào thư mục SaveFile trong debug", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Gui voice
        // hàm xữ lý lấy Voice
        private void StartRecording()
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                string saveFolderPath = Path.Combine(Application.StartupPath, "SaveFile");
                if (!Directory.Exists(saveFolderPath))
                {
                    Directory.CreateDirectory(saveFolderPath);
                }

                // Đặt đường dẫn và tên file cho ghi âm trong thư mục "SaveFile"
                recordedFilePath = Path.Combine(saveFolderPath, "RecordedAudio.wav");

                // Khởi tạo đối tượng WaveIn và WaveFileWriter
                waveIn = new WaveIn();
                waveIn.WaveFormat = new WaveFormat(44100, 1); // Âm thanh mono với tần số 44.1 kHz

                waveWriter = new WaveFileWriter(recordedFilePath, waveIn.WaveFormat);

                // Gán sự kiện cho việc ghi âm
                waveIn.DataAvailable += WaveIn_DataAvailable;

                // Bắt đầu ghi âm
                waveIn.StartRecording();

                // Đánh dấu là đang ghi âm
                isRecording = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bắt đầu ghi âm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StopRecording()
        {
            try
            {
                // Dừng ghi âm
                waveIn?.StopRecording();

                // Giải phóng tài nguyên
                waveIn?.Dispose();
                waveWriter?.Close();
                waveWriter?.Dispose();

                // Đánh dấu là đã dừng ghi âm
                isRecording = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi dừng ghi âm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            // Ghi dữ liệu âm thanh vào file
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
        }
        private void HandleFileVoiceMessage(string message)
        {
            try
            {
                // [Voice_Message_Group]${id_Gr}${id_Gui}${nameGui}${ten_File}${kichThuoc}${noiDung}
                string[] parts = message.Split('$');
                string id_Gr = parts[1];
                string id_ngGui = parts[2];
                string name_ngGui = parts[3];
                string fileName = parts[4];
                int fileSize = int.Parse(parts[5]);
                byte[] voiceData = Convert.FromBase64String(parts[6]);

                // Kiểm tra xem có phải là file được gửi đến cho client hiện tại không
                if (id_Gr == id_Group && id_ngGui != UserInfo.Instance.Id)
                {
                    // Hiển thị hộp thoại hỏi người dùng có muốn nghe voice không
                    DialogResult result = MessageBox.Show($"Thành viên {name_ngGui} vừa gửi một đoạn thoại bạn có muốn nghe không?", "Nhận đoạn ghi âm", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        PlayVoice(voiceData);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý đoạn ghi âm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PlayVoice(byte[] voiceData)
        {
            try
            {
                // Lưu dữ liệu vào file tạm thời
                string tempFilePath = Path.Combine(Application.StartupPath, "TempVoice.wav");
                File.WriteAllBytes(tempFilePath, voiceData);

                // Sử dụng một thư viện để phát lại file âm thanh, ví dụ NAudio
                // Cần thêm thư viện NAudio vào dự án của bạn
                using (var audioFile = new AudioFileReader(tempFilePath))
                using (var outputDevice = new WaveOutEvent())
                {
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    // Đợi cho đến khi phát xong
                    while (outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(100);
                    }
                }

                // Xóa file tạm thời
                File.Delete(tempFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phát lại đoạn ghi âm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Gửi voice
        private void Voice()
        {
            if (!isRecording)
            {
                // Bắt đầu ghi âm
                StartRecording();

                // Hiển thị MessageBox và nút OK để dừng ghi âm
                DialogResult result = MessageBox.Show("Đang ghi âm. Nhấn OK để dừng ghi âm.", "Thông báo", MessageBoxButtons.OK);

                // Dừng ghi âm nếu người dùng nhấn OK
                if (result == DialogResult.OK)
                {
                    StopRecording();
                    Send_Voice();
                }
            }
            else
            {
                StopRecording();
            }
        }
        private void Send_Voice()
        {
            try
            {
                // Đọc dữ liệu từ file ghi âm
                byte[] voiceData = File.ReadAllBytes(recordedFilePath);

                // Tạo thông điệp để gửi đoạn ghi âm
                // [Voice_Message_Group]${id_Gr}${id_Gui}${nameGui}${ten_File}${kichThuoc}${noiDung}
                string fileName = Path.GetFileName(recordedFilePath);
                string message = $"[Voice_Message_Group]${id_Group}${UserInfo.Instance.Id}${UserInfo.Instance.Name}${fileName}${voiceData.Length}${Convert.ToBase64String(voiceData)}";

                // Gửi thông điệp tới server
                byte[] data = Result.Instance.Serialize(message);
                client.GetStream().Write(data, 0, data.Length);

                MessageBox.Show("Đoạn ghi âm đã được gửi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi đoạn ghi âm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Form
        public Form_Chat_Group_Main(string idGroup, string nameGroup, string passGroup)
        {
            InitializeComponent();
            id_User = idGroup;
            id_Group = idGroup;
            name_Group = nameGroup;
            pass_Group = passGroup;
            Connect();
        }
        private void Form_Chat_Group_Main_Load(object sender, EventArgs e)
        {
            LamMoi();
        }
        private void pic_LamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Minimize_Click(object sender, EventArgs e)
        {
            Minimize.Click += delegate {
                // Thu nhỏ form.
                this.WindowState = FormWindowState.Minimized;
            };
        }
        private void Zoom_Click(object sender, EventArgs e)
        {
            Zoom.Click += delegate {
                // Kiểm tra trạng thái hiện tại của form.
                if (this.WindowState == FormWindowState.Maximized)
                {
                    // Thu nhỏ form.
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    // Phóng to form.
                    this.WindowState = FormWindowState.Maximized;
                }
            };
        }

        // quản lý nhóm
        private void btn_ChinhSua_Click_1(object sender, EventArgs e)
        {
            chinhSua();
        }
        private void btn_Luu_Click_1(object sender, EventArgs e)
        {
            luuThongTin();
        }
        private void btn_GiaiTan_Click_1(object sender, EventArgs e)
        {
            giaiTanNhom();
        }
        private void chk_AnHienPass_MatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_AnHienPass_MatKhau.Checked)
            {
                txt_Pass.PasswordChar = '\0';
            }
            else
            {
                txt_Pass.PasswordChar = '●';
            }
        }

        // gửi tin nhắn
        private void btn_Send_Click_1(object sender, EventArgs e)
        {
            Send();
            txt_Mess.Text = "";
        }
        private void pic_VoiceChat_Click(object sender, EventArgs e)
        {
            Voice();
        }
        private void pic_ChonFile_Click(object sender, EventArgs e)
        {
            chonFile();
            SendFile();
        }
        #endregion

        
    }
}
