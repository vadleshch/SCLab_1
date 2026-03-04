using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCLab_1
{
    internal class Bigram
    {
        public string bigram;
        public double p;
        public static bool Contains(List<Bigram> bigrams, string bigram)
        {
            foreach (var item in bigrams)
            {
                if (item.bigram == bigram)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
