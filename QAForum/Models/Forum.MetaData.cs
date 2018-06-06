using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QAForum.Models
{
    [MetadataType(typeof(Forum.MetaData))]
    public partial class Forum
    {
        internal sealed class MetaData
        {
            [Required]
            [StringLength(100)]
            [DisplayName("Title")]
            public string ForumTitle { get; set; }
        }
    }
}