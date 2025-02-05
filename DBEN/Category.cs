using System;
using System.Collections.Generic;

namespace DBEN;

public partial class Category
{
    public int Id { get; set; }

    public int? ParentCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();

    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<TransactionCatalog> TransactionCatalogs { get; set; } = new List<TransactionCatalog>();
}
