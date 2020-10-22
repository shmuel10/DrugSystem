using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

namespace BLL
{
    class CheckInteraction
    {
        private XmlDocument drugsNums;
        public CheckInteraction()
        {
            //drugsNums = new XmlDocument();
            //string p2 = @"../xmlFiles/mainxml.xml";
            //drugsNums.Load(p2);



            //string p8 = @"C:\Users\OWNER\Source\Repos\DrugSystem\DrugSystem\DrugSystem\bin\Debug\BLL\xmlFiles\mainxml.xml";
            //string str = Regex.Replace(p8, "DrugSystem\\bin$", @"BLL\xmlFiles\mainxml.xml");
            //string p = Path.GetFullPath(@"BLL\xmlFiles\mainxml.xml");
            //drugsNums.Load(p);

        }
        public List<string> GetInteractionMedicines(string medicineName)
        {
            int drugNum = FindMedicineID(medicineName);
            List<string> interactionMedicines = new List<string>();
            try
            {
                string interactionJsonString = HttpRequest(GenerateURL(drugNum));
                Root interactionObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(interactionJsonString);
                if (interactionObj.interactionTypeGroup != null)
                {
                    foreach (var item in interactionObj.interactionTypeGroup)
                    {
                        foreach (var item1 in item.interactionType)
                        {
                            foreach (var item2 in item1.interactionPair)
                            {
                                foreach (var item3 in item2.interactionConcept)
                                {
                                    if (item3.sourceConceptItem.name != medicineName)
                                    {
                                        interactionMedicines.Add(item3.sourceConceptItem.name);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("Error");
            }
            return interactionMedicines;
        }

        public int FindMedicineID(string name)
        {
            int result;
            XmlElement root = drugsNums.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("minConcept"); // You can also use XPath here
            foreach (XmlNode node in nodes)
            {
                XmlNodeList properties = node.ChildNodes;
                if (properties[1].InnerText.ToLower() == name.ToLower())
                {
                    result = int.Parse(properties[0].InnerText);
                    return result;
                }
            }
            throw new ArgumentException("Can't find medicine name");
        }

        private string HttpRequest(String url)
        {

            string html = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }
            return html;
        }

        private string GenerateURL(int drugNum)
        {
            string first = @"https://rxnav.nlm.nih.gov/REST/interaction/interaction.json?rxcui=";
            string second = @"&sources=ONCHigh";
            return first + drugNum.ToString() + second;
        }

        public class UserInput
        {
            public List<string> sources { get; set; }
            public string rxcui { get; set; }
        }

        public class MinConceptItem
        {
            public string rxcui { get; set; }
            public string name { get; set; }
            public string tty { get; set; }
        }

        public class MinConceptItem2
        {
            public string rxcui { get; set; }
            public string name { get; set; }
            public string tty { get; set; }
        }

        public class SourceConceptItem
        {
            public string id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class InteractionConcept
        {
            public MinConceptItem2 minConceptItem { get; set; }
            public SourceConceptItem sourceConceptItem { get; set; }
        }

        public class InteractionPair
        {
            public List<InteractionConcept> interactionConcept { get; set; }
            public string severity { get; set; }
            public string description { get; set; }
        }

        public class InteractionType
        {
            public string comment { get; set; }
            public MinConceptItem minConceptItem { get; set; }
            public List<InteractionPair> interactionPair { get; set; }
        }

        public class InteractionTypeGroup
        {
            public string sourceDisclaimer { get; set; }
            public string sourceName { get; set; }
            public List<InteractionType> interactionType { get; set; }
        }

        public class Root
        {
            public string nlmDisclaimer { get; set; }
            public UserInput userInput { get; set; }
            public List<InteractionTypeGroup> interactionTypeGroup { get; set; }
        }
    }
}

