using System.Text;
using RefactoringKata.Enum;

namespace RefactoringKata
{
	public class OrdersWriter
	{
		private Orders _orders;
		private StringBuilder _orderDetail = new StringBuilder();

		public OrdersWriter(Orders orders)
		{
			_orders = orders;
		}

		public string GetContents()
		{
			Set_orderDetail();

			return _orderDetail.ToString();
		}

		private void Set_orderDetail()
		{
			_orderDetail.Append("{\"orders\": [");

			for (var i = 0; i < _orders.GetOrdersCount(); i++)
			{
				var order = _orders.GetOrder(i);
				_orderDetail.AppendFormat("{0}\"id\": {1}, \"products\": [", "{", order.GetOrderId());

				SetOrderDetail(order);

				SetCloseChar(order.GetProductsCount() > 0);
				
				_orderDetail.Append(", ");
			}
			SetCloseChar(_orders.GetOrdersCount() > 0);
		}

		private void SetOrderDetail(Order order)
		{
			for (var productCount = 0; productCount < order.GetProductsCount(); productCount++)
			{
				SetProductDetail(order.GetProduct(productCount));
			}
		}

		private void SetProductDetail(Product product)
		{
			_orderDetail.AppendFormat("{0}\"code\": \"{1}\", \"color\": \"{2}\", ", "{", product.Code, product.Color);

			if (product.Size != EnumProductSize.SIZE_NOT_APPLICABLE)
			{
				_orderDetail.AppendFormat("\"size\": \"{0}\", ", product.Size);
			}
			_orderDetail.AppendFormat("\"price\": {0}, \"currency\": \"{1}\"{2}, ", product.Price, product.Currency, "}");
		}

		private void SetCloseChar(bool isRemoveChar)
		{
			if (isRemoveChar)
			{
				_orderDetail.Remove(_orderDetail.Length - 2, 2);
			}
			_orderDetail.Append("]}");
		}
	}
}