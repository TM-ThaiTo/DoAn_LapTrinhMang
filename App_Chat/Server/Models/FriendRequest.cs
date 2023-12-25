namespace Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FriendRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestID { get; set; }

        public int? SenderID { get; set; }

        public int? ReceiverID { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public DateTime? Timestamp { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
