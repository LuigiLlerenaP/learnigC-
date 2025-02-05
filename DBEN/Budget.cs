using System;
using System.Collections.Generic;

namespace DBEN;

public partial class Budget
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int? CategoryId { get; set; }

    public string BudgetName { get; set; } = null!;

    public decimal TotalBudget { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateOnly? ValidUntil { get; set; }

    public virtual Category? Category { get; set; }

    public virtual UserFinance User { get; set; } = null!;
}
