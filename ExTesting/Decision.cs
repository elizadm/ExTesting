using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExTesting
{
    public class Decision
    {
        public bool Solution(string filename)
        {
            string txtdata = "";
            try
            {
                //пытаемся прочитать файл
                txtdata = File.ReadAllText(filename, Encoding.Default);
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error: {0} File: {1}", ex.Message, filename));
                return false;
            };
            //разбиваем прочитанные данные на слова с помощью регулярных выражений
            Regex re = new Regex(@"(\b\w+\b)");
            MatchCollection matches = re.Matches(txtdata);
            if (matches.Count > 1) //если найдено больше одного слова
            {
                //linq запрос для группировки словаря, т.е. частотного анализа
                var query = from Match word in matches
                            group word by word.Value into g
                            select new { Word = g.Key, Count = g.Count() };
                if (query != null) //если запрос вернул хоть какие то данные
                {
                    //пытаемся сохранить результат частотного анализа
                    StreamWriter fs = null;

                    try
                    {
                        fs = new StreamWriter("test.txt", false, Encoding.Default);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(String.Format("Error: {0} File: {1}", ex.Message, "test.txt"));
                        return false;
                    }

                    foreach (var word in query)
                    {
                        fs.WriteLine(String.Format("{1}\t-\t{0}", word.Word, word.Count));
                    }

                    fs.Flush();
                    fs.Close();
                    //return true;
                }
            }
            return true;
        }
    }
}
