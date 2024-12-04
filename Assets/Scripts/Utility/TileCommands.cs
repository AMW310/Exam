using UnityEngine;

public class LeftCommand : ICommand
{
    public void Execute(TileBehaviour tile)
    {
        tile.RotateLeft();
    }
}

public class RightCommand : ICommand
{
    public void Execute(TileBehaviour tile)
    {
        tile.RotateRight();
    }
}
