namespace Application.FunctionalTests
{
    public static class ApiRoutes
    {
        private const string _Base = "api/";
        private const string _Values = "values";

        public static string Values { get; private set; } = $"{_Base}{_Values}";
    }
}
