using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteBrainence.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFContext _context;
        public HomeController()
        {
            _context = new EFContext();
        }
        public ActionResult Index()
        {
            //ViewBag.CountRowTable = _context.FileInfoDatas.Count();
            var model = _context.FileInfoDatas.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string search)
        {
            string filePath = string.Empty;
            if (file != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                file.SaveAs(filePath);

                //Read the contents of file.
                string text = System.IO.File.ReadAllText(filePath);
                var sentences = text.Split('.');

                foreach (var sentence in sentences)
                {
                    string wordDb = "";
                    string wordDbRev = "";
                    bool isAddToDb = false;
                    int counter = 0;
                    var words = sentence.Split(' ');
                    foreach (var item in words)
                    {
                        var word = item.Replace("\r\n", string.Empty);
                        if (word == search)
                        {
                            isAddToDb = true;
                            counter++;
                        }
                        wordDb+= word + ' ';
                        word = word.Reverse();
                        wordDbRev += word + ' ';

                    }
                    if (!string.IsNullOrEmpty(wordDbRev.Trim()))
                    {
                        if (isAddToDb)
                        {
                            FileInfoData fileInfoData = new FileInfoData
                            {
                               OriginText=wordDb.Trim()+'.',
                               ReverseWordText=wordDbRev.Trim()+'.',
                               Word=search,
                               CountWords=counter
                            };
                            _context.FileInfoDatas.Add(fileInfoData);
                            _context.SaveChanges();
                            //Console.WriteLine(wordDb.Trim() + '.');
                        }
                    }
                }
            }
            var model = _context.FileInfoDatas.ToList();
            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public static class StringReverse
    {
        public static string Reverse(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            //str = new string(charArray);
            return new string(charArray);
        }
    }
}