using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img2html.demo
{
    class Program
    {
        static void Main(string[] args)
        {
            while (args.Length == 0)
            {
                Console.WriteLine("Usage:\n\timg2html <filename>");
                return;
            }

            string html = new img2html.baselib.imgconv(@args[0]).GetHtml();

            Console.WriteLine(html != null && html.Length > 0 ?
                html : "Não foi possível gerar a imagem");
        }
    }
}
