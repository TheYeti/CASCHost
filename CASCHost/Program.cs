﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CASCHost
{
	public class Program
	{
		public static void Main(string[] args)
		{

			Directory.CreateDirectory("wwwroot");

			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("hosting.json", optional: true)
				.Build();

			var host = new WebHostBuilder()
				.ConfigureLogging(options => options.AddConsole())
				.UseConfiguration(config)
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseKestrel()
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
	}
}
