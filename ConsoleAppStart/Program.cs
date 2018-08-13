using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSorter;

namespace ConsoleAppStart
{
    class Program
    {
        static void Main(string[] args)
        {
            WordsCollection wc = WordsReader.Read(args[0]);
            WordsWriter.WriteAnswer(args[1], wc);
        }
    }
}
