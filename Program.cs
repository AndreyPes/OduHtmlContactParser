using System;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.IO;
using System.Xml;

namespace OduHtmlContactParser
{
    class Program
    {
        static void Main(string[] args)
        {

            var html = new HtmlDocument();
            html.LoadHtml(new WebClient().DownloadString("http://www.address.net/my.html"));
            var root = html.DocumentNode;
            var commonPosts = root.Descendants().Where(n => n.GetAttributeValue("id", "").Equals("table5"));
            string buffer = "";
          
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml2(commonPosts.ToArray()[0].InnerHtml);
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//td[@width=346]"))
             {
       
                if (Program.strconcat(link.InnerText.Split(new Char[] { '\r', '\n', ' ' })) != "Факс" )
                {
                 
                    buffer += link.InnerText + Environment.NewLine;
                }
              
            }
            XmlDocument xm = new XmlDocument();

            string path=  Directory.GetCurrentDirectory()+"employee.txt";
            File.WriteAllText(@"" + path, buffer);

            Console.ReadKey();
        }
        public static string strconcat(string[] sarr)
        {
            string buffstr = "";
            foreach(var s in sarr)
            {
                buffstr += s;
            }
            return buffstr;
        }

    }
}
