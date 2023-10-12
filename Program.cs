namespace CAEvent
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock("Amazon");
            stock.Price = 100;

            stock.onChangePriceHandler += Stock_onChangePriceHandler;

            stock.ChangePriceBy(0.03m);
            stock.ChangePriceBy(-0.03m);
            stock.ChangePriceBy(0.00m);



        }

        private static void Stock_onChangePriceHandler(Stock stock, decimal oldPrice)
        {
            string result = "";
            if (stock.Price > oldPrice)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                result = "UP";
            }
            else if (stock.Price < oldPrice)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                result = "Down";
            }
            else 
            {
                Console.ForegroundColor= ConsoleColor.Gray;
                
            }

            Console.WriteLine($"Name: {stock.Name} {stock.Price} - {result}");
        }
    }
    public delegate void ChangePriceHandler(Stock stock, decimal oldPrice);
    public class Stock
    {
        private string name;
        private decimal price;

        public string Name => this.name;
        public decimal Price { get => this.price; set => this.price = value; }

        public event ChangePriceHandler onChangePriceHandler;
        public void ChangePriceBy(decimal precent)
        {
            decimal oldPrice = this.price;
            this.price += Math.Round(this.price * precent, 2) ;
            if(onChangePriceHandler != null)
            {
                onChangePriceHandler(this, oldPrice);
            }
                

        }
        public Stock(string stockName) 
        {
            this.name = stockName;
        }

    }
}