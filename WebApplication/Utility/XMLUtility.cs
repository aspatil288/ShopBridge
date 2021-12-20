using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Configuration;

namespace Utility
{
    public class XMLUtility
    {
        public void SaveXML(DataTable dt, string fileName)
        {
            using (StringWriter sw = new StringWriter())
            {
                dt.WriteXml(sw);
                dt.WriteXml(ConfigurationManager.AppSettings["XMLFilePath"] + fileName); // Get Folder Path from Appconfig or json file as per .net core
            }
        }
        public List<XElement> GetXML(string fileName)
        {
            // read the xml from Folder Path from Appconfig & file name passed
            XDocument xdocument = XDocument.Load(ConfigurationManager.AppSettings["XMLFilePath"] + fileName);
            IEnumerable<XElement> xmlData = from el in xdocument.Root.Elements()
                                            select el;
            return xmlData.ToList();
        }
    }
}
