using System.Text;
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

		public string ToJsonString()
		{
			var sb=new StringBuilder();
			sb.Append($"{{\"code\": \"{Code}\", \"color\": \"{Color}\", ");

			if (IsSizeApplicable())
			{
				sb.Append($"\"size\": \"{Size}\", ");
			}

			sb.Append($"\"price\": {Price}, \"currency\": \"{Currency}\"}}");

			return sb.ToString();
		}

	    private bool IsSizeApplicable()
	    {
		    return Size != EnumProductSize.SIZE_NOT_APPLICABLE;
	    }
    }
}
