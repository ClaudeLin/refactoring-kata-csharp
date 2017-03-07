using System.Collections.Generic;
using System.Text;
using RefactoringKata.Enum;

namespace RefactoringKata
{
	public class OrdersWriter
	{
		private Orders _orders;
		private StringBuilder _orderDetail = new StringBuilder();
		private Dictionary<string, string> _contentDetail;
		public OrdersWriter(Orders orders)
		{
			_orders = orders;
			InitDictionary();
		}

		public string GetContents()
		{
			Set_orderDetail();

			return _orderDetail.ToString();
		}

		private void InitDictionary()
		{
			_contentDetail = new Dictionary<string, string>();
			_contentDetail.Add("openingChar", "{\"orders\": [");
			_contentDetail.Add("order", "{0}\"id\": {1}, \"products\": [");
			_contentDetail.Add("productSizeError", "{0}\"code\": \"{1}\", \"color\": \"{2}\", \"price\": {3}, \"currency\": \"{4}\"{5}, ");
			_contentDetail.Add("product", "{0}\"code\": \"{1}\", \"color\": \"{2}\", \"size\": \"{3}\", \"price\": {4}, \"currency\": \"{5}\"{6}, ");
			_contentDetail.Add("closingChar", "]}");
		}

		private void Set_orderDetail()
		{
			_orderDetail.Append(_contentDetail["openingChar"]);

			for (var i = 0; i < _orders.GetOrdersCount(); i++)
			{
				var order = _orders.GetOrder(i);
				_orderDetail.AppendFormat(_contentDetail["order"], "{", order.GetOrderId());

				SetOrderDetail(order);
			}
			SetCloseChar(_orders.GetOrdersCount() > 0);
		}

		private void SetOrderDetail(Order order)
		{
			for (var i = 0; i < order.GetProductsCount(); i++)
			{
				SetProductDetail(order.GetProduct(i));
			}
			SetCloseChar(order.GetProductsCount() > 0);

			_orderDetail.Append(", ");
		}

		private void SetProductDetail(Product product)
		{
			if (product.Size != EnumProductSize.SIZE_NOT_APPLICABLE)
			{
				_orderDetail.AppendFormat(_contentDetail["product"], "{", product.Code, product.Color, product.Size, product.Price, product.Currency, "}");

			}
			else
			{
				_orderDetail.AppendFormat(_contentDetail["productSizeError"], "{", product.Code, product.Color, product.Price, product.Currency, "}");

			}
		}

		private void SetCloseChar(bool isRemoveChar)
		{
			if (isRemoveChar)
			{
				_orderDetail.Remove(_orderDetail.Length - 2, 2);
			}
			_orderDetail.Append(_contentDetail["closingChar"]);
		}
	}
}