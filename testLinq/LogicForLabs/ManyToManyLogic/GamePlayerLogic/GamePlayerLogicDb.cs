using Microsoft.EntityFrameworkCore;
using testLinq.Connection;
using testLinq.LogicForLabs.ManyToManyLogic.GameLogic;
using testLinq.LogicForLabs.ManyToManyLogic.PlayerLogic;
using testLinq.Model;

namespace testLinq.LogicForLabs.ManyToManyLogic.GamePlayerLogic;

public class GamePlayerLogicDb()
{
    private static Barkovskii2323dLearningDbContext _db = new Barkovskii2323dLearningDbContext();
    private GameLogicDb _gameLogicDb = new GameLogicDb(_db);
    private PlayerLogicDb _playerLogicDb = new PlayerLogicDb(_db);


    public void GetAllGamePlayers()
    {
        var gameWithPlayer = _db
            .GamePlayers
            .Include(item => item.Game)
            .Include(item => item.Player)
            .Select(
                item => new
                {
                    item.Game.Name,
                    item.Game.Genre,
                    item.Game.ReleaseYear,
                    item.Player.Username,
                    item.Player.Age,
                    item.Player.Country,
                    item.HoursPlayed
                }
            ).ToList();

        gameWithPlayer.ForEach(i =>
            Console.WriteLine(
                $"Название игры: {i.Name}| Жарн игры: {i.Genre}| Релиз игры: {i.ReleaseYear}| Имя игрока: {i.Username}| Возраст: {i.Age}| Страна: {i.Country}| Часов игры: {i.HoursPlayed}"
            ));
    }

    public void UpdateHoursPlayerForPlayer()
    {
        _gameLogicDb.GetAllGames();
        Console.WriteLine();

        Console.Write("Введите id игры: ");
        int gameId = int.Parse(Console.ReadLine());

        _playerLogicDb.GetAllPlayers();
        Console.WriteLine();

        Console.Write("Введите id игрока: ");
        int playerId = int.Parse(Console.ReadLine());

        var gamePlayer = _db
            .GamePlayers
            .FirstOrDefault(item => item.GameId == gameId && item.PlayerId == playerId);

        if (gamePlayer == null)
        {
            Console.WriteLine("УПС ЧТО-ТО ПОШЛО НЕ ТАК. АШИПКА");
            return;
        }

        Console.Write("Введите количество часов: ");
        int hour = int.Parse(Console.ReadLine());

        gamePlayer.HoursPlayed += hour;

        _db.SaveChanges();
        Console.WriteLine("Количество часов успешно обновлено");
    }

    public void CreateGamePlayers()
    {
        _gameLogicDb.GetAllGames();
        Console.WriteLine();

        Console.Write("Введите id игры: ");
        int gameId = int.Parse(Console.ReadLine());

        _playerLogicDb.GetAllPlayers();
        Console.WriteLine();

        Console.Write("Введите id игрока: ");
        int playerId = int.Parse(Console.ReadLine());

        var gamePlayer = _db
            .GamePlayers
            .FirstOrDefault(item => item.PlayerId == playerId && item.GameId == gameId);

        if (gamePlayer == null)
        {
            Console.WriteLine("ПИЗДЕЦ УЖ ЧЕ");
            return;
        }

        Console.Write("Введите количество часов: ");
        int hour = int.Parse(Console.ReadLine());

        GamePlayer newGamePlayer = new GamePlayer
        {
            GameId = gameId,
            PlayerId = playerId,
            HoursPlayed = hour
        };

        _db.GamePlayers.Add(newGamePlayer);
        _db.SaveChanges();

        Console.WriteLine("Игрок и игра успешео добавлены");
    }
}