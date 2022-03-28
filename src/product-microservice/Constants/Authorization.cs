namespace product_microservice.Constants
{
    public class Authorization
    {
        public class Policy
        {
            public const string ReadProducts = "read:business";
        }        

        public class RequireClaim
        {
            public const string Permissions = "permissions";
            public const string Scope = "scope";
        }
    }
}
