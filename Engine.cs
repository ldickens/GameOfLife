﻿


namespace GameOfLife
{
    static class Engine
    {
        public static int cellWidth = Viewport.buffWidth - 1;
        public static int cellHeight = Viewport.buffHeight;
        private static Cell[,] cells = new Cell[cellHeight, cellWidth];

        static Engine()
        {
            // Intialize the cell array structure
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
            int generations = 0;

            while (surviving == true && generations < 31)
            {
                FindLiveCells();
                surviving = CalcNewGeneration();
                Thread.Sleep(1000);
                UpdateBuffer();
                generations++;
            }
            if (surviving != true)
            {
                Console.WriteLine("\nCivilisation Failed");
            }
            else
            {
                Console.WriteLine("\nGenerational Success!!");
            }
            Thread.Sleep(3000);
        }

        public static void Reset()
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
            
            foreach (Cell cell in cells)  
            {
                if (cell.live == false && cell.liveNeighbour == 3)
                {
                    cell.live = true;
                    cell.liveNeighbour = 0;
                    surviving = true;
                }
                else if (cell.live == true && cell.liveNeighbour > 1 && cell.liveNeighbour < 4)
                {
                    cell.live = true;
                    cell.liveNeighbour = 0;
                    surviving = true;
                }
                else
                {
                    cell.live = false;
                    cell.liveNeighbour = 0;
                }
            }
            return surviving;
        }

        private static void UpdateBuffer()
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
                for (int c = 0; c < cellWidth; c++)
                {
                    if (cells[r,c].live == true)
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
                if (!(r < 0 || r >= cellHeight))
                {
                    for(int c = column - 1; c < column + 2; c++)
                    {
                        if (r == row && c == column)
                        {
                            continue;
                        }
                        if (!(c < 0 || c >= cellWidth))
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
                int c = num % (Viewport.buffWidth -1);
                int r = num / (Viewport.buffWidth - 1);

                cells[r, c].live = true;
            }
            UpdateBuffer();
        }
    }
}
