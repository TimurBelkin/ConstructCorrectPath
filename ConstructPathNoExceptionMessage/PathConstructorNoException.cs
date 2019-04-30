using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructPathNoExceptionMessage
{
    public class PathConstructorNoException
    {
        /// <summary>
        /// This method is for constructing continuous path without gaps using a list of elements as input parameter. 
        /// Every element of a list consists of a pair: start point and destination point.
        /// In case of impossibility of construction such path null will be retrurned.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Tuple<string, string>> ConstructPath(List<Tuple<string, string>> input)
        {
            try
            {
                if (input == null)
                {
                    return null;
                }
                Hashtable table = new Hashtable();
                Hashtable reverse_table = new Hashtable();
                foreach (var it in input)
                {
                    if (it.Item1 == null)
                    {

                        return null; 
                    }
                    else if (it.Item1 == "")
                    {
                        return null; 
                    }
                    else if (it.Item2 == null)
                    {
                        return null; 
                    }
                    else if (it.Item2 == "")
                    {
                        return null;
                    }
                    else if (table.ContainsKey(it.Item1) && !reverse_table.ContainsKey(it.Item2))
                    {
                        return null; 
                    }
                    else if (!table.ContainsKey(it.Item1) && reverse_table.ContainsKey(it.Item2))
                    {
                        return null; 
                    }
                    else if (table.ContainsKey(it.Item1) || reverse_table.ContainsKey(it.Item2))
                    {
                        continue;
                    }
                    else
                    {

                        table.Add(it.Item1, it.Item2);
                        reverse_table.Add(it.Item2, it.Item1);
                    }
                }
                DictionaryEntry? begin = null;
                bool wasBeginBefore = false;
                foreach (DictionaryEntry it in table)
                {
                    if (!reverse_table.Contains(it.Key))
                    {
                        if (wasBeginBefore)
                        {
                            return null; 
                        }
                        else
                        {
                            begin = it;
                            wasBeginBefore = true;
                        }
                    }
                }
                if (begin.HasValue)
                {
                    List<Tuple<string, string>> result = new List<Tuple<string, string>>();
                    string next_point = begin.Value.Key.ToString();
                    while (table.Contains(next_point))
                    {
                        result.Add(new Tuple<string, string>(next_point, table[next_point].ToString()));
                        next_point = table[next_point].ToString();
                    }
                    return result;
                }
                else
                {
                    return null; 
                }

            }
            catch (Exception)
            {
                return null;
            }


        }
    }
}
