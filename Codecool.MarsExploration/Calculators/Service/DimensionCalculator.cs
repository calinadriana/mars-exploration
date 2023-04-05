using System.Reflection.Metadata.Ecma335;

namespace Codecool.MarsExploration.Calculators.Service;

public class DimensionCalculator : IDimensionCalculator
{
    public int CalculateDimension(int size, int dimensionGrowth)
    {
        int ceva = size * dimensionGrowth;
        return findNextSquare(ceva);



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
