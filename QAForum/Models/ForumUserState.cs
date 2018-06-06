using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QAForum.Models
{
    public class ForumUserState
    {
        public string AvatarFileName { get; set; }

        public ForumUserState()
        {
            AvatarFileName = string.Empty;
        }
    }
}