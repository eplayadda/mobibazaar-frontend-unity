
using System;
using System.Collections.Generic;
namespace mb
{
    [Serializable]
    public class Order
    {
        public int categoryId;
        public string description;
        public int id;
        public string imageURL;
        public string name;
        public int price;
    }
    [Serializable]

    public class OrderList
    {
        public List<Order> orders;
    }

}