using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeafTests
{
    public class Centertest
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
        public void NewCenter()
        {

            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("code", "FAS");
            values.Add("name", "FUNDACIO PROVA");
            values.Add("nif", "123123X");
            values.Add("address", "Carrer del mar 5 s/n");
            values.Add("city", "Reus");
            values.Add("pc", "43201");
            values.Add("creationDate", "01/01/4052 00:00:00");

            Leaf.Models.Center center = new Leaf.Models.Center(values, _config);
            Leaf.Models.Center createdcenter = center.Create();

            Assert.IsNotNull(createdcenter);
        }

        [Test]
        public void NewCenter_withExistingCode()
        {

            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("code", "TEST");
            values.Add("name", "FUNDACIO PROVA");
            values.Add("nif", "123123X");
            values.Add("address", "Carrer del mar 5 s/n");
            values.Add("city", "Reus");
            values.Add("pc", "43201");
            values.Add("creationDate", "01/01/4052 00:00:00");

            Leaf.Models.Center center = new Leaf.Models.Center(values, _config);
            Leaf.Models.Center createdCenter;

            try {
                createdCenter = center.Create();
            } catch (Exception)
            {
                createdCenter = null;
                
            }

            Assert.IsNull(createdCenter);

        }

        [Test]
        public void NewCenter_withSettedId()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("id", "1");
            values.Add("code", "FAS");
            values.Add("name", "FUNDACIO PROVA");
            values.Add("nif", "123123X");
            values.Add("address", "Carrer del mar 5 s/n");
            values.Add("city", "Reus");
            values.Add("pc", "43201");
            values.Add("creationDate", "01/01/4052 00:00:00");

            Leaf.Models.Center center = new Leaf.Models.Center(values, _config);
            Leaf.Models.Center createdCenter;

            try
            {
                createdCenter = center.Create();
            }
            catch (Exception)
            {
                createdCenter = null;

            }

            Assert.IsNull(createdCenter);

        }

        [Test]
        public void GetCenterById()
        {
            Leaf.Models.Center center = new Leaf.Models.Center(1, _config);
            Assert.IsNotNull(center);
        }

        [Test]
        public void GetCenterByCode()
        {
            Leaf.Models.Center center = new Leaf.Models.Center("TEST", _config);
            Assert.IsNotNull(center);
        }

        [Test]
        public void SaveCenter()
        {

            Leaf.Models.Center patient = new Leaf.Models.Center(1, _config);
            patient.City = "New City";
            Assert.IsNotNull(patient.Save());
        }

        [Test]
        public void SaveCenter_withoutSettedNHC()
        {

            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("code", "FAS");
            values.Add("name", "FUNDACIO PROVA");
            values.Add("nif", "123123X");
            values.Add("address", "Carrer del mar 5 s/n");
            values.Add("city", "Reus");
            values.Add("pc", "43201");
            values.Add("creationDate", "01/01/4052 00:00:00");

            Leaf.Models.Center center = new Leaf.Models.Center(values, _config);
            Leaf.Models.Center savedCenter;

            try
            {
                savedCenter = center.Save();
            }
            catch (Exception)
            {
                savedCenter = null;

            }

            Assert.IsNull(savedCenter);
        }
    }
}