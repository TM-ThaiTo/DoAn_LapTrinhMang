namespace Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Avatar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int User_AvatarID { get; set; }

        public int? UserDetailID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Avatar { get; set; }

        public virtual User_Details User_Details { get; set; }
    }
}
