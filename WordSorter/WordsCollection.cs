using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSorter
{
    public class WordsCollection
    {
        public List<string> Words { get; set; }

        public WordsCollection(params string[] words)
        {
            Words = words.ToList();
        }

        public WordsCollection(List<string> words)
        {
            Words = words;
        }
    }
}
