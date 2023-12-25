namespace Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FriendList")]
    public partial class FriendList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FriendshipID { get; set; }

        public int? UserID1 { get; set; }

        public int? UserID2 { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
