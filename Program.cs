using MCA_Solution;
using MCA_Solution.receiptChanges;
using System.Text.Json;

class Program
{
    static async Task Main()
    {
        //Get data from url
        string url = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";

        using HttpClient client = new HttpClient();
        using HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            //Store receipt data
            string receiptData = await response.Content.ReadAsStringAsync();

            //Create a list of receipts
            List<Receipt> receipts = JsonSerializer.Deserialize<List<Receipt>>(receiptData);

            //Split products into domestic and imported
            List<Receipt> domesticProducts;
            List<Receipt> importedProducts;
            DomesticVsImported.SplitProducts(receipts, out domesticProducts, out importedProducts);

            //Sort products alphabetically
            domesticProducts.Sort(SortAlphabetically.Comparer);
            importedProducts.Sort(SortAlphabetically.Comparer);

            //Truncate description in receipts
            TruncateDescription.Truncate(domesticProducts);
            TruncateDescription.Truncate(importedProducts);

            //Calculate total cost of domestic and imported products
            double domesticCost = CalculateCost.TotalCost(domesticProducts);
            double importedCost = CalculateCost.TotalCost(importedProducts);

            //Print the receipts from domestic and imported products
            Console.WriteLine(". Domestic");
            domesticProducts.ForEach(receipt => receipt.print());
            Console.WriteLine(". Imported");
            importedProducts.ForEach(receipt => receipt.print());

            //Print the total costs and number of products
            Console.WriteLine($"Domestic cost: ${domesticCost.ToString("f1")}");
            Console.WriteLine($"Imported cost: ${importedCost.ToString("f1")}");
            Console.WriteLine($"Domestic count: {domesticProducts.Count}");
            Console.WriteLine($"Imported count: {importedProducts.Count}");
        }
        else
        {
            Console.WriteLine("Failed to get data. Status code: " + response.StatusCode);
        }

    }
}
