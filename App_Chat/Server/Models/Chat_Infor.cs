namespace Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Chat_Infor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? UserID1 { get; set; }

        public int? UserID2 { get; set; }

        [StringLength(50)]
        public string IP { get; set; }

        public int? Port { get; set; }
    }
}
