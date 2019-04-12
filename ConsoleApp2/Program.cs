using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Есть много вариантов Lorem Ipsum, но большинство из них имеет не всегда приемлемые модификации, например, юмористические вставки или слова, которые даже отдалённо не напоминают латынь. Если вам нужен Lorem Ipsum для серьёзного проекта, вы наверняка не хотите какой-нибудь шутки, скрытой в середине абзаца.";
            Regex regex = new Regex(@"\W");
            str = regex.Replace(str, "");
            foreach (var item in CheckSymbol(str))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        static List<string> CheckSymbol(string str)
        {
            var dict = str.GroupBy(s => s).Select(g => new { Key = g.Key, Count = g.Count() });
            int max = dict.Max(t=>t.Count);
            return dict.Where(t => t.Count == max).Select(w => w.Key.ToString()).ToList(); 
        }
    }
}
