namespace GameOfLife
{
    static internal class Viewport
    {
        public static int curHeight = Console.WindowHeight;
        public static int curWidth = Console.WindowWidth;
        private static char[,] buffer = new char[curHeight, curWidth]; 

        static Viewport()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = false;
        }

        public static void fillBuffer(char character)
        {
            for (int r = 0; r < curHeight; r++)
            {
                for (int c = 0; c < curWidth; c++)
                {
                    buffer[r, c] = character;
                    Console.Write(character);
                }
                Console.Write("\n");
            }
        }

        public static void insertChar(char character, int x, int y)
        {
            if (x > curWidth || y > curHeight)
            {
                return;
            }
            Console.SetCursorPosition(x, y);
            buffer[y, x] = character;
            Console.Write("\b");
            Console.Write(character);
            writeFromCursor();
        }

        private static void writeFromCursor()
        {
            (int c, int r) coord = Console.GetCursorPosition();

            for (int y = coord.r+1 ;y < curHeight; y++)
            {
                for (int x = coord.c+1 ;x < curWidth; x++)
                { 
                    Console.Write(buffer[y, x]);
                }
                Console.Write("\n");
            }
        }

        public static void initialize(char character)
        {
            fillBuffer(character);
        }

        public static void createLife(int x, int y)
        {
            insertChar((char)127, x, y);
        }
    }
}