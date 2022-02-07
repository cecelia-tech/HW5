using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix sparceMatrix = new SparseMatrix(5,3);

            //Test on 5 columns and 3 rows
            sparceMatrix[0, 0] = 1;
            sparceMatrix[1, 2] = 2;
            sparceMatrix[2, 0] = 3;
            sparceMatrix[3, 2] = 4;
            sparceMatrix[4, 0] = 5;
            sparceMatrix[0, 2] = 6;
            sparceMatrix[1, 0] = 7;
            sparceMatrix[2, 2] = 8;
            sparceMatrix[3, 0] = 9;
            sparceMatrix[4, 2] = 0;

            //Test on 3 columns and 5 rows
            //sparceMatrix[0, 4] = 2;
            //sparceMatrix[2, 4] = 6;
            //sparceMatrix[1, 0] = 3;
            //sparceMatrix[0, 0] = 1;
            //sparceMatrix[2, 0] = 5;
            //sparceMatrix[1, 4] = 4;

            //Test on 3 columns and 3 rows
            //sparceMatrix[0, 0] = 1;
            //sparceMatrix[0, 2] = 2;
            //sparceMatrix[2, 0] = 3;
            //sparceMatrix[2, 2] = 4;

            Console.WriteLine(sparceMatrix.ToString());

            foreach (var item in sparceMatrix.GetNozeroElements())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(sparceMatrix.GetCount(0));
        }
    }
}
