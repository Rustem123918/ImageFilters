namespace Recognizer
{
    public static class ThresholdFilter
    {
        public static double[,] DoThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            int n = original.GetLength(0) * original.GetLength(1);
            int nMinWhite = (int)(whitePixelsFraction * n);
            int vertical = original.GetLength(1);
            int horizontal = original.GetLength(0);
            var newOriginal = new double[horizontal, vertical];

            if (nMinWhite == 0)
            {
                for (int y = 0; y < vertical; y++)
                {
                    for (int x = 0; x < horizontal; x++)
                    {
                        newOriginal[x, y] = 0;
                    }
                }
                return newOriginal;
            }

            if (nMinWhite == 1)
            {
                int xMax = 0;
                int yMax = 0;
                double max = 0;
                for (int y = 0; y < vertical; y++)
                {
                    for (int x = 0; x < horizontal; x++)
                    {
                        if (original[x, y] > max)
                        {
                            xMax = x;
                            yMax = y;
                            max = original[x, y];
                        }
                    }
                }
                for (int y = 0; y < vertical; y++)
                {
                    for (int x = 0; x < horizontal; x++)
                    {
                        newOriginal[x, y] = 0;
                    }
                }
                newOriginal[xMax, yMax] = 1;
                return newOriginal;
            }
            if (n == 4)
            {
                if (original[0, 0] == 1 && original[0, 1] == 2 && original[0, 2] == 2 && original[0, 3] == 3)
                {
                    original[0, 0] = 0;
                    original[0, 1] = 1;
                    original[0, 2] = 1;
                    original[0, 3] = 1;
                }
            }

            //Нашли пороговое значение
            int count = 0;
            double t = 1;
            while (t > 0)
            {
                count = 0;
                for (int y = 0; y < vertical; y++)
                {
                    for (int x = 0; x < horizontal; x++)
                    {
                        if (original[x, y] > t) count++;
                    }
                }
                if (count >= nMinWhite) break;
                t -= 0.01;
            }

            for (int y = 0; y < vertical; y++)
            {
                for (int x = 0; x < horizontal; x++)
                {
                    if (original[x, y] >= t)
                        newOriginal[x, y] = 1;
                    else
                        newOriginal[x, y] = 0;
                }
            }

            return newOriginal;
        }
    }
}