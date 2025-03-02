using System;
using System.Collections.Generic;

namespace testLinq.Model;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public int? AuthorId { get; set; }

    public int? Year { get; set; }

    public string? Genre { get; set; }

    public int? Pages { get; set; }

    public virtual Author? Author { get; set; }
}
