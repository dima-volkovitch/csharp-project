using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Сводное описание для TestHandler
/// </summary>
public class TestHandler : IHttpHandler 
{
    public bool IsReusable => true;



    void IHttpHandler.ProcessRequest(HttpContext context)
    {
        string[] args = context.Request.Url.PathAndQuery.Split('/');

        double a = double.Parse(args[1]);
        double b = double.Parse(args[2]);
        double c = double.Parse(args[3]);

        string html = File.ReadAllText("response.html");
        string[] ans = Calculator.GetAnswer(a, b, c);

      
        context.Response.Write(string.Format(html, a, b, c, ans[0], ans[1]));
    }
}