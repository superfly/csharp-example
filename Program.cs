using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace fly_example
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
      string port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
      string url = string.Concat("http://0.0.0.0:", port);

      return WebHost.CreateDefaultBuilder(args)
                 .UseKestrel()
                 .UseStartup<Startup>()
                 .ConfigureLogging((hostingContext, logging) =>
                 {
                   logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                   logging.AddConsole();
                   logging.AddDebug();
                   logging.AddEventSourceLogger();
                 })
                 .UseUrls(url);

    }
  }
}
