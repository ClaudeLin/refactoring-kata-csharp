using System.Collections.Generic;
using System.Text;
using RefactoringKata.Enum;

namespace RefactoringKata
{
	public class OrdersWriter
	{
		private Orders _orders;

		public OrdersWriter(Orders orders)
		{
			_orders = orders;
		}

		public string GetContents()
		{
			return _orders.ToJsonString();
		}
	}
}