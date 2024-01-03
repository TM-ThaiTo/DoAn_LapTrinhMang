using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.App.Class_Chat
{
    public class Chat_Result
    {
        #region Biến
        private static Chat_Result instance;
        public static Chat_Result Instance
        {
            get { if (instance == null) instance = new Chat_Result(); return instance; }
            private set { instance = value; }
        }
        private Chat_Result() { }
        #endregion
    }
}
