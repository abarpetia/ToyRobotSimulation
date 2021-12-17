using System;
using ToyRobotSimulation.HelperClasses;

namespace ToyRobotSimulation
{
  public class Start
  {
    static void Main()
    {
      IRobotMovements robotMovements = new RobotMovements();

      while (true)
      {
        try
        {
          Console.Write("Toy Robot Simulator" + Environment.NewLine + "Enter the command:");
          string[] command = Console.ReadLine().ToString().Split(' ');

          // Switch case to find which command has been fired. 
          switch (command[0].ToUpper())
          {
            case "PLACE":
              if (command.Length == 2)
              {
                command = command[1].Split(',');
                if (command.Length == 3)
                {
                  // Initially placing the robot on tabletop.
                  robotMovements.PlaceRobotOnTableTop(command);
                }
                else if (command.Length == 2)
                {
                  // Moving robot to new provided position.
                  robotMovements.UpdateRobotPlaceOnTableTop(command);
                }
                else
                {
                  throw new ArgumentOutOfRangeException("Insufficient command parameters. Expected: PLACE X, Y, DIRECTION Or PLACE X, Y command");
                }
              }
              else
              {
                throw new ArgumentOutOfRangeException("Insufficient command parameters. Expected: PLACE X, Y, DIRECTION Or PLACE X, Y command");
              }
              break;
            case "MOVE":
              if (robotMovements.IsRobotPlaced())
              {
                robotMovements.MoveRobotForward();
              }
              else
              {
                throw new Exception("Robot not placed: Please place the robot first.");
              }
              break;
            case "LEFT":
              if (robotMovements.IsRobotPlaced())
              {
                robotMovements.RotateRobotToLeft();
              }
              else
              {
                throw new Exception("Robot not placed: Please place the robot first.");
              }
              break;
            case "RIGHT":
              if (robotMovements.IsRobotPlaced())
              {
                robotMovements.RotateRobotToRight();
              }
              else
              {
                throw new Exception("Robot not placed: Please place the robot first.");
              }
              break;
            case "REPORT":
              if (robotMovements.IsRobotPlaced())
              {
                Console.Write(robotMovements.ReportCurrentPosition() + Environment.NewLine + "Press any Key to continue.");
                Console.ReadKey();
              }
              else
              {
                throw new Exception("Robot not placed: Please place the robot first.");
              }
              break;
            case "EXIT":
            case "X":
              return;
            default:
              throw new InvalidOperationException("Invalid Command.");
          }
        }
        catch (Exception e)
        {
          Console.Write(e.Message.ToString() + Environment.NewLine + "Press any key to continue.");
          Console.ReadKey();
        }
        Console.Clear();
      } 
    }
  }
}
