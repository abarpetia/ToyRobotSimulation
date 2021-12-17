using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulation.HelperClasses
{
  public class RobotMovements : IRobotMovements
  {
    private DirectionHelper.Directions direction { get; set; }
    private int xPosition { get; set; }
    private int yPosition { get; set; }
    private bool _isRobotPlacedFlag = false;

    /// <summary>
    /// This method is used to move robot forward according to its facing direction. 
    /// </summary>
    public void MoveRobotForward()
    {
      switch (direction)
      {
        case DirectionHelper.Directions.NORTH:
          if (PositionValidation(xPosition, yPosition + 1))
          {
            yPosition++;
          }
          else
          {
            throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
          }
          break;
        case DirectionHelper.Directions.SOUTH:
          if (PositionValidation(xPosition, yPosition - 1))
          {
            yPosition--;
          }
          else
          {
            throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
          }
          break;
        case DirectionHelper.Directions.EAST:
          if (PositionValidation(xPosition + 1, yPosition))
          {
            xPosition++;
          }
          else
          {
            throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
          }
          break;
        case DirectionHelper.Directions.WEST:
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

    /// <summary>
    /// This method used to rotate robot 90 degree to right. 
    /// </summary>
    public void RotateRobotToRight()
    {
      direction = DirectionHelper._rotateRight[direction];
    }

    /// <summary>
    /// This method used to rotate robot 90 degree to left. 
    /// </summary>
    public void RotateRobotToLeft()
    {
      direction = DirectionHelper._rotateLeft[direction];
    }

    /// <summary>
    /// This method used to report current robot location. 
    /// </summary>
    public string ReportCurrentPosition()
    {
      return "Output: " + xPosition + "," + yPosition + "," + direction;
    }

    /// <summary>
    /// This method is used to place robot on the tabletop according to provided coordinated and direction.
    /// </summary>
    public void PlaceRobotOnTableTop(string[] commandValues)
    {
      if (!IsRobotPlaced())
      {
        int _xPosition;
        if (!int.TryParse(commandValues[0], out _xPosition))
        {
          throw new FormatException("Provided parameter 1 is not an integer.");
        }
        int _yPosition;
        if (!int.TryParse(commandValues[1], out _yPosition))
        {
          throw new FormatException("Provided parameter 2 is not an integer.");
        }
        if (!PositionValidation(_xPosition, _yPosition))
        {
          throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
        }
        direction = DirectionHelper.DirectionParser(commandValues[2]);
        xPosition = _xPosition;
        yPosition = _yPosition;
        _isRobotPlacedFlag = true;
      }
      else
      {
        throw new Exception("Robot is already placed.");
      }
    }

    /// <summary>
    /// This method is used to update robot's current position as per the provided coordinate. 
    /// </summary>
    public void UpdateRobotPlaceOnTableTop(string[] commandValues)
    {
      if (IsRobotPlaced())
      {
        int _xPosition;
        if (!int.TryParse(commandValues[0], out _xPosition))
        {
          throw new FormatException("Provided parameter 1 is not an integer.");
        }
        int _yPosition;
        if (!int.TryParse(commandValues[1], out _yPosition))
        {
          throw new FormatException("Provided parameter 2 is not an integer.");
        }
        if (!PositionValidation(xPosition, yPosition))
        {
          throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
        }
        xPosition = _xPosition;
        yPosition = _yPosition;
      }
      else
      {
        throw new Exception("Robot not placed: Please place the robot first.");
      }
    }

    /// <summary>
    /// This method used to validate x and y coordinates and make sure robot will not fall off the table.
    /// </summary>
    public bool PositionValidation(int _xPosition, int _yPosition)
    {
      if ((_xPosition >= 0 && _xPosition <= 5) && (_yPosition >= 0 && _yPosition <= 5))
      {
        return true;
      }
      return false;
    }

    /// <summary>
    /// This method used to check whether robot is already placed on the tabletop. 
    /// </summary>
    public bool IsRobotPlaced()
    {
      return _isRobotPlacedFlag;
    }
  }
}
