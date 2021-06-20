using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace InvoiceProject
{
    [Serializable]
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceLine> LineItems { get; set; }

        public Invoice()
        {
            LineItems = new List<InvoiceLine>();
        }

        /// <summary>
        /// AddInvoiceLine adds a new entry to the list of line items
        /// </summary>
        public void AddInvoiceLine(InvoiceLine invoiceLine)
        {
            LineItems.Add(invoiceLine);
        }

        /// <summary>
        /// RemoveInvoiceLine removes an existing entry from the list of line items
        /// </summary>
        public void RemoveInvoiceLine(int invoiceLineId)
        {
            var entry = LineItems.Single(item => item.InvoiceLineId == invoiceLineId);
            LineItems.Remove(entry);
        }

        /// <summary>
        /// GetTotal should return the sum of (Cost * Quantity) for each line item
        /// </summary>
        public decimal GetTotal()
        {
            return LineItems.Aggregate(0m, (result, item) => result += item.Cost * item.Quantity);
        }

        /// <summary>
        /// MergeInvoices appends the items from the sourceInvoice to the current invoice
        /// </summary>
        /// <param name="sourceInvoice">Invoice to merge from</param>
        public void MergeInvoices(Invoice sourceInvoice)
        {
            LineItems.AddRange(sourceInvoice.LineItems);
        }

        /// <summary>
        /// Creates a deep clone of the current invoice (all fields and properties)
        /// </summary>
        public Invoice Clone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (Invoice)formatter.Deserialize(ms);
            }
        }

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Invoice Number: [InvoiceNumber], InvoiceDate: [dd/MM/yyyy], LineItemCount: [Number of items in LineItems]
        /// </summary>
        public override string ToString()
        {
            return $"Invoice Number: {InvoiceNumber}, InvoiceDate: {InvoiceDate.ToShortDateString()}, LineItemCount: {LineItems.Count()}";
        }
    }
}
