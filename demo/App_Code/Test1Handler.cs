using System.Web;
using System.IO;

/// <summary>
/// Сводное описание для Test1Handler
/// </summary>
public class Test1Handler : IHttpHandler
{
    private const string fileName = "index.html";

    public bool IsReusable => true;

    public void ProcessRequest(HttpContext context)
    {
        context.Response.Write(File.ReadAllText(fileName));
    }
}