using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeafTests
{
    public class PatientTest
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
        public void NewPatient_withDNI()
        {

            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("name", "Chuck");
            values.Add("surname", "Norris");
            values.Add("lastname", "");
            values.Add("dni", "20asdsd8F");
            values.Add("phone", "680305080");
            values.Add("phoneAlt", "977854258");
            values.Add("address", "Carrer del mar 5 s/n");
            values.Add("city", "Reus");
            values.Add("pc", "43201");
            values.Add("sex", "1");
            values.Add("note", "Nothing to say");
            values.Add("lastAccess", "");
            values.Add("email", "chuck.norris@google.apple");
            values.Add("center", "1");
            values.Add("bornDate", "01/01/4052");

            Leaf.Models.Patient patient = new Leaf.Models.Patient(values, _config);
            Leaf.Models.Patient createdPatient = patient.Create();

            Assert.IsNotNull(createdPatient);
        }

        [Test]
        public void NewPatient_withExistingDNI()
        {

            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("name", "Chuck");
            values.Add("surname", "Norris");
            values.Add("lastname", "");
            values.Add("dni", "20847888F");
            values.Add("phone", "680305080");
            values.Add("phoneAlt", "977854258");
            values.Add("address", "Carrer del mar 5 s/n");
            values.Add("city", "Reus");
            values.Add("pc", "43201");
            values.Add("sex", "1");
            values.Add("note", "Nothing to say");
            values.Add("lastAccess", "");
            values.Add("email", "chuck.norris@google.apple");
            values.Add("center", "1");
            values.Add("bornDate", "01/01/4052");

            Leaf.Models.Patient patient = new Leaf.Models.Patient(values, _config);
            Leaf.Models.Patient createdPatient;

            try { 
                createdPatient = patient.Create();
            } catch (Exception)
            {
                createdPatient = null;
                
            }

            Assert.IsNull(createdPatient);

        }

        [Test]
        public void NewPatient_withSettedNHC()
        {

            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("nhc", "21344");
            values.Add("name", "Chuck");
            values.Add("surname", "Norris");
            values.Add("lastname", "");
            values.Add("dni", "5464dgdfg");
            values.Add("phone", "680305080");
            values.Add("phoneAlt", "977854258");
            values.Add("address", "Carrer del mar 5 s/n");
            values.Add("city", "Reus");
            values.Add("pc", "43201");
            values.Add("sex", "1");
            values.Add("note", "Nothing to say");
            values.Add("lastAccess", "");
            values.Add("email", "chuck.norris@google.apple");
            values.Add("center", "1");
            values.Add("bornDate", "01/01/4052");

            Leaf.Models.Patient patient = new Leaf.Models.Patient(values, _config);
            Leaf.Models.Patient createdPatient;

            try
            {
                createdPatient = patient.Create();
            }
            catch (Exception)
            {
                createdPatient = null;

            }

            Assert.IsNull(createdPatient);

        }

        [Test]
        public void NewPatient_withoutDNI()
        {

            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("name", "Chuck");
            values.Add("surname", "Norris");
            values.Add("lastname", "Again");
            values.Add("dni", "");
            values.Add("phone", "180305080");
            values.Add("phoneAlt", "177854258");
            values.Add("address", "Carrer del mar 4 s/n");
            values.Add("city", "Reus");
            values.Add("pc", "43201");
            values.Add("sex", "1");
            values.Add("note", "Nothing to say");
            values.Add("lastAccess", "");
            values.Add("email", "chuck.norris@google.apple");
            values.Add("center", "1");
            values.Add("bornDate", "01/01/4052");

            Leaf.Models.Patient patient = new Leaf.Models.Patient(values, _config);
            Leaf.Models.Patient createdPatient = patient.Create();

            Assert.IsNotNull(createdPatient);
        }

        [Test]
        public void GetPatientByNHC()
        {

            Leaf.Models.Patient patient = new Leaf.Models.Patient(1, _config);
            Assert.IsNotNull(patient);
        }

        [Test]
        public void GetPatientByDNI()
        {

            Leaf.Models.Patient patient = new Leaf.Models.Patient("20847888F", _config);
            Assert.IsNotNull(patient);
        }

        [Test]
        public void SavePatient()
        {

            Leaf.Models.Patient patient = new Leaf.Models.Patient("20847888F", _config);
            patient.PhoneAlt = "43543543";
            Assert.IsNotNull(patient.Save());
        }

        [Test]
        public void SavePatient_withoutSettedNHC()
        {

            Dictionary<string, string> values = new Dictionary<string, string>();

            values.Add("name", "Chuck");
            values.Add("surname", "Norris");
            values.Add("lastname", "Again");
            values.Add("dni", "");
            values.Add("phone", "180305080");
            values.Add("phoneAlt", "177854258");
            values.Add("address", "Carrer del mar 4 s/n");
            values.Add("city", "Reus");
            values.Add("pc", "43201");
            values.Add("sex", "1");
            values.Add("note", "Nothing to say");
            values.Add("lastAccess", "");
            values.Add("email", "chuck.norris@google.apple");
            values.Add("center", "1");
            values.Add("bornDate", "01/01/4052");

            Leaf.Models.Patient patient = new Leaf.Models.Patient(values, _config);
            Leaf.Models.Patient savedPatient;

            try
            {
                savedPatient = patient.Save();
            }
            catch (Exception)
            {
                savedPatient = null;

            }

            Assert.IsNull(savedPatient);
        }
    }
}