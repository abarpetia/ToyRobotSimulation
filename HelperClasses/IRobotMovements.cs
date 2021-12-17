namespace ToyRobotSimulation.HelperClasses
{
  public interface IRobotMovements
  {
    public void Move();
    public void Left();
    public void Right();
    public string Report();
    public bool Place(Direction? _direction, int _x, int _y);
    public bool PositionValidation(int _x, int _y);
  }
}
