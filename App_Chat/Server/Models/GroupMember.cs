namespace Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GroupMember
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupMemberID { get; set; }

        public int GroupID { get; set; }

        public int UserID { get; set; }

        public virtual GroupChat GroupChat { get; set; }

        public virtual User User { get; set; }
    }
}
