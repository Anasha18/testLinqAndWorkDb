using testLinq;
using testLinq.Connection;

// Random random = new Random();
// List<int> listInts = new List<int>();
//
// for (int i = 0; i < 10; i++)
// {
//     listInts.Add(random.Next(-10, 10));
// }
//
// //var sortedList = listInts.Where(item => item % 2 == 0).ToList();
//
// // for (int i = 0; i < sortedList.Count; i++)
// // {
// //     Console.Write(sortedList[i] + " ");
// // }
//
// Console.WriteLine();
// for (int i = 0; i < listInts.Count; i++)
// {
//     Console.Write(listInts[i] + " ");
// }
//
// // List<string> listAsString = new List<string>();
// //
// // listAsString.Add("asfdf");
// // listAsString.Add("qwer");
// // listAsString.Add("poiuyut");
// //
// // var sorted = listAsString.Select(item => item.Length ).ToList();
// //
// // for (int i = 0; i < sorted.Count; i++)
// // {
// //     Console.Write(sorted[i] + " ");
// // }
//
// // List<string> listName =
// // [
// //     "Анастасия",
// //     "Коля",
// //     "Тельман"
// // ];
// //
// // var sortedName = listName.Where(name => name.StartsWith("А")).ToList();
// //
// // for (int i = 0; i < sortedName.Count; i++)
// // {
// //     Console.Write(sortedName[i] + " ");
// // }
//
// Console.WriteLine();
//
// var maxNumberFromListInts = listInts.Max();
// Console.WriteLine(maxNumberFromListInts);
//
// var orderByListInts = listInts.OrderBy(item => item).ToList();
//
// for (int i = 0; i < orderByListInts.Count(); i++)
// {
//     Console.Write(orderByListInts[i] + " ");
// }
//
// Console.WriteLine();
// var squaresListInts = listInts.Select(number => number * number).ToList();
//
// for (int i = 0; i < squaresListInts.Count; i++)
// {
//     Console.Write(squaresListInts[i] + " ");
// }
//
// Console.WriteLine();
//
// var positiveNumbers = listInts.Where(item => item > 0).ToList();
// for (int i = 0; i < positiveNumbers.Count; i++)
// {
//     Console.Write(positiveNumbers[i] + " ");
// }
//
// Console.WriteLine();
//
// var maxNumberIsTen = listInts.Where(num => num > 10).ToList();
//
// for (int i = 0; i < maxNumberIsTen.Count; i++)
// {
//     Console.WriteLine(maxNumberIsTen[i] + " ");
// }
//
// var countListInts = listInts.Count();
// Console.WriteLine(countListInts);
// Console.WriteLine();
//
//
// var sumListInts = listInts.Sum();
// Console.WriteLine(sumListInts);
//
//
// List<User> user =
// [
//     new User("Pashok", 19),
//     new User("Mashok", 15),
//     new User("Max", 30),
// ];
//
// var linqSuser = user.Where(userAge => userAge.Age > 18).ToList();
//
// for (int i = 0; i < linqSuser.Count; i++)
// {
//     Console.WriteLine(linqSuser[i] + " ");
// }
//
// Console.WriteLine();
//
// var groupByWord = user.GroupBy(name => name.Name.StartsWith("P")).ToList();
//
// for (int i = 0; i < groupByWord.Count; i++)
// {
//     Console.WriteLine(groupByWord[i].Key + " ");
//     groupByWord[i].ToList().ForEach(item => Console.WriteLine(item));
// }
//
// Console.WriteLine();
// var avgListInts = listInts.Average();
// Console.WriteLine(avgListInts);
// Console.WriteLine();
//
//
// List<Product> productsNames =
// [
//     new Product(1, "spinogriz"),
//     new Product(2, "spinogriz2"),
// ];
//
// var sortedProducts = productsNames.Select(names => names.Name).ToList();
//
// for (int i = 0; i < sortedProducts.Count; i++)
// {
//     Console.WriteLine(sortedProducts[i] + " ");
// }
//
// Console.WriteLine();
//
// var sortedListInts = listInts.Where(number => number % 3 == 1 && number % 5 == 1).ToList();
//
// for (int i = 0; i < sortedListInts.Count; i++)
// {
//     Console.Write(sortedListInts[i] + " ");
// }
//
// var distinctListInts = listInts.ToList();
//
// distinctListInts.Distinct().ToList().ForEach(item => Console.Write(item + " "));
//
//
// var propusk3ElemList = listInts.ToList();
//
// propusk3ElemList.Skip(3).ToList().ForEach(item => Console.Write(item + " "));
//
// Console.WriteLine();
//
// var positiveListInts = listInts.ToList();
//
// positiveListInts.Where(n => n >= 0).ToList().ForEach(n => Console.Write(n + " "));
// Console.WriteLine();
//
// var secondNumberFromList = listInts.Distinct().OrderByDescending(num => num).Skip(1).FirstOrDefault();
//
// Console.WriteLine(secondNumberFromList);

Barkovskii2323dLearningDbContext db = new Barkovskii2323dLearningDbContext();
OneToManyLogicDb oneToManyLogicDb = new OneToManyLogicDb(db);

Console.WriteLine("Привет, тут можно что-то делать с БД");

while (true)
{
    Console.WriteLine("1. Добавить книгу (только с автором)");
    Console.WriteLine("2. Просмотреть все книги");
    Console.WriteLine("3. Удалить книгу");
    Console.WriteLine("4. Обновить название книги");
    Console.WriteLine("5. Удалить автора");
    Console.WriteLine("6. Закрыть приложение");
    Console.Write("Выберите действие: ");
    int choice = int.Parse(Console.ReadLine());
    Console.WriteLine();

    switch (choice)
    {
        case 1:
        {
            oneToManyLogicDb.AddNewBook();
            
            Console.WriteLine();
        }
            break;
        case 2:
        {
            oneToManyLogicDb.ViewBooks();
            
            Console.WriteLine();
        }
            break;
        case 3:
        {
            oneToManyLogicDb.DeleteBook();
            
            Console.WriteLine();
        }
            break;
        case 4:
        {
            oneToManyLogicDb.UpdateBook();
            
            Console.WriteLine();
        }
            break;
        case 5:
        {
            oneToManyLogicDb.DeleteAuthor();
            
            Console.WriteLine();
        }
            break;
        case 6:
        {
            return;
        }
        default:
            Console.WriteLine("Такого дейвствия нет! Выберите из предстваленого списка");
            break;
    }
}