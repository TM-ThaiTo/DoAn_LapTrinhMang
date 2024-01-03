namespace Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GroupMessage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupMessageID { get; set; }

        public int GroupID { get; set; }

        public int UserID { get; set; }

        public string Content { get; set; }

        public DateTime? Timestamp { get; set; }

        public virtual GroupChat GroupChat { get; set; }

        public virtual User User { get; set; }
    }
}
