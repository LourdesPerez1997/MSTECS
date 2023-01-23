using System;
using System.Collections.Generic;

namespace MSTECS.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public DateTime Date { get; set; }

    public int? ClientId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; } = new List<InvoiceDetail>();
}
