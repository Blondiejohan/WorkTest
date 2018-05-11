using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace WorkTest
{
    public class Program
    {

        public static List<Invoice> ConverInvoicesFromTXT(string fileChoice, string path)
        {
            Console.WriteLine("FileChoise: " + fileChoice + " Path: " + path);
            List<Invoice> results = new List<Invoice>();
            var fileList = new List<List<string>>();

            if (fileChoice == "all")
            {
                foreach (string file in Directory.EnumerateFiles(path))
                {
                    var invoiceFromReader = File.ReadAllLines(file).Skip(1).ToList();
                    fileList.Add(invoiceFromReader);
                }
            }
            else
            {
                var invoiceFromReader = File.ReadAllLines(fileChoice).Skip(1).ToList();
                fileList.Add(invoiceFromReader);
            }


            foreach (List<string> file in fileList)
            {
                foreach (string line in file)
                {
                    var values = line.Split(";");

                    Invoice invoice = new Invoice(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7], values[8], values[9], values[10], values[11]);
                    results.Add(invoice);
                }
            }

            return results;
        }

        public static void ConvertToXMLFromInvoiceList(List<Invoice> invoices)
        {
            XmlDocument xmlDocument = new XmlDocument();
            string savePath = "C:\\XmlInvoices";



            XmlNode documentNode = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            xmlDocument.AppendChild(documentNode);

            XmlNode invoicesNode = xmlDocument.CreateElement("invoices");
            xmlDocument.AppendChild(invoicesNode);

            foreach (Invoice invoice in invoices)
            {

                XmlNode invoiceNode = xmlDocument.CreateElement("invoice");

                XmlAttribute InvoiceNumber = xmlDocument.CreateAttribute("InvoiceNumber");
                InvoiceNumber.Value = invoice.InvoiceNumber;
                invoiceNode.Attributes.Append(InvoiceNumber);

                XmlAttribute InvoiceLineNumber = xmlDocument.CreateAttribute("InvoiceLineNumber");
                InvoiceLineNumber.Value = invoice.InvoiceLineNumber;
                invoiceNode.Attributes.Append(InvoiceLineNumber);

                XmlAttribute InvoiceDate = xmlDocument.CreateAttribute("InvoiceDate");
                InvoiceDate.Value = invoice.InvoiceDate;
                invoiceNode.Attributes.Append(InvoiceDate);

                XmlAttribute DueDate = xmlDocument.CreateAttribute("DueDate");
                DueDate.Value = invoice.DueDate;
                invoiceNode.Attributes.Append(DueDate);

                XmlAttribute TotalAmount = xmlDocument.CreateAttribute("TotalAmount");
                TotalAmount.Value = invoice.TotalAmount;
                invoiceNode.Attributes.Append(TotalAmount);

                XmlAttribute CustomerName = xmlDocument.CreateAttribute("CustomerName");
                CustomerName.Value = invoice.CustomerName;
                invoiceNode.Attributes.Append(CustomerName);

                XmlAttribute InvoiceLineAddressStreet = xmlDocument.CreateAttribute("InvoiceLineAddressStreet");
                InvoiceLineAddressStreet.Value = invoice.InvoiceLineAddressStreet;
                invoiceNode.Attributes.Append(InvoiceLineAddressStreet);

                XmlAttribute InvoiceLineAddressZipCode = xmlDocument.CreateAttribute("InvoiceLineAddressZipCode");
                InvoiceLineAddressZipCode.Value = invoice.InvoiceLineAddressZipCode;
                invoiceNode.Attributes.Append(InvoiceLineAddressZipCode);

                XmlAttribute InvoiceLineAddressCity = xmlDocument.CreateAttribute("InvoiceLineAddressCity");
                InvoiceLineAddressCity.Value = invoice.InvoiceLineAddressCity;
                invoiceNode.Attributes.Append(InvoiceLineAddressCity);

                XmlAttribute InvoiceLineChargedWeight = xmlDocument.CreateAttribute("InvoiceLineChargedWeight");
                InvoiceLineChargedWeight.Value = invoice.InvoiceLineChargedWeight;
                invoiceNode.Attributes.Append(InvoiceLineChargedWeight);

                XmlAttribute Currency = xmlDocument.CreateAttribute("Currency");
                Currency.Value = invoice.Currency;
                invoiceNode.Attributes.Append(Currency);

                XmlAttribute Amount = xmlDocument.CreateAttribute("Amount");
                Amount.Value = invoice.Amount;
                invoiceNode.Attributes.Append(Amount);


                invoicesNode.AppendChild(invoiceNode);

            }




            System.IO.Directory.CreateDirectory(savePath);
            xmlDocument.Save(savePath + "\\Invoices.xml");
            Console.WriteLine("");
            Console.WriteLine("Convertion complete");
            Console.WriteLine("");

        }

        public static void DisplayConvertionMenu(string path)
        {
            Console.WriteLine();
            Console.WriteLine("==== csv to xml convertion Menu ====");
            Console.WriteLine();
            Console.WriteLine("Press R to go to main menu");
            Console.WriteLine();
            Console.WriteLine("1. Convert all files");
            Console.WriteLine("2. convert specific file");

            ConsoleKey result = Console.ReadKey(false).Key;

            switch (result)
            {
                case ConsoleKey.D1:
                    int number = 1;
                    List<string> checkList = new List<string>();
                    foreach (string file in Directory.EnumerateFiles(path))
                    {
                        checkList.Add(file);
                    }
                    if (checkList.Count > 0)
                    {

                        bool correct = false;
                        while (!correct)
                        {
                            var options = new List<string>();

                            foreach (string file in Directory.EnumerateFiles(path))
                            {
                                options.Add(file);
                                number++;
                            }


                            if (number > 0)
                            {
                                Console.WriteLine("Testing" + path);
                                ConvertToXMLFromInvoiceList(ConverInvoicesFromTXT("all", path));
                                Console.WriteLine("All files converted");
                                Console.WriteLine();
                                GoToStartMenu();
                                correct = true;
                            }
                            else
                            {
                                Console.WriteLine("No files in path");
                                Console.WriteLine();
                                GoToStartMenu();
                            }
                        }





                    }
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    DisplayFileChooseMenu(path);
                    break;
                case ConsoleKey.R:
                    Console.Clear();
                    DisplayStartMenu();
                    break;
                default:
                    Console.Clear();
                    DisplayConvertionMenu(path);
                    break;
            }
        }

        private static void DisplayFileChooseMenu(string path)
        {
            Console.WriteLine();
            Console.WriteLine("==== File choise Menu ====");
            Console.WriteLine();

            string line;
            int number = 1;
            List<string> checkList = new List<string>();
            foreach (string file in Directory.EnumerateFiles(path))
            {
                checkList.Add(file);
            }
            if (checkList.Count > 0)
            {
                int value;
                bool correct = false;
                while (!correct)
                {
                    var options = new List<string>();
                    Console.WriteLine("type \"back\" to go to go back");
                    Console.WriteLine();
                    Console.WriteLine("Enter the number of the file you want to convert");
                    Console.WriteLine();

                    foreach (string file in Directory.EnumerateFiles(path))
                    {
                        Console.WriteLine(number + ". " + file);
                        options.Add(file);
                        number++;
                    }
                    line = Console.ReadLine();
                    if (line == "back")
                    {
                        DisplayFileChooseMenu(path);
                    }
                    if (int.TryParse(line, out value))
                    {
                        if (value > 0 && value <= number)
                        {
                            ConvertToXMLFromInvoiceList(ConverInvoicesFromTXT(options[value - 1], path));
                            correct = true;
                        }
                        else
                        {
                            Console.WriteLine("Number does not match any file");
                            Console.WriteLine();

                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number corresponding to a file");
                        Console.WriteLine();

                    }
                }
                Console.Clear();
                GoToStartMenu();
            }
            else
            {
                Console.WriteLine("No files in folder");
                Console.WriteLine();

                GoToStartMenu();



            }



        }

        public static void GoToStartMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to go back to main menu");

            ConsoleKey startMenu;
            do
            {
                startMenu = Console.ReadKey(false).Key;
                if (startMenu == ConsoleKey.Enter)
                    DisplayStartMenu();

            } while (startMenu != ConsoleKey.Enter);
        }

        public static void GoToSearchMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to search again or any other key to go to start menu");

            ConsoleKey result = Console.ReadKey(false).Key;

            switch (result)
            {
                case ConsoleKey.Enter:
                    Console.Clear();
                    DisplaySearchMenu();
                    break;
                default:
                    Console.Clear();
                    DisplayStartMenu();
                    break;
            }
        }

        public static void DisplaySearchMenu()
        {
            Console.WriteLine();
            Console.WriteLine("==== Search Menu ====");
            Console.WriteLine();
            Console.WriteLine("Press R to go to main menu");
            Console.WriteLine();
            Console.WriteLine("1. Find invoices by Keyword (Examples: InvoiceLineNumber or CustomerName");
            

            ConsoleKey result = Console.ReadKey(false).Key;

            switch (result)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("");

                    bool d1Correct = false;
                    while (!d1Correct)
                    {
                        Console.WriteLine("Enter the keyword of the invoice you want to find");
                        Console.WriteLine();

                        var line = Console.ReadLine();

                        if (FindInvoiceByKeyword(line))
                        {
                            d1Correct = true;
                        }
                        else
                        {
                            Console.WriteLine("No invoice found with that keyword");
                            Console.WriteLine();
                            GoToSearchMenu();
                        }
                    }

                    break;
                case ConsoleKey.R:
                    Console.Clear();
                    DisplayStartMenu();
                    break;
                default:
                    Console.Clear();
                    DisplaySearchMenu();
                    break;
            }
}





