using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Controller
    {
        public static List<Good> Goods = new List<Good>();

        public void AddGood(string title, float price, float sale, string desc)
        {
            Good good = new Good()
            {
                Title = title,
                Price = price,
                Sale = sale,
                Description = desc
            };
            good.Price = good.Price - good.Sale;
            Goods.Add(good);
        }

        public string GetGoods()
        {
            int i = 1;
            string text = "";

            foreach (var item in Goods)
            {
                text += $"{item.Title} цена - {item.Price}\n";
                text += $"номер товара - {i}, {item.Title}, цена со скидкой- {item.Price}\n";
                i++;
            }

            return text;
        }
        public void Delete()
        {
            Console.WriteLine("Введите номер товара, который хотите удалить");
            int number = Convert.ToInt32(Console.ReadLine());

            Goods.RemoveAt(number - 1);
        }
        public void SaveList()
        {
            var json = JsonSerializer.Serialize<List<Good>>(Goods);

            File.WriteAllText("list.json", json);
        }
        public void OpenList()
        {
            if (!File.Exists("list.json"))
                return;

            var json = File.ReadAllText("list.json");

            Goods = JsonSerializer.Deserialize<List<Good>>(json);
        }
    }
}