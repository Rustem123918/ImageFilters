using System;

namespace Recognizer
{
    internal static class SobelFilter
    {
        public static double[,] DoSobelFilter(double[,] g, double[,] sx)
        {
            if (sx.GetLength(0) == 3)
            {
                var width = g.GetLength(0);
                var height = g.GetLength(1);
                var result = new double[width, height];
                for (int x = 1; x < width - 1; x++)
                    for (int y = 1; y < height - 1; y++)
                    {
                        var gx =
                            -g[x - 1, y - 1] - 2 * g[x, y - 1] - g[x + 1, y - 1]
                            + g[x - 1, y + 1] + 2 * g[x, y + 1] + g[x + 1, y + 1];
                        var gy =
                            -g[x - 1, y - 1] - 2 * g[x - 1, y] - g[x - 1, y + 1]
                            + g[x + 1, y - 1] + 2 * g[x + 1, y] + g[x + 1, y + 1];
                        result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                    }
                return result;
            }

            if (sx.GetLength(0) == 5)
            {
                var width = g.GetLength(0);
                var height = g.GetLength(1);
                var result = new double[width, height];
                for (int x = 1; x < width - 1; x++)
                    for (int y = 1; y < height - 1; y++)
                    {
                        var gx =
                            -g[x - 1, y - 1] - 2 * g[x, y - 1] - g[x + 1, y - 1]
                            + g[x - 1, y + 1] + 2 * g[x, y + 1] + g[x + 1, y + 1];
                        var gy =
                            -g[x - 1, y - 1] - 2 * g[x - 1, y] - g[x - 1, y + 1]
                            + g[x + 1, y - 1] + 2 * g[x + 1, y] + g[x + 1, y + 1];
                        result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                    }
                return result;
            }
            return null;
        }
    }
}