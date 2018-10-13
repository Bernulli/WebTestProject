using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class GetFile
    {
        public string text;
        string path;
        public string[] sentences;

        public GetFile(string search)
        {
            path = @"War.txt";
            text = File.ReadAllText(path);
            sentences = text.Split('.');
            
            foreach (var sentence in sentences)
            {
                string wordDb = "";
                bool isAddToDb = false;
                int counter = 0;
                var words = sentence.Split(' ');
                foreach(var item in words)
                {
                    var word = item.Replace("\r\n", string.Empty);
                    if(word==search)
                    {
                        isAddToDb = true;
                        counter++;
                    }
                    word=word.Reverse();
                    wordDb += word + ' ';

                }
                if(!string.IsNullOrEmpty(wordDb.Trim()))
                {
                    if (isAddToDb)
                    {
                        Console.WriteLine(wordDb.Trim()+'.');
                    }
                }
            }
        }
        
    }
}
