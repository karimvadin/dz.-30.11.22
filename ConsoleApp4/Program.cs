using ConsoleApp4;
using static System.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        WriteLine("Выберите команду: добавить (необходимо вписать товар), список, сохранить, удалить, открыть");


        while (true)
        {
            var command = ReadLine().ToLower().Split(' ');
            Controller s = new Controller();
            switch (command[0])
            {

                case "добавить":
                    s.AddGood(command[1], float.Parse(command[2]), float.Parse(command[3]), command[4]);
                    break;
                case "список":
                    WriteLine(s.GetGoods());
                    break;
                case "сохранить":
                    s.SaveList();
                    break;
                case "открыть":
                    s.OpenList();
                    break;
                case "удалить":
                    s.Delete();
                    break;

                default:
                    WriteLine("Ошибка в комане");
                    break;

            }
        }

    }
}