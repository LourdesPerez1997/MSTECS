﻿using System;
using System.Collections.Generic;

namespace MSTECS.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();
}
