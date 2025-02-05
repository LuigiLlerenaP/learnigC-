using System;
using System.Collections.Generic;

namespace DBEN;

public partial class TransactionCatalog
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string TransactionType { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Movement> Movements { get; set; } = new List<Movement>();
}
