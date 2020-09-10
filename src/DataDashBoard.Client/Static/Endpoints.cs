namespace DataDashboard.Client.Static
{
    public static class Endpoints
    {
        private static readonly string BaseUrl = "https://localhost:5001";
        public static string CustomersEndpoint = $"{BaseUrl}/api/customers/";
        public static string OrdersEndpoint = $"{BaseUrl}/api/orders/";
        public static string ServersEndpoint = $"{BaseUrl}/api/servers/";
    }
}