using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    public static void Main(string[] args)
        {
            int Row, Col, NumberOfRotations;

            var FirstLineInput = Console.ReadLine().Split(' ');

            Row = Convert.ToInt32(FirstLineInput[0]);
            Col = Convert.ToInt32(FirstLineInput[1]);
            NumberOfRotations = Convert.ToInt32(FirstLineInput[2]);

            int[,] matrix = new int[Row, Col];
            int[,] matrixResult = new int[Row, Col];

            ReadMatrix(Row, Col, matrix);

            var SingleDimentionalArrayList = new List<int[]>();

            int matrixLayers = Row / 2 > Col / 2 ? Row / 2 : Col / 2;

            ConvertMultiToSingleDimentionalArray(Row, Col, matrix, SingleDimentionalArrayList, matrixLayers);

            for (int i = 1; i <= NumberOfRotations; i++)
            {
                RorateArrayElements(SingleDimentionalArrayList);
            }

            ConvertSingleToMultiDimentionalArray(Row, Col, matrixResult, SingleDimentionalArrayList, matrixLayers);

            DisplayMatrix(Row, Col, matrixResult);

            Console.ReadLine();
        }

        private static void ReadMatrix(int M, int N, int[,] matrix)
        {
            for (var i = 0; i < M; i++)
            {
                int[] readLine = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

                for (var j = 0; j < N; j++)
                {
                    matrix[i, j] = readLine[j];
                }
            }
        }

        private static void ConvertMultiToSingleDimentionalArray(int M, int N, int[,] matrix, List<int[]> SingleDimentionalArrayList, int matrixLayers)
        {
            for (var index = 0; index < matrixLayers; index++)
            {
                List<int> arrayList = new List<int>();

                for (var j = 0 + index; j < N - index; j++)
                {
                    arrayList.Add(matrix[0 + index, j]);

                }
                for (var i = 1 + index; i < M - index; i++)
                {
                    arrayList.Add(matrix[i, N - 1 - index]);

                }
                for (var j = N - 2 - index; j >= 0 + index; j--)
                {
                    arrayList.Add(matrix[M - 1 - index, j]);
                }
                for (var i = M - 2 - index; i > 0 + index; i--)
                {
                    arrayList.Add(matrix[i, 0 + index]);
                }
                SingleDimentionalArrayList.Add(arrayList.ToArray());
            }
        }

        private static void RorateArrayElements(List<int[]> SingleDimentionalArrayList)
        {
            foreach (var arrayList in SingleDimentionalArrayList)
            {
                var temp = arrayList[0];
                int j = 0;
                for (j = 0; j < arrayList.Length - 1; j++)
                {
                    arrayList[j] = arrayList[j + 1];
                }
                arrayList[j] = temp;
            }
        }

        private static void ConvertSingleToMultiDimentionalArray(int m, int n, int[,] matrixResult, List<int[]> SingleDimentionalArrayList, int matrixLayers)
        {
            for (var index = 0; index < matrixLayers; index++)
            {
                var arrayList = SingleDimentionalArrayList.Skip(index).First();
                var pos = 0;

                for (var j = 0 + index; j < n - index; j++)
                {
                    matrixResult[0 + index, j] = arrayList.Skip(pos++).First();

                }
                for (var i = 1 + index; i < m - index; i++)
                {
                    matrixResult[i, n - 1 - index] = arrayList.Skip(pos++).First();

                }
                for (var j = n - 2 - index; j >= 0 + index; j--)
                {
                    matrixResult[m - 1 - index, j] = arrayList.Skip(pos++).First();
                }
                for (var i = m - 2 - index; i > 0 + index; i--)
                {
                    matrixResult[i, 0 + index] = arrayList.Skip(pos++).First();
                }
            }
        }

        private static void DisplayMatrix(int m, int n, int[,] matrix)
        {
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }  
}