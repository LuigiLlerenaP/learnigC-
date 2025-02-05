using System;
using System.Collections.Generic;

namespace DBEN;

public partial class UserFinance
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal InitialBudget { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual ICollection<Movement> Movements { get; set; } = new List<Movement>();
}
