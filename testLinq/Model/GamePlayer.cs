using System;
using System.Collections.Generic;

namespace testLinq.Model;

public partial class GamePlayer
{
    public int GameId { get; set; }

    public int PlayerId { get; set; }

    public int? HoursPlayed { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
