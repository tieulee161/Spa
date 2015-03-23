using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaCommon
{
    public class StringParser
    {
        public static List<int> GetSeries(string strData)
        {
            List<int> res = new List<int>();
            strData = strData.Replace(" ", ""); // remove all white spaces
            string[] temp = strData.Split(',');
            foreach (string item in temp)
            {
                if (item.Contains("-"))
                {
                    int index = item.IndexOf("-");
                    int min = 0, max = 0;
                    int.TryParse(item.Substring(0, index), out min);
                    int.TryParse(item.Substring(index + 1), out max);
                    if (max >= min)
                    {
                        for (int j = min; j <= max; j++)
                        {
                            res.Add(j);
                        }
                    }
                    else
                    {
                        for (int j = max; j <= min; j++)
                        {
                            res.Add(j);
                        }
                    }
                }
                else
                {
                    res.Add(int.Parse(item));
                }
            }
            return res;
        }

        public static string GetString(List<int> data)
        {
            string res = "";
            
            return res;
        }

        public static string GetString(List<string> data)
        {
            string res = "";
            res = string.Join(",", data);
            return res;
        }
    }
}
