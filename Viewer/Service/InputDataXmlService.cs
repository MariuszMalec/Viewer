using System;
using System.Xml;

namespace Viewer.Service
{
    public class InputDataXmlService : IXmlService
    {
        private string _inputXmlFile;

        public InputDataXmlService(string inputXmlFile)
        {
            _inputXmlFile = inputXmlFile;
        }

        public string GetFromFileValue(string findtext)
        {
            try
            {
                string value = "-";
                if (System.IO.File.Exists(_inputXmlFile))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_inputXmlFile);
                    XmlNodeList nodeList = doc.DocumentElement.SelectNodes("/DANE");
                    foreach (XmlNode node in nodeList)
                    {
                        if (node.SelectSingleNode(findtext) == null)
                        {
                            return "-";
                        }
                        value = node.SelectSingleNode(findtext).InnerText;
                    }
                    return $"{value}";
                }
                return $"{value}";
            }
            catch (Exception e)
            {
                throw new Exception("check function GetFromFileValue", e);
            }
        }
    }
}
