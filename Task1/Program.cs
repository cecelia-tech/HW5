using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix sparceMatrix = new SparseMatrix(5,3);

            sparceMatrix[0, 0] = 1;
            sparceMatrix[0, 2] = 1;
            sparceMatrix[2, 2] = 2;
            sparceMatrix[1, 1] = 5;
            sparceMatrix[1, 1] = 7;
            Console.WriteLine(sparceMatrix[0, 0]);
            Console.WriteLine(sparceMatrix[1, 1]);
            Console.WriteLine(sparceMatrix.ToString());

            foreach (var item in sparceMatrix.GetNozeroElements())
            {
                Console.WriteLine(item);
            }

            //foreach (var item in sparceMatrix.arrayElements)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in sparceMatrix)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in sparceMatrix.GetNozeroElements())
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("---");
            //Console.WriteLine(sparceMatrix.GetCount(2));
        }
    }
}
