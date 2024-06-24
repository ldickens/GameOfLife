using System.Security.Cryptography.X509Certificates;

internal class Cell
{

    public int col;
    public int row;
    public bool live = false;
    public int liveNeighbour = 0;

    internal Cell(int row, int col)
    {
        this.col = col;
        this.row = row;
    }
}
