namespace SistemaDeProdutividade.Web;

public class WebConfiguration
{
    public const string HttpClientName = "Api";
    public static string BackendUrl { get; set; } = "http://localhost:5283";
    public static string FrontendUrl { get; set; } = "http://localhost:5167";
}
