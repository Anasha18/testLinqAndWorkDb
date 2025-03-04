using System;
using System.Collections.Generic;

namespace testLinq.Model;

public partial class Game
{
    public int GameId { get; set; }

    public string? Name { get; set; }

    public string? Genre { get; set; }

    public int? ReleaseYear { get; set; }

    public virtual ICollection<GamePlayer> GamePlayers { get; set; } = new List<GamePlayer>();
}
