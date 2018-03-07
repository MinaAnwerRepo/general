using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

namespace test_schema_validation
{
    class Program
    {

        public static bool ValidateXMLRequestAgainstXSD(string _InquireCustomerCardsRequest, string _XMLSchema, string _Namespace)
        {
            XDocument XML = XDocument.Parse(_InquireCustomerCardsRequest);
            XmlSchemaSet Schemas = new XmlSchemaSet();
            Schemas.Add(_Namespace, XmlReader.Create(new StringReader(_XMLSchema)));
            try
            {
                XML.Validate(Schemas, null);
            }
            catch (XmlSchemaValidationException)
            {
                return false;
            }

            return true;
        }

  
        static void Main(string[] args)
        {
            // ValidateXMLRequestAgainstXSD
            //string schema = System.IO.File.ReadAllText(@"C:\Users\m.lewes\Desktop\finalschema\InquireCreditCardRequest.xsd");
            //string xmltxt = System.IO.File.ReadAllText(@"C:\Users\m.lewes\Desktop\finalschema\RestrictCardXML.xml");
            //   Console.WriteLine(ValidateXMLRequestAgainstXSD(xmltxt,schema, @"http://www.w3.org/2001/XMLSchema"));
            CspParameters cspparams = new CspParameters();
            cspparams.KeyContainerName = "XML_DSIG_RSA_KEY";
            RSACryptoServiceProvider rsakey = new  RSACryptoServiceProvider(cspparams);

             var result = VerifyXmlFile(@"C:\Users\m.lewes\Desktop\finalschema\test.xml",rsakey);

             Console.WriteLine(result.ToString());
             Console.ReadLine();

        }


        public static void SignXML(string path, RSA key)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.PreserveWhitespace = true;
                xmldoc.Load(path);
                SignedXml signedXml = new SignedXml(xmldoc);
                signedXml.SigningKey = key;
                Reference reference = new Reference();
                reference.Uri = "";
                XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                reference.AddTransform(env);
                signedXml.AddReference(reference);
                signedXml.ComputeSignature();
                XmlElement xmlDifitalSignature = signedXml.GetXml();
                xmldoc.DocumentElement.AppendChild(xmldoc.ImportNode(xmlDifitalSignature, true));
                xmldoc.Save(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

        }


        public static Boolean VerifyXmlFile(String Name, RSA Key)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Name);
            SignedXml signedXml = new SignedXml(xmlDocument);
            XmlNodeList nodeList = xmlDocument.GetElementsByTagName("Signature");
            signedXml.LoadXml((XmlElement)nodeList[0]);
            return signedXml.CheckSignature(Key);
        }



    }
}
