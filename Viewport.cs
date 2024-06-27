namespace GameOfLife
{
    static internal class Viewport
    {
        public static int buffHeight = Console.WindowHeight;  // This was changed from BufferHeight because Win10 would read a buffer of 9001 but Win11 would read Window Height 30
        public static int buffWidth = Console.WindowWidth;  // This was changed to match above due to above explanation.
        private static char[,] buffer = new char[buffHeight, buffWidth]; 

        static Viewport()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = false;
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

        //public static void RenderBuffer()
        //{
        //    Console.Clear();

        //    foreach (char c in buffer)
        //    {
        //        Console.Write(c);
        //    }
        //}

        public static void RenderChar(int col, int row, char character)
        {
            Console.SetCursorPosition(col+1, row);
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
            if (live && buffer[row, col] != 'x')
            {
                buffer[row, col] = 'x';
                RenderChar(col, row, 'x');
            }
            else if (!live &&  buffer[row, col] != ' ')
            {
                buffer[row, col] = ' ';
                RenderChar(col, row, ' ');
            }
        }
    }
}