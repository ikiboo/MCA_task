using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCA_Solution.receiptChanges
{
    public static class CalculateCost
    {
        public static double TotalCost(List<Receipt> receipts)
        {
            return receipts.Sum(r => r.price);
        }

    }
}
