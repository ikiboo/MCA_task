using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCA_Solution.receiptChanges
{
    public static class TruncateDescription
    {
        public static void Truncate(List<Receipt> receipts)
        {
            foreach (Receipt receipt in receipts)
            {
                if (receipt.description.Length > 10)
                {
                    receipt.description = receipt.description.Substring(0, 10) + "...";
                }
            }
        }
    }
}
