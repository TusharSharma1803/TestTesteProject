namespace Test_Taste_Console_Application.Constants
{
    public static class HttpClientSettings
    {
        public const string JsonType = "application/json";

        public const string AuthType = "Bearer";

        //[Tushar sharma] - 26th oct 2025 
        // API key to authorize the API calls.
        // Got this from the same API provided in the doc. 
        // Below is the source of key.
        // https://api.le-systeme-solaire.net/en/generatekey.html
        public const string APIKey = "2e53ac3a-59b7-4c2c-a1b5-e755e0987430";
    }
}
