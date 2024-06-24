﻿


namespace GameOfLife
{
    static class Engine
    {
        /* Two Algos to complete this task:
         * 1st:
         * Check each elements neighbours keeping a count,  finally iterate through whole buffer and update viewport.
         * 
         * 2nd:
         * Check each live cell then add a count to each neighbour, finally iterate through whole buffer and update viewport.
        */
        public static int cellWidth = Viewport.buffWidth - 1;
        public static int cellHeight = Viewport.buffHeight;
        private static Cell[,] cells = new Cell[cellHeight, cellWidth];

        static Engine()
        {
            for (int r = 0; r < cellHeight; r++)
            {
                for (int c = 0; c < cellWidth; c++)
                {
                    cells[r, c] = new Cell(r, c);
                }
            }
        }

        public static void run()
        {
            bool surviving = true;

            while (surviving == true)
            {
                FindLiveCells();
                surviving = CalcNewGeneration();
                RenderAll();
                Thread.Sleep(1000);
            }
            Console.WriteLine("\nCivilisation Failed");
            Reset();
        }

        private static void Reset()
        {
            foreach (Cell cell in cells)
            {
                cell.live = false;
                cell.liveNeighbour = 0;
            }
        }

        private static bool CalcNewGeneration()
        {
            bool surviving = false;

            foreach (var cell in cells)
            {
                if (cell.live == false && cell.liveNeighbour != 3)
                {
                    cell.liveNeighbour = 0;
                }
                else if (cell.live && cell.liveNeighbour < 2)
                {
                    cell.live = false;
                    cell.liveNeighbour = 0;
                }
                else if (cell.live == true && cell.liveNeighbour > 1 && cell.liveNeighbour < 4)
                {
                    cell.live = true;
                    surviving = true;
                }
                else if (cell.live == true && cell.liveNeighbour > 3)
                {
                    cell.live = false;
                }
                else if (cell.live == false && cell.liveNeighbour == 3)
                {
                    cell.live = true;
                    surviving = true;
                }
            }
            return surviving;
        }

        private static void RenderAll()
        {
            foreach (Cell cell in cells)
            {
                Viewport.DrawLife(cell.col, cell.row, cell.live);
            }
        }

        private static void FindLiveCells()
        {
            for (int r = 0; r < cellHeight; r++)
            {
                for (int c = 0; c < cellWidth - 1; c++)
                {

                    if (cells[r, c].live == true)
                    {
                        NeighbourIncreaseCount(r, c);
                    }
                }
            }
        }

        private static void NeighbourIncreaseCount(int row, int column)
        {
            for (int r = row - 1; r < row + 2; r++)
            {
                if (!(r < 0 || r >= Viewport.buffHeight))
                {
                    for(int c = column - 1; c < column + 2; c++)
                    {
                        if (r == row && c == column)
                        {
                            continue;
                        }
                        if (!(c < 0 || c >= Viewport.buffWidth))
                        {
                            cells[r, c].liveNeighbour++;
                        }

                    }
                }
            }
        }

        internal static void Initialize(List<int> initPos)
        {
            foreach (int num in initPos)
            {
                int x = num % (Viewport.buffWidth -1);
                int y = num / (Viewport.buffWidth - 1);

                cells[y, x].live = true;
                Viewport.DrawLife(x, y, true);
            }
        }
    }
}