public static bool FindInvoiceByKeyword(string keyword)
{
    bool resBool;

    if (File.Exists("C:\\XmlInvoices\\invoices.xml"))
    {

        var xmlString = File.ReadAllText("C:\\XmlInvoices\\invoices.xml");
        XmlDocument xmlDocument = new XmlDocument();

        if (xmlString.Count() > 0)
        {

            xmlDocument.LoadXml(xmlString);
            XmlDocument xmlDocumentOut = new XmlDocument();

            XmlNodeList elemList = xmlDocument.GetElementsByTagName("invoice");
            foreach (XmlNode xmlNode in elemList)
            {
                var attributes = xmlNode.Attributes;
                foreach (XmlAttribute xmlAttribute in attributes)
                {
                    if (xmlAttribute.Value.Equals(keyword))
                    {
                        Console.WriteLine("");
                        foreach (XmlAttribute xmlAttribute2 in xmlNode.Attributes)
                        {
                            foreach (XmlText xmlStuff in xmlAttribute2.ChildNodes)
                            {
                                Console.Write(xmlStuff.Data + " ");
                            }
                        }
                    }
                }
            }
            xmlDocumentOut.Save(Console.Out);


            resBool = true;
            GoToSearchMenu();


        }
        else
        {
            Console.WriteLine("ID does not match any invoice, please try again.");
            Console.WriteLine();
            resBool = false;
            GoToSearchMenu();
        }

    }
    else
    {
        Console.WriteLine("There have not been any convertions done yet");
        Console.WriteLine();
        resBool = false;
        GoToStartMenu();
    }


    return resBool;

}



