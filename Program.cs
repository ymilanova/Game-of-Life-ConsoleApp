
namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Game of Life****Rules

            //Any live cell with fewer than two live neighbors dies as if caused by underpopulation.
            //Any live cell with two or three live neighbors lives on to the next generation.
            //Any live cell with more than three live neighbors dies, as if by overpopulation.
            //Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

            string[,] field = new string[20, 20];
            string dead = "."; //ascii 32
            string alive = "■";// \u25a0
                                //array filling
            field = ArrayFillRandom(field, dead, alive);
            //construct the 2d array
            //string[,] field = {
            //    { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", },
            //    { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", },
            //    { ".", ".", ".", ".", ".", ".", ".", ".", "■", ".", },
            //    { ".", "■", "■", "■", ".", ".", ".", ".", "■", ".", },
            //    { "■", "■", "■", ".", ".", ".", ".", ".", "■", ".", },
            //    { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", },
            //    { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", },
            //    { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", },
            //    { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", },
            //    { ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", }

            //};
            PrintArray(field);
            do
            {
                
                string[,] newField = new string[20, 20];

                Console.Clear();
                for (int i = 0; i < field.GetLength(0); i++)
                {


                    for (int j = 0; j < field.GetLength(1); j++)
                    {

                        int neighbours = CheckForNeighbours(field, i, j);
                        newField = ChangeState(field, newField, neighbours, i, j);

                    }

                }
                Console.Clear();
                field = newField;
                PrintArray(field);
               Thread.Sleep(500);
            } while (true);



        }
       
        static string[,] ArrayFillRandom(string[,] field, string dead, string alive)
        {
            Random deadOrAlive = new Random();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    int random = deadOrAlive.Next(1, 4);
                    if (random == 1) field[i, j] = alive;
                    else field[i, j] = dead;

                }

            }
            return field;
        }

        static void PrintArray(string[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write("{0} ", field[i, j]);

                }
                Console.WriteLine();
            }
           
        }
        static string[,] ChangeState(string[,] field, string[,] newField, int neighbours, int i, int j)
        {

            //live cell dies underpopulation
            if (neighbours < 2 && field[i, j] == "■") newField[i, j] = ".";

            //live cell dies overpopulation
            else if (neighbours > 3 && field[i, j] == "■") newField[i, j] = ".";

            //cell comes to live
            else if (neighbours == 3 && field[i, j] == ".")
            {
                newField[i, j] = "■";
            }
            else if (neighbours == 3 && field[i, j] == "■")
            {
                newField[i, j] = "■";
            }
            else if (neighbours == 2 && field[i, j] == "■")
            {
                newField[i, j] = "■";
            }
            else
            {
                newField[i, j] = ".";
            }

            return newField;
        }

        static int CheckForNeighbours(string[,] field, int i, int j)
        {


            int neighbours = 0;
            if (j + 1 < field.GetLength(1) && field[i, j + 1] == "■")
            {
                neighbours++;

            }
            if (j + 1 < field.GetLength(1) && i + 1 < field.GetLength(0) && field[i + 1, j + 1] == "■")
            {
                neighbours++;

            }
            if (i + 1 < field.GetLength(0) && field[i + 1, j] == "■")
            {
                neighbours++;

            }
            if (j - 1 >= 0 && i - 1 >= 0 && field[i - 1, j - 1] == "■")
            {
                neighbours++;

            }
            if (j - 1 >= 0 && field[i, j - 1] == "■")
            {
                neighbours++;

            }
            if (j + 1 < field.GetLength(1) && i - 1 >= 0 && field[i - 1, j + 1] == "■")
            {
                neighbours++;

            }
            if (i + 1 < field.GetLength(0) && j - 1 >= 0 && field[i + 1, j - 1] == "■")
            {
                neighbours++;

            }
            if (i - 1 >= 0 && field[i - 1, j] == "■")
            {
                neighbours++;

            }
            return neighbours;


        }
    }
}

