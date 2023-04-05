using System.ComponentModel.Design;
using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public class MapElementPlacer : IMapElementPlacer
{
    public bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        var maxX = coordinate.X + element.Dimension;
        var maxY = coordinate.Y + element.Dimension;
        if (maxX > map.GetLength(0) || maxY > map.GetLength(0)) return false;

        for (int i = coordinate.X; i < map.GetLength(0); i++)
        {
            for (int j = coordinate.Y; j < map.GetLength(1); j++)
            {
                if (map[i, j] == " ")
                {
                    return true;
                }
            }
        }

        return false;

    }

    public void PlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        map[coordinate.X, coordinate.Y] = element.Name;
    }
}