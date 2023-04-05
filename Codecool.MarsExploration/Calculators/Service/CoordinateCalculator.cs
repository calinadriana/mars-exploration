using Codecool.MarsExploration.Calculators.Model;

namespace Codecool.MarsExploration.Calculators.Service;

public class CoordinateCalculator : ICoordinateCalculator
{
    public Coordinate GetRandomCoordinate(int dimension)
    {
        Random random = new Random();

        int x = random.Next(0, dimension);
        int y = random.Next(0, dimension);
        return new Coordinate(x, y);
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(Coordinate coordinate, int dimension)
    {
      
        List<Coordinate> adjacentCoordinates = new List<Coordinate>();
        for (int i = coordinate.X - 1; i <= coordinate.X + 1; i++)
        {
            for (int j = coordinate.Y - 1; j <= coordinate.Y + 1; j++)
            {
                Coordinate newCoordinate = new Coordinate(i, j);
                if (i < dimension && j < dimension && i >= 0 && j >= 0 && coordinate !=newCoordinate)
                {
                    adjacentCoordinates.Add(newCoordinate);
                } 
            }
        }

        return adjacentCoordinates;


    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(IEnumerable<Coordinate> coordinates, int dimension)
    {
        List<Coordinate> adjacentCoordinates = new List<Coordinate>();

        foreach (Coordinate coordinate in coordinates)
        {
            //if (coordinate.Y - 1 >= 0) 
            //{
            //    adjacentCoordinates.Add(new Coordinate(coordinate.X,coordinate.Y-1));
            //}

            //if (coordinate.Y + 1 <= dimension)
            //{
            //    adjacentCoordinates.Add(new Coordinate(coordinate.X, coordinate.Y +1));
            //}
            var newCoord =  GetAdjacentCoordinates(coordinate, dimension);
            adjacentCoordinates.AddRange(newCoord);

        }
        return adjacentCoordinates;

    }
}

