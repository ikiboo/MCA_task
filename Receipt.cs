namespace MCA_Solution
{
    public class Receipt
    {
        public string name { get; set; }
        public bool domestic { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public int? weight { get; set; }

        public void print()
        {
            Console.WriteLine($"... {name}");
            Console.WriteLine($"    Price: ${price.ToString("f1")}");
            Console.WriteLine($"    {description}");
            if (weight != null)
            {
                Console.WriteLine($"    Weight: {weight}g");
            } 
            else
            {
                Console.WriteLine("    Weight: N/A");
            }
        }
    }
}

