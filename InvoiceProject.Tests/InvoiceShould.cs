using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceProject.Tests
{
    public class InvoiceShould
    {
        [Test]
        public void AddInvoiceLine()
        {
            var invoice = new Invoice();

            var invoiceLineId = 1;
            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = invoiceLineId,
                Cost = 6.99m,
                Quantity = 1,
                Description = "Apple"
            });

            Assert.IsTrue(invoice.LineItems.Any(item => item.InvoiceLineId == invoiceLineId));
            Assert.AreEqual(1, invoice.LineItems.Count());
        }

        [Test]
        public void RemoveInvoiceLine()
        {
            var invoice = new Invoice();

            var invoiceLineId = 1;
            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = invoiceLineId,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            });

            invoice.RemoveInvoiceLine(invoiceLineId);

            Assert.AreEqual(0, invoice.LineItems.Count());
        }

        [Test]
        public void GetTotal()
        {
            var invoice = new Invoice();

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 10.21m,
                Quantity = 4,
                Description = "Banana"
            });

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            });

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 3,
                Cost = 5.21m,
                Quantity = 5,
                Description = "Pineapple"
            });

            Assert.AreEqual(72.10m, invoice.GetTotal());
        }

        [Test]
        public void MergeInvoices()
        {
            var invoice1 = new Invoice();

            invoice1.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 10.33m,
                Quantity = 4,
                Description = "Banana"
            });

            var invoice2 = new Invoice();
            var invoiceLineId = 2;

            invoice2.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = invoiceLineId,
                Cost = 5.22m,
                Quantity = 1,
                Description = "Orange"
            });

            invoice1.MergeInvoices(invoice2);

            Assert.AreEqual(2, invoice1.LineItems.Count());
            Assert.IsTrue(invoice1.LineItems.Any(item => item.InvoiceLineId == invoiceLineId));
        }

        [Test]
        public void CloneInvoice()
        {
            var invoice = new Invoice();
            var invoiceLineId = 1;

            invoice.AddInvoiceLine(new InvoiceLine()
            {
                InvoiceLineId = invoiceLineId,
                Cost = 6.99m,
                Quantity = 1,
                Description = "Apple"
            });

            var clonedInvoice = invoice.Clone();
            invoice.RemoveInvoiceLine(1);

            Assert.IsTrue(clonedInvoice.LineItems.Any(item => item.InvoiceLineId == invoiceLineId));
        }

        [Test]
        public void OutputCustomString()
        {
            var date = DateTime.Now;
            var invoice = new Invoice()
            {
                InvoiceDate = date,
                InvoiceNumber = 1000,
                LineItems = new List<InvoiceLine>()
                {
                    new InvoiceLine()
                    {
                        InvoiceLineId = 1,
                        Cost = 6.99m,
                        Quantity = 1,
                        Description = "Apple"
                    }
                }
            };

            var expected = $"Invoice Number: 1000, InvoiceDate: {date.ToShortDateString()}, LineItemCount: 1";
            Assert.AreEqual(expected, invoice.ToString());
        }
    }
}