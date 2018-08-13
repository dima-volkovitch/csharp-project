using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSorter
{
    public class WordsReader
    {
        public static readonly char[] SEPARATORS = { ' ', ',', '.', ':', ';', '?', '!', '\r', '\n', '\0'};

        public static WordsCollection Read(string path)
        {
            string words = File.ReadAllText(path);
            return new WordsCollection(words.ToLower().Split(SEPARATORS, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
