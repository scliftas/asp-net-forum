using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QAForum.Models
{
    [MetadataType(typeof(Post.MetaData))]
    public partial class Post
    {
        internal sealed class MetaData
        {
            [Required]
            [DisplayName("User")]
            public Guid? UserID { get; set; }

            [Required]
            [DisplayName("Thread")]
            public int? ThreadID { get; set; }

            [DisplayName("Title")]
            public string PostTitle { get; set; }

            [Required]
            [DisplayName("Posted")]
            public DateTime PostDateTime { get; set; }

            [DisplayName("Post")]
            public string PostBody { get; set; }
        }
    }
}