using System.Reflection.Metadata.Ecma335;

namespace Codecool.MarsExploration.Calculators.Service;

public class DimensionCalculator : IDimensionCalculator
{
    public int CalculateDimension(int size, int dimensionGrowth)
    {
        int dimension = size * dimensionGrowth;
        if (dimension <= 0)
        {
            dimension = 1;
        }
        return findNextSquare(dimension);



    }

    private bool isPerfect(int n)
    {
        if((Math.Sqrt(n) - Math.Floor(Math.Sqrt(n))) !=0)
        {
            return false;
        }
        return true;

    }

    private int findNextSquare(int number)
    {
        if (isPerfect(number))
        {
            return number;
        }

        int nextNumber = (int)Math.Floor(Math.Sqrt(number)) + 1;
        return nextNumber;
    }

}
