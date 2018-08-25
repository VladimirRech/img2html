using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace img2html.baselib
{
    public class imgconv
    {
        public string FileFullPath { get; set; }
        private Dictionary<string, ImageFormat> SupportedImg;
        private string extension;

        public imgconv(string fileFullPath)
        {
            FileFullPath = fileFullPath;
            extension = Path.GetExtension(fileFullPath).ToLower();
            SupportedImg = new Dictionary<string, ImageFormat>
            {
                { ".bmp", ImageFormat.Bmp },
                { ".png", ImageFormat.Png },
                { ".gif", ImageFormat.Gif },
                { ".jpg", ImageFormat.Jpeg }
            };
        }

        public string GetHtml()
        {
            byte[] imgBytes = img2ByteArray();

            while (imgBytes != null && imgBytes.Length > 0)
            {
                return string.Format("<img src=\"data:image/{0};base64,{1}\" />",
                    extension,
                    Convert.ToBase64String(imgBytes));
            }

            return null;
        }

        byte[] img2ByteArray()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                while (!SupportedImg.ContainsKey(extension))
                    return null;

                using (var img = Image.FromFile(FileFullPath))
                    img.Save(memoryStream, SupportedImg[extension]);

                return memoryStream.ToArray();
            }
        }
    }
}
