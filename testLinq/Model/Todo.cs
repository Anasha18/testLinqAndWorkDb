using System;
using System.Collections.Generic;

namespace testLinq.Model;

public partial class Todo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string CreatedTime { get; set; } = null!;
}
