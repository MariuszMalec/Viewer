using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace Viewer.Service
{
    public class VarpoolService : IXmlService
    {
        private string _varpoolFile;

        public VarpoolService(string varpoolFile)
        {
            _varpoolFile = varpoolFile;
        }

        public string GetFromFileValue(string findtext)
        {
            try
            {
                string Value = string.Empty;
                if (File.Exists(_varpoolFile))
                {
                    List<string> listvarpoolNames = new List<string>(new string[] { });
                    List<string> listvarpoolValues = new List<string>(new string[] { });
                    XmlDocument doc = new XmlDocument();
                    doc.Load(_varpoolFile);
                    XPathNavigator navigator = doc.CreateNavigator();
                    XPathNodeIterator nodes = navigator.Select("/VarPool/Overview");
                    string Name = "";
                    XPathNodeIterator nodesName = navigator.Select("/VarPool/Var/Name");
                    foreach (XPathNavigator oCurrent in nodesName)
                    {
                        Name = oCurrent.InnerXml;//Name
                        listvarpoolNames.Add(Name);
                    }
                    XPathNodeIterator nodesValue = navigator.Select("/VarPool/Var/Value");
                    foreach (XPathNavigator oCurrent in nodesValue)
                    {
                        Value = oCurrent.InnerXml;//Name
                        listvarpoolValues.Add(Value);
                    }
                    Value = string.Empty;
                    int count = 0;
                    foreach (string element in listvarpoolNames)
                    {
                        //if(element.Contains(textfind))
                        if (element == findtext)
                        {
                            Value = listvarpoolValues[count].ToString().Replace(" ", "");
                        }
                        count++;
                    }
                    return $"{Value}";
                }
                return $"{Value}";
            }
            catch (Exception e)
            {
                throw new Exception("check function GetFromXmlFileValue", e);
            }
        }
    }
}
