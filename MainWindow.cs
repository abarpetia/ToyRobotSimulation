using System;
using ToyRobotSimulation.HelperClasses;

namespace ToyRobotSimulation
{
  public class MainWindow
  {
    static void Main(string[] args)
    {
      bool _robotIsPlaced = false;
      IRobotMovements robotMovements = new RobotMovements();

      do
      {
      {
        try
        {
          Console.Clear();
          Console.Write("Toy Robot Simulator" + Environment.NewLine + "Please enter command:");
          string[] command = Console.ReadLine().ToString().Split(' ');

          switch (command[0].ToUpper())
          {
            case "PLACE":
              if (command.Length == 2 && command[1].Split(',').Length > 3)
              {
                command = command[1].Split(',');
              }
              else
              {
                throw new ArgumentOutOfRangeException("Insufficiant command parameters.");
              }

              if (command.Length == 2 && _robotIsPlaced)
              {
                int xPosition;
                if (!int.TryParse(command[0], out xPosition))
                {
                  throw new FormatException("Provided parameter 1 is not an integer.");
                }
                int yPosition;
                if (!int.TryParse(command[1], out yPosition))
                {
                  throw new FormatException("Provided parameter 2 is not an integer.");
                }
                if (!robotMovements.PositionValidation(xPosition, yPosition))
                {
                  throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
                }
                robotMovements.Place(null, xPosition, yPosition);
              }
              else if (command.Length == 3 && !_robotIsPlaced)
              {
                int xPosition;
                if (!int.TryParse(command[0], out xPosition))
                {
                  throw new FormatException("Provided parameter 1 is not an integer.");
                }
                int yPosition;
                if (!int.TryParse(command[1], out yPosition))
                {
                  throw new FormatException("Provided parameter 2 is not an integer.");
                }
                Direction directionInformation;
                if (!Enum.TryParse(command[2], true, out directionInformation))
                {
                  throw new FormatException("Provided parameter 3 is not a valid direction.");
                }
                if (!robotMovements.PositionValidation(xPosition, yPosition))
                {
                  throw new IndexOutOfRangeException("Provided position is outside tabletop, robot will fall.");
                }
                _robotIsPlaced = robotMovements.Place(directionInformation, xPosition, yPosition);
              }
              else
              {
                throw new ArgumentOutOfRangeException("Insufficiant command parameters.");
              }
              break;
            case "MOVE":
              if (_robotIsPlaced)
              {
                robotMovements.Move();
              }
              else
              {
                throw new Exception("Robot not placed: Please place the robot first.");
              }
              break;
            case "LEFT":
              if (_robotIsPlaced)
              {
                robotMovements.Left();
              }
              else
              {
                throw new Exception("Robot not placed: Please place the robot first.");
              }
              break;
            case "RIGHT":
              if (_robotIsPlaced)
              {
                robotMovements.Right();
              }
              else
              {
                throw new Exception("Robot not placed: Please place the robot first.");
              }
              break;
            case "REPORT":
              if (_robotIsPlaced)
              {
                Console.WriteLine(robotMovements.Report());
              }
              else
              {
                throw new Exception("Robot not placed: Please place the robot first.");
              }
              break;
            case "EXIT":
            case "X":
              return;
            case "":
              throw new ArgumentNullException("Please enter valid command.");
            default:
              throw new InvalidOperationException("Invalid Command.");
          }
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message.ToString());
        }
        Console.ReadLine();
        Console.Clear();
      } while (true);
    }
  }
}
