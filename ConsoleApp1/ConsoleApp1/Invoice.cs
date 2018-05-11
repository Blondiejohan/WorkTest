using System;


namespace WorkTest
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public string InvoiceLineNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string DueDate { get; set; }
        public string TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceLineAddressStreet { get; set; }
        public string InvoiceLineAddressZipCode { get; set; }
        public string InvoiceLineAddressCity { get; set; }
        public string InvoiceLineChargedWeight { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }

        public Invoice(string invoiceNumber, string invoiceLineNumber, string invoiceDate, string dueDate, string totalAmount, string customerName, string invoiceLineAddressStreet, string invoiceLineAddressZipCode, string invoiceLineAddressCity, string invoiceLineChargedWeight, string currency, string amount)
        {
            InvoiceNumber = invoiceNumber;
            InvoiceLineNumber = invoiceLineNumber;
            InvoiceDate = invoiceDate;
            DueDate = dueDate;
            TotalAmount = totalAmount;
            CustomerName = customerName;
            InvoiceLineAddressStreet = invoiceLineAddressStreet;
            InvoiceLineAddressZipCode = invoiceLineAddressZipCode;
            InvoiceLineAddressCity = invoiceLineAddressCity;
            InvoiceLineChargedWeight = invoiceLineChargedWeight;
            Currency = currency;
            Amount = amount;
           

        }
        //Other properties, methods, events...
    }
}