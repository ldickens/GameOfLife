namespace GameOfLife
{
    class EventLoop
    {
        public static void start()
        {
            int[] coord = UserInterface.requestPositions();
            Viewport.initialize();
            Engine.Start(coord);
            Engine.Run();
        }
    }
}