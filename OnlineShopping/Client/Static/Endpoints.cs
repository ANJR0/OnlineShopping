using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string BrandsEndPoint = $"{Prefix}/brands";
        public static readonly string CategoriesEndPoint = $"{Prefix}/categories";
        public static readonly string CustomersEndPoint = $"{Prefix}/customers";
        public static readonly string DeliveriesEndPoint = $"{Prefix}/deliveries";
        public static readonly string ShopOrdersEndPoint = $"{Prefix}/shopOrders";
        public static readonly string OrderItemsEndPoint = $"{Prefix}/orderItems";
        public static readonly string PaymentsEndPoint = $"{Prefix}/payments";
        public static readonly string ProductsEndPoint = $"{Prefix}/products";
        public static readonly string StaffsEndPoint = $"{Prefix}/staffs";
        public static readonly string AccountsEndPoint = $"{Prefix}/accounts";
    }
}
