using System;
using System.Collections.Generic;

namespace DBEN;

public partial class Movement
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TransactionCatalogId { get; set; }

    public DateOnly MovementDate { get; set; }

    public decimal ValueMovement { get; set; }

    public virtual TransactionCatalog TransactionCatalog { get; set; } = null!;

    public virtual UserFinance User { get; set; } = null!;
}
