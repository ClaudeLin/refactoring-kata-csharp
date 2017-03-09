﻿using System.Collections.Generic;
using System.Linq;

namespace RefactoringKata
{
    public class Orders
    {
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public int GetOrdersCount()
        {
            return _orders.Count;
        }

        public Order GetOrder(int i)
        {
            return _orders[i];
        }

	    public string ToJsonString()
	    {
			return $"{{\"orders\": [{string.Join(", ", _orders.Select(o => o.ToJsonString()))}]}}";
	    }
    }
}
