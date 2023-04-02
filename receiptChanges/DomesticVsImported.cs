using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCA_Solution.receiptChanges
{
    public static class DomesticVsImported
    {
        public static void SplitProducts(List<Receipt> receipts, out List<Receipt> domesticProducts, out List<Receipt> importedProducts)
        {
            domesticProducts = new List<Receipt>();
            importedProducts = new List<Receipt>();

            foreach (Receipt receipt in receipts)
            {
                if (receipt.domestic)
                {
                    domesticProducts.Add(receipt);
                }
                else
                {
                    importedProducts.Add(receipt);
                }
            }
        }
    }
}
