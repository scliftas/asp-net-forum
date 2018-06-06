using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QAForum.Models
{
    [MetadataType(typeof(Thread.MetaData))]
    public partial class Thread
    {
        internal sealed class MetaData
        {
            [Required]
            [DisplayName("Forum")]
            public int ForumID { get; set; }

            [Required]
            [StringLength(100)]
            [DisplayName("Title")]
            public string ThreadTitle { get; set; }

            [Required]
            [DisplayName("Owner")]
            public Guid? OwnerID { get; set; }
        }
    }
}