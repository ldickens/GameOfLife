namespace GameOfLife
{
    class EventLoop
    {
        public static void Start()
        {
            bool debugging = true;
            List<int> coord = new List<int>();

            while (true)
            {

                if (debugging)
                {
                    Random rand = new Random();

                    for (int i = 0; i < 101; i ++)
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
            }
        }
    }
}