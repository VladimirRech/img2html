using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img2html.baselib
{
    public class imgconv
    {
        public string FileFullPath { get; set; }
        public string LastError { get; set; }

        public imgconv(string fileFullPath)
        {
            FileFullPath = fileFullPath;
        }

        public string GetHtml()
        {
            return null;
        }
    }
}
