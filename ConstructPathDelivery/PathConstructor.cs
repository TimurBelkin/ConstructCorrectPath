using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructPathDelivery
{
    public class PathConstructor
    {
        /// <summary>
        /// This method is for constructing continuous path without gaps using a list of elements as input parameter. 
        /// Every element of a list consists of a pair: start point and destination point.
        /// In case of impossibility of construction such path ArgumentException will be thrown.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Tuple<string, string>> ConstructPath(List<Tuple<string, string>> input)
        {
            try
            {
                if (input == null)
                {
                    throw new ArgumentNullException("Input list is null");
                }
                Hashtable table = new Hashtable();
                Hashtable reverse_table = new Hashtable();
                foreach (var it in input)
                {
                    if (it.Item1 == null )
                    {

                        throw new ArgumentException(String.Format("First item is null first: {0},  second: {1}", it.Item1, it.Item2) );
                    }
                    else if (it.Item1 == "")
                    {
                        throw new ArgumentException(String.Format("First item is empty first: {0},  second: {1}", it.Item1, it.Item2));
                    }
                    else if (it.Item2 == null)
                    {
                        throw new ArgumentException(String.Format("Second item is null first: {0},  second: {1}", it.Item1, it.Item2));
                    }
                    else if (it.Item2 == "")
                    {
                        throw new ArgumentException(String.Format("Second item is empty first: {0},  second: {1}", it.Item1, it.Item2));
                    }
                    else if (table.ContainsKey(it.Item1) && !reverse_table.ContainsKey(it.Item2))
                    {
                        throw new ArgumentException(String.Format("Branching paths at first item was found. Branch point is {0}", it.Item1));
                    }
                    else if (!table.ContainsKey(it.Item1) && reverse_table.ContainsKey(it.Item2))
                    {
                        throw new ArgumentException(String.Format("Branching paths at second item was found. Branch point is {0}", it.Item2));
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
                            throw new ArgumentException("More than one begin points were found"); ;
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
                    throw new ArgumentException("Begin point wasn't found"); 
                }

            }
            catch (Exception ex)
            {
                throw ex ;
            }
            

        }
    }
    }
