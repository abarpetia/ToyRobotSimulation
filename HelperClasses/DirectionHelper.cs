using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulation.HelperClasses
{
  public class DirectionHelper
  {
    /// <summary>
    /// enum to hold robot facing direction information. 
    /// </summary>
    public enum Directions
    {
      NORTH,
      SOUTH,
      EAST,
      WEST
    }

    /// <summary>
    /// Dictionary variable to map the source direction (keys) along with the next right rotating direction (value).
    /// </summary>
    public static Dictionary<Directions, Directions> _rotateRight = new Dictionary<Directions, Directions>
    {
      { Directions.NORTH, Directions.EAST },
      { Directions.SOUTH, Directions.WEST },
      { Directions.EAST, Directions.SOUTH },
      { Directions.WEST, Directions.NORTH }
    };

    /// <summary>
    /// Dictionary variable to map the source direction (keys) along with the next left rotating direction (value).
    /// </summary>
    public static Dictionary<Directions, Directions> _rotateLeft = new Dictionary<Directions, Directions>
    {
      { Directions.NORTH, Directions.WEST },
      { Directions.SOUTH, Directions.EAST },
      { Directions.EAST, Directions.NORTH },
      { Directions.WEST, Directions.SOUTH }
    };

    /// <summary>
    /// This method used to parse string direction to enum. 
    /// </summary>
    public static Directions DirectionParser(string _direction)
    {
      Directions direction;
      if (!Enum.TryParse(_direction, true, out direction))
      {
        throw new FormatException("Provided parameter 3 is not a valid direction.");
      }
      return direction;
    }    
  }
}
