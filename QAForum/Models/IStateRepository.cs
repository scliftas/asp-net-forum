using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAForum.Models
{
    public interface IStateRepository
    {
        ForumUserState GetForumUserState();
    }
}
