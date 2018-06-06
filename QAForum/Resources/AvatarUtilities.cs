using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using QAForum.Models;

namespace QAForum.Resources
{
    public class AvatarUtilities
    {
        public IEnumerable<AvatarData> GetAllAvatars()
        {
            List<AvatarData> avatars = new List<AvatarData>();

            DirectoryInfo di = new DirectoryInfo(HttpContext.Current.Request.MapPath("/content/images/avatars"));

            var files = di.GetFiles();

            foreach (var file in files)
            {
                avatars.Add(new AvatarData()
                {
                    AvatarName = file.Name,
                    FullPath = "~/content/images/avatars/" + file.Name
                });
            }

            return avatars;
        }
    }
}