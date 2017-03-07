using RefactoringKata.Enum;

namespace RefactoringKata
{
    public class Product
    {
        public string Code { get; set; }
		public EnumProductColor Color { get; set; }
		public EnumProductSize Size { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }

        public Product(string code, int color, int size, double price, string currency)
        {
            Code = code;
            Color = (EnumProductColor)color;
			Size = (EnumProductSize)size;
            Price = price;
            Currency = currency;
        }
    }
}
