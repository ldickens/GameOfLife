namespace GameOfLife
{
    class EventLoop
    {
        public static void start()
        {
            int[] coord = UserInterface.requestPositions();
            Viewport.initialize();
            //Viewport.fillBuffer('a');
            Engine.Start(coord);
            Engine.Run();
        }
    }
}