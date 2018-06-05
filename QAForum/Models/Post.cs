namespace QAForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        public int PostID { get; set; }

        public Guid? UserID { get; set; }

        public int? ThreadID { get; set; }

        [Required]
        [StringLength(100)]
        public string PostTitle { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime PostDateTime { get; set; }

        [Required]
        public string PostBody { get; set; }

        public virtual Thread Thread { get; set; }
    }
}
