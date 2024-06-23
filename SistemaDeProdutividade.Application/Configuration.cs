namespace SistemaDeProdutividade.Application;
public static class Configuration
{
    public const int DefaultStatusCode = 200;
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 15;

    public static string BackendUrl { get; set; } = "http://localhost:5283";
    public static string FrontendUrl { get; set; } = "http://localhost:5167";
}
