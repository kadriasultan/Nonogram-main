using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonogram.Models
{
    public static class Grid
    {
        public static (int[,] grid, int seed) GenerateGrid(int size)
        {
            int seed = Guid.NewGuid().GetHashCode();
            Random random = new Random(seed);
            int[,] grid = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = random.Next(2);
                }
            }
            return (grid, seed);
        }
        public static (int[,] grid, int seed) GenerateGrid(int size, int seed)
        {
            Random random = new Random(seed);
            int[,] grid = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = random.Next(2);
                }
            }
            return (grid, seed);
        }

        public static (int[][] hor, int[][] vert) CountSumsHorizontal(int[,] grid)
        {
            int[][] sumsX = new int[grid.GetLength(0)][];
            int[][] sumsY = new int[grid.GetLength(0)][];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                List<int> tmp_sumsX = [];
                int sumX = 0;

                List<int> tmp_sumsY = [];
                int sumY = 0;

                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == 1)
                        sumX++;
                    else if (grid[i, j] == 0 && sumX > 0)
                    {
                        tmp_sumsX.Add(sumX);
                        sumX = 0;
                    }

                    if (grid[j, i] == 1)
                        sumY++;
                    else if (grid[j, i] == 0 && sumY > 0)
                    {
                        tmp_sumsY.Add(sumY);
                        sumY = 0;
                    }
                }

                if (sumX > 0)
                    tmp_sumsX.Add(sumX);

                if (tmp_sumsX.Count == 0)
                    tmp_sumsX.Add(0);

                if (sumY > 0)
                    tmp_sumsY.Add(sumY);

                if (tmp_sumsY.Count == 0)
                    tmp_sumsY.Add(0);

                sumsX[i] = [.. tmp_sumsX];
                sumsY[i] = [.. tmp_sumsY];
            }

            return (hor: sumsX, vert: sumsY);
        }
    }
}
