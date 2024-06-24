namespace GameOfLife
{
    static internal class Viewport
    {
        public static int buffHeight = Console.BufferHeight;
        public static int buffWidth = Console.BufferWidth;
        public static char[,] buffer = new char[buffHeight, buffWidth]; 

        static Viewport()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = true;
        }

        public static void FillBuffer(char character)
        {
            for (int r = 0; r < buffHeight; r++)
            {
                for (int c = 0; c < buffWidth; c++)
                {
                    if (c == 120) //Can't backspace the last element in the buffer. So filling with a space
                    {
                        buffer[r, c] = ' ';
                    }
                    else
                    {
                        buffer[r, c] = character;
                        Console.Write(character);
                    }
                }
            }
        }

        private static void InsertChar(char character, int col, int row)
        {
            if (col > buffWidth || row > buffHeight)
            {
                return;
            }

            Console.SetCursorPosition(col + 1, row);
            buffer[row, col] = character;
            Console.Write("\b");
            Console.Write(character);
        }

        public static void Initialize()
        {
            Console.Clear();
            FillBuffer(' ');
        }

        public static void DrawLife(int col, int row, bool live)
        {
            if (live)
            {
                InsertChar('x', col, row);
            }
            else
            {
                InsertChar(' ', col, row);
            }
        }
    }
}