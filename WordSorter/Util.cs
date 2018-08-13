using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSorter
{
    public class Util
    {
        public static SortedDictionary<string, int> CountWordsNumber(WordsCollection words)
        {
            SortedDictionary<string, int> ans = new SortedDictionary<string, int>();
            HashSet<string> set = new HashSet<string>(words.Words);

            foreach (string searchWord in set)
            {
                int count = 0;
                foreach (string word in words.Words)
                {
                    if (searchWord.Equals(word))
                    {
                        count++;
                    }
                }
                ans.Add(searchWord, count);
            }

            return ans;
        }

        public static List<string> GetAnswer(WordsCollection words)
        {
            SortedDictionary<string, int>.Enumerator e = CountWordsNumber(words).GetEnumerator();

            List<string> ans = new List<string>();
            char letter = '0';
            while (e.MoveNext())
            {
                if (!letter.Equals(e.Current.Key[0]))
                {
                    letter = e.Current.Key[0];
                    ans.Add(letter.ToString() + "\r\n");
                }

                ans.Add(e.Current.Key + " " + e.Current.Value + "\r\n");
            }

            return ans;
        }
    }
}
