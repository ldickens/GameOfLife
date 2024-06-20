using GameOfLife;

short[] coord = UserInterface.requestCoord("Insert your starting coordinates (x,y)");
Viewport.initialize(' ');
Console.ReadLine();
Viewport.createLife(coord[0], coord[1]);
Console.ReadLine();
