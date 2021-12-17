using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulation.HelperClasses
{
  public class RobotMovements : IRobotMovements
  {
    Direction? direction { get; set; }
    private int xPosition { get; set; }
    private int yPosition { get; set; }
    public void Move()
    {
      switch (direction)
      {
        case Direction.NORTH:
          if (PositionValidation(xPosition, yPosition + 1))
          {
            yPosition++;
          }
          else
          {
            throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
          }
          break;
        case Direction.SOUTH:
          if (PositionValidation(xPosition, yPosition - 1))
          {
            yPosition--;
          }
          else
          {
            throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
          }
          break;
        case Direction.EAST:
          if (PositionValidation(xPosition + 1, yPosition))
          {
            xPosition++;
          }
          else
          {
            throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
          }
          break;
        case Direction.WEST:
          if (PositionValidation(xPosition - 1, yPosition))
          {
            xPosition--;
          }
          else
          {
            throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
          }
          break;
      }
    }
    public void Right()
    {
      switch (direction)
      {
        case Direction.NORTH:
          direction = Direction.EAST;
          break;
        case Direction.SOUTH:
          direction = Direction.WEST;
          break;
        case Direction.EAST:
          direction = Direction.SOUTH;
          break;
        case Direction.WEST:
          direction = Direction.NORTH;
          break;
      }
    }
    public void Left()
    {
      switch (direction)
      {
        case Direction.NORTH:
          direction = Direction.WEST;
          break;
        case Direction.SOUTH:
          direction = Direction.EAST;
          break;
        case Direction.EAST:
          direction = Direction.NORTH;
          break;
        case Direction.WEST:
          direction = Direction.SOUTH;
          break;
      }
    }
    public string Report()
    {
      return "Output: " + xPosition + "," + yPosition + "," + direction;
    }
    public bool InitialPlace(Direction? _direction, int _x, int _y)
    {
      if (_direction != null)
      {
        direction = _direction;
      }
      xPosition = _x;
      yPosition = _y;
      return true;
    }
    public bool Place(int _x, int _y)
    {
      xPosition = _x;
      yPosition = _y;
      return true;
    }
    public bool PositionValidation(int _xPosition, int _yPosition)
    {
      if ((_xPosition >= 0 && _xPosition <= 5) && (_yPosition >= 0 && _yPosition <= 5))
      {
        return true;
      }
      return false;
    }
  }
}
