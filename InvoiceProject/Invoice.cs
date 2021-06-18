using System;
using System.Collections.Generic;

namespace InvoiceProject
{
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceLine> LineItems { get; set; }

        public void AddInvoiceLine(InvoiceLine invoiceLine)
        {
            LineItems.Add(invoiceLine);
        }

        public void RemoveInvoiceLine(int SOMEID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetTotal should return the sum of (Cost * Quantity) for each line item
        /// </summary>
        public decimal GetTotal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// MergeInvoices appends the items from the sourceInvoice to the current invoice
        /// </summary>
        /// <param name="sourceInvoice">Invoice to merge from</param>
        public void MergeInvoices(Invoice sourceInvoice)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a deep clone of the current invoice (all fields and properties)
        /// </summary>
        public Invoice Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Invoice Number: [InvoiceNumber], InvoiceDate: [dd/MM/yyyy], LineItemCount: [Number of items in LineItems]
        /// </summary>
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
