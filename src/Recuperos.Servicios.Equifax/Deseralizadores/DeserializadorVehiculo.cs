using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Recuperos.Servicios.Equifax.Deseralizadores
{
    public static class DeserializadorVehiculo
    {
        public static T Deserializar<T>(string soapResponse)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(soapResponse);

            var soapBody = xmlDocument.GetElementsByTagName("soapenv:Body")[0];
            string innerObject = soapBody.InnerXml;

            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(innerObject.Replace("sch:", "")))
            {
                return (T)deserializer.Deserialize(reader);
            }
        }
    }
}
