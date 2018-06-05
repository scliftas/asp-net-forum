using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QAForum.Models
{
    [MetadataType(typeof(Forum.MetaData))]
    public partial class Forum
    {
        internal sealed class MetaData
        {
            [DisplayName("Title")]
            public string ForumTitle { get; set; }
        }
    }
}