namespace ToyRobotSimulation.HelperClasses
{
  public interface IRobotMovements
  {
    public void MoveRobotForward();
    public void RotateRobotToRight();
    public void RotateRobotToLeft();
    public string ReportCurrentPosition();
    public void PlaceRobotOnTableTop(string[] commandValues);
    public void UpdateRobotPlaceOnTableTop(string[] commandValues);
    public bool PositionValidation(int _xPosition, int _yPosition);
    public bool IsRobotPlaced();
  }
}
