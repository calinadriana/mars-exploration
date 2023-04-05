using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Builder;

public class MapElementBuilder : IMapElementBuilder
{
    public MapElement Build(int size, string symbol, string name, int dimensionGrowth, string? preferredLocationSymbol = null)
    {
        DimensionCalculator dimensionCalculator = new DimensionCalculator();
        CoordinateCalculator coordinateCalculator = new CoordinateCalculator();

        int dimension = dimensionCalculator.CalculateDimension(size, dimensionGrowth);
        string[,] ourElement = new string[dimension, dimension];

        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                ourElement[i, j] = " ";
            }
        }

        for (int i = 0; i < size; i++)
        {
            var generatedRandomCoordinate = coordinateCalculator.GetRandomCoordinate(dimension);
            while (ourElement[generatedRandomCoordinate.X,generatedRandomCoordinate.Y] != " ")
            {
                generatedRandomCoordinate = coordinateCalculator.GetRandomCoordinate(dimension);
            }
            ourElement[generatedRandomCoordinate.X, generatedRandomCoordinate.Y] = symbol;

            
        }


        MapElement generateElement = new MapElement(ourElement, name, dimension);
        return generateElement;

    }
}