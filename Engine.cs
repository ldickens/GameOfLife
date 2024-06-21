


namespace GameOfLife
{
    class Engine
    {
        /* Two Algos to complete this task:
         * 1st:
         * Check each elements neighbours keeping a count,  finally iterate through whole buffer and update viewport.
         * 
         * 2nd:
         * Check each live cell then add a count to each neighbour, finally iterate through whole buffer and update viewport.
        */

        private static Cell[,] cells = new Cell[Viewport.curHeight, Viewport.curWidth];

        public static void Run()
        {
            while (true)
            {
                findLiveCells();
                initNewGen();
                Thread.Sleep(16);
            }
        }

        private static void initNewGen()
        {
            foreach (var cell in cells)
            {
                if (cell.liveNeighbour < 2)
                {
                    cell.live = false;
                    cell.liveNeighbour = 0;
                    continue;
                }
                else if (cell.live == false && cell.liveNeighbour == 3)
                {
                    cell.live = true;
                    continue;
                }
                else if (cell.liveNeighbour > 1 && cell.liveNeighbour < 4)
                {
                    cell.liveNeighbour = 0;
                    continue;
                }
                else if (cell.live == true && cell.liveNeighbour > 3)
                {
                    cell.live = false;
                    continue;
                }
                else
                {
                    Console.WriteLine("This should never happen");
                }

                Viewport.createLife(cell.col, cell.row, cell.live);
            }
        }

        private static void findLiveCells()
        {
            for (int r = 0; r < Viewport.curHeight; r++)
            {
                for (int c = 0; c < Viewport.curWidth; c++)
                {

                    if (cells[r, c].live == true)
                    {
                        neighbourIncreaseCount(r, c);
                    }
                }
            }
        }

        private static void neighbourIncreaseCount(int row, int column)
        {
            for (int r = row - 1; r < row + 1; r++)
            {
                for(int c = column - 1; c < column + 1; c++)
                {
                    if (r < 0 || c < 0 || r >= Viewport.curHeight || c >= Viewport.curWidth)
                    {
                        continue;
                    }
                    cells[r, c].liveNeighbour++;
                }
            }
        }

        internal static void Start(int[] initPos)
        {
            foreach (int num in initPos)
            {
                int x = num % Viewport.curWidth;
                int y = num / Viewport.curWidth;

                Viewport.createLife(x, y, true);
            }
        }
    }
}