public static void DisplayFilePathMenu()
{
    Console.WriteLine();
    Console.WriteLine("==== File path Menu ====");
    Console.WriteLine();
    Console.WriteLine("Press R to go to main menu");
    Console.WriteLine();
    Console.WriteLine("1. Choose default csv location (C:CsvInvoices)");
    Console.WriteLine("2. Enter custom location");

    ConsoleKey result = Console.ReadKey(false).Key;
    string exampleCsvPath = "C:\\CsvInvoices";
    string line;
    switch (result)
    {
        case ConsoleKey.D1:
            Console.Clear();
            DisplayConvertionMenu(exampleCsvPath);
            break;
        case ConsoleKey.R:
            Console.Clear();
            DisplayStartMenu();
            break;
        case ConsoleKey.D2:

            bool correct = false;
            Console.WriteLine("Input folder path for csv");
            Console.WriteLine();
            Console.WriteLine("type \"back\" to go back");


            while (!correct)
            {
                line = Console.ReadLine();
                if (line == "back")
                {
                    DisplayFilePathMenu();
                }
                if (line is string)
                {
                    if (Directory.Exists(line))
                    {
                        correct = true;
                        DisplayConvertionMenu(line);
                    }
                    else
                    {
                        Console.WriteLine("Path does not exist, please input another path");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Path not found, Please input another path");
                    Console.WriteLine();
                }
            }
            break;
        default:
            Console.Clear();
            DisplayFilePathMenu();
            break;
    }
}




public static void DisplayStartMenu()
{
    Console.WriteLine();
    Console.WriteLine("==== Start Menu ====");
    Console.WriteLine();
    Console.WriteLine("Press R to go to main menu");
    Console.WriteLine();
    Console.WriteLine("1. Convert invoices from csv to xml");
    Console.WriteLine("2. Search for invoice");

    ConsoleKey result = Console.ReadKey(false).Key;

    switch (result)
    {
        case ConsoleKey.D1:
            Console.Clear();
            DisplayFilePathMenu();
            break;
        case ConsoleKey.D2:
            Console.Clear();
            DisplaySearchMenu();
            break;
        case ConsoleKey.R:
            Console.Clear();
            DisplayStartMenu();
            break;
        default:
            Console.Clear();
            DisplayStartMenu();
            break;
    }
}



static void Main(string[] args)
{
    DisplayStartMenu();


}
    }
}