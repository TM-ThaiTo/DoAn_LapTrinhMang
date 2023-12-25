namespace Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MessageID { get; set; }

        public int? SenderID { get; set; }

        public int? ReceiverID { get; set; }

        public string Content { get; set; }

        public DateTime? Timestamp { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
