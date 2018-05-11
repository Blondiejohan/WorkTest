using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkTest;
using System.IO;

namespace ConsoleApp1Test
{

    [TestClass]
    public class UnitTest1
        
    {
        Invoice testInvoice = new Invoice("1234", "0001", "2018-01-01", "2018-01-05", "141,09", "Daniel Johansson", "Vevgatan 6", "504 64", "Borås", "0,34", "SEK", "100,99");
        string referencexmlDocumentAllInvoices = File.ReadAllText("C:\\XmlInvoice\\TestXmlAll.xml");
        string referencexmlDocumentInvoice1 = File.ReadAllText("C:\\XmlInvoice\\TestxmlInvoice1.xml");

        string referencecsvDocumentAllInvoice1 = File.ReadAllText("C:\\CsvInvoices\\Invoice1Test.txt");


        [TestMethod]
        public void TestReadCsv()
        {
            string testReadCsv = File.ReadAllText("C:\\CsvInvoices\\Invoice1.txt");
            Assert.AreEqual(referencecsvDocumentAllInvoice1, testReadCsv);

        }
        [TestMethod]
        public void TestConvertFromCvsToInvoice()
        {
            var InvoiceList = Program.ConverInvoicesFromTXT("C:\\CsvInvoices\\Invoice1.txt","");
            Assert.AreEqual(InvoiceList[0], testInvoice);

        }
    }
}
