using testLinq.Connection;
using testLinq.Model;

namespace testLinq.LogicForLabs.ManyToManyLogic.GameLogic;

public class GameLogicDb(Barkovskii2323dLearningDbContext db)
{
    private Barkovskii2323dLearningDbContext _db = db;
    
    public void CreateGame()
    {
        Console.Write("Введите название игры: ");
        string name = Console.ReadLine();

        Console.Write("Введите жанр игры: ");
        string genre = Console.ReadLine();

        Console.Write("Введите дату релиз игры: ");
        int releaseYear = int.Parse(Console.ReadLine());

        Game newGame = new Game
        {
            Name = name,
            Genre = genre,
            ReleaseYear = releaseYear
        };

        _db.Games.Add(newGame);

        _db.SaveChanges();

        Console.WriteLine("Игра успешно добавлена");
    }

    public void UpdateGame()
    {
        GetAllGames();
        Console.WriteLine();

        Console.Write("Ввдедите id для обновления игры: ");
        int gameId = int.Parse(Console.ReadLine());

        var game = _db
            .Games
            .FirstOrDefault(item => item.GameId == gameId);

        if (game == null)
        {
            Console.WriteLine("Такой игры нет!");
            return;
        }

        Console.Write("Введите название игры: ");
        string name = Console.ReadLine();

        Console.Write("Введите жанр игры: ");
        string genre = Console.ReadLine();

        Console.Write("Введите дату релиз игры: ");
        int releaseYear = int.Parse(Console.ReadLine());

        game.Name = name;
        game.Genre = genre;
        game.ReleaseYear = releaseYear;

        _db.SaveChanges();

        Console.WriteLine("Игра успешно обновлена, МОИ ПОЗДРАВЛЕНИЯ!!");
    }

    public void GetAllGames()
    {
        List<Game> games = _db.Games.ToList();

        games.ForEach(item =>
            Console.WriteLine(
                $"ID: {item.GameId}| Название игры: {item.Name}| Жанр игры: {item.Genre}| Дата релиза игры: {item.ReleaseYear}"
            ));
    }

    public void DeleteGame()
    {
        GetAllGames();
        Console.WriteLine();

        Console.Write("Выберите id для удаления игры: ");
        int gameId = int.Parse(Console.ReadLine());

        var game = _db
            .Games
            .FirstOrDefault(item => item.GameId == gameId);

        if (game == null)
        {
            Console.WriteLine("УПС такой игры нет! ОШИБКА КРЧ");
            return;
        }

        var gamePlayers = _db
            .GamePlayers
            .Where(item => item.GameId == gameId)
            .ToList();

        _db.GamePlayers.RemoveRange(gamePlayers);
        _db.Games.Remove(game);

        _db.SaveChanges();

        Console.WriteLine("Игра успешно удалена!");
    }
}