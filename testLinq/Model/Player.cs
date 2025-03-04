using System;
using System.Collections.Generic;

namespace testLinq.Model;

public partial class Player
{
    public int PlayerId { get; set; }

    public string? Username { get; set; }

    public int? Age { get; set; }

    public string? Country { get; set; }

    public virtual ICollection<GamePlayer> GamePlayers { get; set; } = new List<GamePlayer>();
}
