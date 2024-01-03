namespace Server.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupChat")]
    public partial class GroupChat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GroupChat()
        {
            GroupMembers = new HashSet<GroupMember>();
            GroupMessages = new HashSet<GroupMessage>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        [StringLength(50)]
        public string GroupPassword { get; set; }

        public int OwnerID { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupMember> GroupMembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GroupMessage> GroupMessages { get; set; }
    }
}
