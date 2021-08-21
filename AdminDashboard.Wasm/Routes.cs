namespace AdminDashboard.Wasm
{
    public static class Routes
    {
        public static class BusinessPartner
        {
            public const string Index = "/business-partner/index";
            public const string Create = "/business-partner/create";
            public const string Get = "/business-partner/{walletAddress}";
            public const string Update = "/business-partner";
            public const string Delete = "/business-partner/{walletAddress}";

        }

        public static class Employee
        {
            public const string Index = "/employee/index";
            public const string Create = "/employee/create";
            public const string Get = "/employee/{walletAddress}";
            public const string Update = "/employee";
            public const string Delete = "/employee/{walletAddress}";
        }

        public static class Contracts
        {
            public const string Index = "/app/v1/{address}/contracts/get";
            public const string Get = "/app/v1/{address}/contracts/get";
        }
    }
}
