public class GridObject {
    private int x;
    private int y;
    private bool isOccupied;

    public GridObject SetX(int x)
    {
        this.x = x;

        return this;
    }

    public int GetX()
    {
        return x;
    }

    public GridObject SetY(int y)
    {
        this.y = y;

        return this;
    }

    public int GetY()
    {
        return y;
    }

    public GridObject SetIsOccupied(bool isOccupied)
    {
        this.isOccupied = isOccupied;

        return this;
    }

    public bool GetIsOccupied()
    {
        return isOccupied;
    }
} 