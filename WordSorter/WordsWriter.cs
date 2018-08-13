using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSorter
{
    public class WordsWriter
    {
        public static void WriteAnswer(string path, WordsCollection words)
        {
            File.WriteAllLines(path, Util.GetAnswer(words));
        }
    }
}
