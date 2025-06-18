using MissingNumberSOLID.Interfaces;

namespace MissingNumberSOLID.Classes
{
  public class ArrayBuilder : IArrayBuilder
  {
    /// <summary>
    /// Builds an array from a string format in the style [1, 2, 3]
    /// </summary>
    /// <param name="input">String to build array from</param>
    public virtual int[]? BuildArray(string input)
    {
      try
      {
        int[] numberArray = input
          .Trim('[', ']')
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
              .Select(s => int.Parse(s.Trim()))
                .ToArray();


        return numberArray;
      }
      catch (FormatException)
      {
        return null;
      }
    }
  }
}