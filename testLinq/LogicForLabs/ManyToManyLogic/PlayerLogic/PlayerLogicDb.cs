using testLinq.Connection;
using testLinq.Model;

namespace testLinq.LogicForLabs.ManyToManyLogic.PlayerLogic;

public class PlayerLogicDb(Barkovskii2323dLearningDbContext db)
{
    private Barkovskii2323dLearningDbContext _db = db;
    
    public void CreatePlayer()
    {
        Console.Write("Введите имя пользовтеля: ");
        string username = Console.ReadLine();

        Console.Write("Введите возвраст: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Введите страну: ");
        string country = Console.ReadLine();

        Player newPlayer = new Player
        {
            Username = username,
            Age = age,
            Country = country
        };

        _db.Players.Add(newPlayer);

        _db.SaveChanges();
        Console.WriteLine("Игрок успешно добавлен");
    }


    public void UpdatePlayer()
    {
        GetAllPlayers();
        Console.WriteLine();

        Console.Write("Ввдедите id для обновления пользователя: ");
        int playerId = int.Parse(Console.ReadLine());

        var player = _db
            .Players
            .FirstOrDefault(item => item.PlayerId == playerId);

        if (player == null)
        {
            Console.WriteLine("Такой игры нет!");
            return;
        }

        Console.Write("Введите имя пользовтеля: ");
        string username = Console.ReadLine();

        Console.Write("Введите возвраст: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Введите страну: ");
        string country = Console.ReadLine();

        player.Username = username;
        player.Age = age;
        player.Country = country;

        _db.SaveChanges();

        Console.WriteLine("Игрок успешно обновлен, МОИ ПОЗДРАВЛЕНИЯ!!");
    }

    public void GetAllPlayers()
    {
        List<Player> players = _db
            .Players
            .ToList();

        players.ForEach(item => 
            Console.WriteLine(
            $"ID: {item.PlayerId}| Имя пользователя: {item.Username}| Возвраст: {item.Age}| Страна: {item.Country}"
        ));
    }

    public void DeletePlayer()
    {
        GetAllPlayers();
        Console.WriteLine();
        
        Console.Write("Введите id для удаления пользователя: ");
        int playerId = int.Parse(Console.ReadLine());

        var player = _db
            .Players
            .FirstOrDefault(item => item.PlayerId == playerId);

        if (player == null)
        {
            Console.WriteLine("Такого игрока нет!");
            return;
        }

        List<GamePlayer> players = _db
            .GamePlayers
            .Where(item => item.PlayerId == playerId)
            .ToList();

        _db.GamePlayers.RemoveRange(players);
        _db.Players.Remove(player);

        _db.SaveChanges();

        Console.WriteLine("Игкрок успешно удален!");
    }
}