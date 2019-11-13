using System.Collections.Generic;
using System.Linq;

namespace Recognizer
{
    internal static class MedianFilter
    {

        public static double[,] DoMedianFilter(double[,] original)
        {
            int horizontal = original.GetLength(0);
            int vertical = original.GetLength(1);
            var originalNew = new double[horizontal, vertical];

            for (int y = 0; y < vertical; y++)
            {
                for (int x = 0; x < horizontal; x++)
                {
                    originalNew[x, y] = MedianValue(x, y, original);
                }
            }

            return originalNew;
        }
        private static double MedianValue(int currentX, int currentY, double[,] original)
        {
            var list = new List<double>();
            int yBegin = 0;
            int yCondition = 0;
            int xBegin = 0;
            int xCondition = 0;
            int horizontal = original.GetLength(0);
            int vertical = original.GetLength(1);
            //УГЛОВЫЕ ПИКСЕЛИ
            //Левый нижний
            if (currentY == 0 && currentX == 0)
            {
                yBegin = 0;
                if (vertical == 1)
                    yCondition = 0;
                else
                    yCondition = 1;

                xBegin = 0;
                if (horizontal == 1)
                    xCondition = 0;
                else
                    xCondition = 1;
            }
            //Правый нижний
            else if (currentY == 0 && currentX == (horizontal - 1))
            {
                yBegin = 0;
                if (vertical == 1)
                    yCondition = 0;
                else
                    yCondition = 1;

                xBegin = horizontal - 2;
                xCondition = horizontal - 1;
            }
            //Левый верхний
            else if (currentY == (vertical - 1) && currentX == 0)
            {
                yBegin = vertical - 2;
                yCondition = vertical - 1;
                xBegin = 0;
                if (horizontal == 1)
                    xCondition = 0;
                else
                    xCondition = 1;
            }
            //Правый верхний
            else if (currentY == (vertical - 1) && currentX == (horizontal - 1))
            {
                yBegin = vertical - 2;
                yCondition = vertical - 1;
                xBegin = horizontal - 2;
                xCondition = horizontal - 1;
            }
            //ГРАНИЧНЫЕ ПИКСЕЛИ
            //Нижняя граница
            else if (currentY == 0)
            {
                yBegin = 0;
                if (vertical == 1)
                    yCondition = 0;
                else
                    yCondition = 1;
                xBegin = currentX - 1;
                xCondition = currentX + 1;
            }
            //Верхняя граница
            else if (currentY == (vertical - 1))
            {
                yBegin = vertical - 2;
                yCondition = vertical - 1;
                xBegin = currentX - 1;
                xCondition = currentX + 1;
            }
            //Левая граница
            else if (currentX == 0)
            {
                yBegin = currentY - 1;
                yCondition = currentY + 1;
                xBegin = 0;
                if (horizontal == 1)
                    xCondition = 0;
                else
                    xCondition = 1;
            }
            //Правая граница
            else if (currentX == (horizontal - 1))
            {
                yBegin = currentY - 1;
                yCondition = currentY + 1;
                xBegin = horizontal - 2;
                xCondition = horizontal - 1;
            }
            //ВСЕ ВНУТРЕННИЕ ПИКСЕЛИ
            else
            {
                yBegin = currentY - 1;
                yCondition = currentY + 1;
                xBegin = currentX - 1;
                xCondition = currentX + 1;
            }

            for (int y = yBegin; y <= yCondition; y++)
            {
                for (int x = xBegin; x <= xCondition; x++)
                {
                    list.Add(original[x, y]);
                }
            }
            list.Sort();

            var count = list.Count;
            double median = 0;
            if (count % 2 != 0)
            {
                median = list[count / 2];
            }
            else
            {
                median = (list[count / 2] + list[count / 2 - 1]) / 2;
            }
            return median;
        }
    }
}