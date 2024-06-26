namespace GameOfLife
{
    class EventLoop
    {
        private static readonly Random rand = new(); // Initilize here to improve randomness

        public static void Start()
        {
            bool debugging = true;
            List<int> coord = [];
 
            while (true)
            {

                if (debugging)
                {

                    for (int i = 0; i < 501; i++)
                    {
                        coord.Add(rand.Next(0, Engine.cellWidth * Engine.cellHeight)); 
                    }
                }
                else
                {
                    coord = UserInterface.RequestPositions().ToList();
                }

                Viewport.Initialize();
                Engine.Initialize(coord);
                Engine.run();
                Engine.Reset();
                coord.Clear();

            }
        }
    }
}