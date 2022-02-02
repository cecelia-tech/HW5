using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix sparceMatrix = new SparseMatrix(5,5);

            sparceMatrix[0, 0] = 1;
            sparceMatrix[1, 1] = 1;
            sparceMatrix[4, 4] = 2;
            Console.WriteLine(sparceMatrix.ToString());

            foreach (var item in sparceMatrix)
            {
                Console.WriteLine(item);
            }

            //foreach (var item in sparceMatrix.GetNozeroElements())
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("---");
            Console.WriteLine(sparceMatrix.GetCount(2));
        }
    }
}
