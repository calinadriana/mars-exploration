using System.Runtime.Serialization.Formatters;
using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.Configuration.Service;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Builder;
using Codecool.MarsExploration.MapElements.Service.Placer;

namespace Codecool.MarsExploration.MapElements.Service.Generator;

public class MapGenerator : IMapGenerator
{

    public Map Generate(MapConfiguration mapConfig)
    {
        IMapElementBuilder builder = new MapElementBuilder();
        IMapElementsGenerator generatedElements = new MapElementsGenerator(builder);
        IMapElementPlacer placeElement = new MapElementPlacer();
        ICoordinateCalculator coordinateCalculator = new CoordinateCalculator();
        string[,] representation = new string[mapConfig.MapSize, mapConfig.MapSize];
        Map map = new Map(representation);
        var elements = generatedElements.CreateAll(mapConfig);


        for (int i = 0; i < mapConfig.MapSize; i++)
        {
            for (int j = 0;j < mapConfig.MapSize; j++)
            {
                map.Representation[i, j] = " ";
            }
        }

        foreach (var element in elements)
        {
            var coordinate = coordinateCalculator.GetRandomCoordinate(mapConfig.MapSize);
            int numberOfPlacement = 200;
            for (int i = 0; i < numberOfPlacement; i++)
            {
                if (!placeElement.CanPlaceElement(element, map.Representation, coordinate))
                {
                    coordinate = coordinateCalculator.GetRandomCoordinate(mapConfig.MapSize);
                }
                else
                {
                    placeElement.PlaceElement(element, map.Representation, coordinate);
                    break;
                }
            }

        }

        return map;

    }
}