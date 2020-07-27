using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeafTests
{
    public class ApiLogtest
    {
        IConfiguration _config;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(@"C:\Projects\LeafTests")
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _config = builder.Build();

            Tools.InitDatabase(_config);

        }

        [Test]
        public void NewLog()
        {

            Leaf.Models.ApiLog apilog = new Leaf.Models.ApiLog(_config);
            apilog.Id = "testhash";
            apilog.Method = "POST";
            apilog.Headers = Newtonsoft.Json.JsonConvert.SerializeObject("Headers");
            apilog.Scheme = "scheme";
            apilog.Host = "HOST";
            apilog.Path = "/url/get";
            apilog.QueryString = Newtonsoft.Json.JsonConvert.SerializeObject("querystring");
            apilog.RemoteIPAdress = "Remote ip address";
            apilog.Response = Newtonsoft.Json.JsonConvert.SerializeObject("preresponse");

            Assert.IsNotNull(apilog.Create());
        }

        [Test]
        public void GetLogById()
        {
            Leaf.Models.ApiLog apilog = new Leaf.Models.ApiLog("da8b4d2db8738078c9a1cd7882eb76dd", _config);
            Assert.IsNotNull(apilog);
        }


        [Test]
        public void SaveLog()
        {

            Leaf.Models.ApiLog apilog = new Leaf.Models.ApiLog("da8b4d2db8738078c9a1cd7882eb76dd", _config);
            apilog.Response = "200 OK";
            Assert.IsNotNull(apilog.Save());
        }

    }
}