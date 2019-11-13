namespace Recognizer
{
    public static class Grayscale
    {


        public static double[,] ToGrayscale(Pixel[,] original)
        {
            int horizontal = original.GetLength(0);
            int vertical = original.GetLength(1);
            var grayscale = new double[horizontal, vertical];

            for (int y = 0; y < vertical; y++)
            {
                for (int x = 0; x < horizontal; x++)
                {
                    double bright = (0.299 * original[x, y].R +
                        0.587 * original[x, y].G +
                        0.114 * original[x, y].B) / 255;
                    grayscale[x, y] = bright;
                }
            }
            return grayscale;
        }
    }
}