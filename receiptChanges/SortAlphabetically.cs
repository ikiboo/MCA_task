using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCA_Solution.receiptChanges
{
    public static class SortAlphabetically
    {
        public static int Comparer(Receipt x, Receipt y)
        {
            return x.name.CompareTo(y.name);
        }

    }
}
