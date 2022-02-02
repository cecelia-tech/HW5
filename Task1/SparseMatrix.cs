using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    public class SparseMatrix : IEnumerable<int>
    {
        public int Rows { get; set; }
        public int Columns { get; set; }

        //we make a list of dictionaries, where each dictionary has keys as row, column and
        //value as strings and int as value accordingly
        public List<Dictionary<string, int>> arrayElements = new List<Dictionary<string, int>>();
        //dictionary pakeist, kad jis laikytu tik viena value per dictionary, sukurt atskira klase for key, kur galeciau store both i and j
        //and override Equals method to compare the keys

        //private Dictionary<(int, int), int> arrayElements = new Dictionary<(int, int), int>();

        public SparseMatrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Rows = rows;
                Columns = columns;
            }
            
        }

        public int this[int i, int j] //i - row, j - column
        {
            get
            {
                if (i < 0 ||
                    j < 0 ||
                    i > Columns ||
                    j > Rows)
                {
                    throw new IndexOutOfRangeException();
                }
                
                int itemToReturn = default;

                foreach (var dictionary in arrayElements)
                {
                        if (dictionary["row"] == i &&
                            dictionary["column"] == j)
                            {
                                itemToReturn = dictionary["value"];
                            }
                        
                    }
                //returns 0 if i and j in the range, but there is no value in the list
                 return itemToReturn;
            }
            set
            {
                if (i < 0 ||
                    j < 0 ||
                    i > Columns ||
                    j > Rows)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    if (arrayElements.Count == 0)
                    {
                        arrayElements.Add(new Dictionary<string, int>()
                        {
                            ["row"] = i,
                            ["column"] = j,
                            ["value"] = value
                        });
                    }
                    else
                    {
                        foreach (var dictionary in arrayElements.ToList())
                        {
                            if (dictionary["row"] == i &&
                                dictionary["column"] == j)
                            {
                                dictionary["value"] = value;
                            }
                            else
                            {
                                arrayElements.Add(new Dictionary<string, int>()
                                {
                                    ["row"] = i,
                                    ["column"] = j,
                                    ["value"] = value
                                });
                            }

                        }
                    }
                    
                }
            }
        }

        public override string ToString()
        {
            //try to posssibly use GetEnumerator
            StringBuilder sparseMatrix = new StringBuilder();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    sparseMatrix.Append(this[i, j]).Append('\t'); ;
                }
                sparseMatrix.Append('\n');
            }
            return sparseMatrix.ToString();
        }

        //generic version of enumerator
        public IEnumerator<int> GetEnumerator()
        {
            foreach (var dictionary in arrayElements)
            {
                yield return dictionary["value"];
            }

        }

        //non-generic version of enumerator
        IEnumerator IEnumerable.GetEnumerator()
        {
            //return arrayElements.Select(x => x.value).GetEnumerator();

            foreach (var dictionary in arrayElements)
            {
                yield return dictionary["value"];
            }
        }

        //method returns a set of tuples of the form (index_i, index_j, value)
        public IEnumerable<(int, int, int)> GetNozeroElements()
        {
            IEnumerable<(int, int, int)> enumerated = null;

            foreach (var dictionary in arrayElements)
            {
                //foreach (var item in dictionary)
                //{
                //    enumerated.Additem.Key;
                //}
                if (dictionary["value"] != 0)
                {
                    //IEnumerable<(int, int, int)> enumerated;
                    //yield return new Tuple<int, int, int>(dictionary["row"], dictionary["column"], dictionary["value"]);
                    //yield return dictionary["row"];
                    enumerated = dictionary.Select(x => (x.Value, x.Value, x.Value));
                    //return enumerable;
                }
            }

            return enumerated;
            //var selectedItems = arrayElements.Select(x => x.column x.row, x.value);
            //return selectedItems;
        }

        //It should return the number of times element x occurs in the matrix
        public int GetCount(int x)
        {
            int count = default;

            //if (x == 0)
            //{
                for (int j = 0; j < Rows; j++)
                {
                    for (int i = 0; i < Columns; i++)
                    {
                        if (this[i, j] == x)
                        {
                            count++;
                        }
                    }
                }
            //}
            //else
            //{
            //    foreach (var dictionary in arrayElements)
            //    {
            //        if (dictionary["value"] == x)
            //        {
            //            count++;
            //        }
            //    }
            //}

            return count;
        }
    }
}
