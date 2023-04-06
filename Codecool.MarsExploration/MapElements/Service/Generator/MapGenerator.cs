using System.ComponentModel.Design;
using System.Runtime.Serialization.Formatters;
using Codecool.MarsExploration.Calculators.Model;
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
        MapElementBuilder mapElementBuilder = new MapElementBuilder();
        MapElementsGenerator mapElementsGenerator = new MapElementsGenerator(mapElementBuilder);
        MapElementPlacer mapElementPlacer = new MapElementPlacer();
        CoordinateCalculator coordinateCalculator = new CoordinateCalculator();
        string[,] representation = new string[mapConfig.MapSize, mapConfig.MapSize];
        Map map = new Map(representation, true);
        var elements = mapElementsGenerator.CreateAll(mapConfig);
        //MapElement TestMapElement = new MapElement(new string[,] { { "a" } },"mountain", 1);
        //List<MapElement> elements = new List<MapElement>();
        //elements.Add(TestMapElement);

        for (int i = 0; i < mapConfig.MapSize; i++)
        {
            for (int j = 0; j < mapConfig.MapSize; j++)
            {
                map.Representation[i, j] = " ";
            }
        }

        foreach (var element in elements)
        {
            if (element.Name == "water" || element.Name == "minerals")
            {
                ReturnWaterAndMinerals(element, mapConfig, map.Representation);
                continue;
            }

            var coordinate = coordinateCalculator.GetRandomCoordinate(mapConfig.MapSize);
            int numberOfPlace = 200;
            for (int i = 0; i < numberOfPlace; i++)
            {
                if (!mapElementPlacer.CanPlaceElement(element, map.Representation, coordinate))
                {
                    coordinate = coordinateCalculator.GetRandomCoordinate(mapConfig.MapSize);
                }
                else
                {
                    mapElementPlacer.PlaceElement(element, map.Representation, coordinate);
                    break;
                }
            }
        }

        return map;





        //    if (mapElement.Name == "mountain" || mapElement.Name == "pits")
        //    {
        //        while (!placeElement.CanPlaceElement(mapElement,map.Representation, coordinate))
        //        {
        //            coordinate = coordinateCalculator.GetRandomCoordinate(mapConfig.MapSize);
        //        }
        //        placeElement.PlaceElement(mapElement, map.Representation, coordinate);
        //    }
        //}

        //foreach (var mapElement in elements)
        //{
        //    var coordinate = coordinateCalculator.GetRandomCoordinate(mapConfig.MapSize);
        //    var coord = coordinateCalculator.GetAdjacentCoordinates(coordinate, mapConfig.MapSize);
        //    if (mapElement.Name == "water")
        //    {
        //        while (!placeElement.CanPlaceElement(mapElement, representation, coordinate))
        //        {
        //            coordinate = coordinateCalculator.GetRandomCoordinate(mapConfig.MapSize);
        //        }
        //        foreach (var coordinate1 in coord)
        //        {
        //            if (map.Representation[coordinate1.Y, coordinate1.Y] == mapElement.PreferredLocationSymbol)
        //            {
        //                placeElement.PlaceElement(mapElement, map.Representation, coordinate);
        //            }
        //        }

        //    }
        //    if (mapElement.Name == "minerals")
        //    {
        //        while (!placeElement.CanPlaceElement(mapElement, representation, coordinate))
        //        {
        //            coordinate = coordinateCalculator.GetRandomCoordinate(mapConfig.MapSize);
        //        }
        //        foreach (var coordinate1 in coord)
        //        {
        //            if (map.Representation[coordinate1.Y, coordinate1.Y] == mapElement.PreferredLocationSymbol)
        //            {
        //                placeElement.PlaceElement(mapElement, map.Representation, coordinate);
        //            }
        //        }

        //}


        //var newMap = new Map(map.Representation, true);

        //turn newMap;
        //map.SuccessfullyGenerated = true;

    }

    private void ReturnWaterAndMinerals(MapElement element, MapConfiguration mapConfig, string[,] representation)
    {
        bool isMountainAndPitMade = false;
        const string mountainSymbol = "#";
        const string pitSymbol = "&";
        const string mineralSymbol = "%";
        const string waterSymbol = "*";
        Random random = new Random();

        List<Coordinate> mountainCoordinates = new List<Coordinate>();
        List<Coordinate> pitCoordinates = new List<Coordinate>();
        List<Coordinate> adjacentCoordinatesMountains = new List<Coordinate>();
        List<Coordinate> adjacentCoordinatesPits = new List<Coordinate>();

        if (!isMountainAndPitMade)
        {
            isMountainAndPitMade = true;
            for (int i = 0; i < mapConfig.MapSize; i++)
            {
                for (int j = 0; j < mapConfig.MapSize; j++)
                {
                    if (representation[i, j] == mountainSymbol) mountainCoordinates.Add(new Coordinate(i, j));
                    if (representation[i, j] == pitSymbol) pitCoordinates.Add(new Coordinate(i, j));
                }
            }

            adjacentCoordinatesMountains = GetEmptyAdjacentCoordinates(mapConfig, mountainCoordinates, representation);
            adjacentCoordinatesPits = GetEmptyAdjacentCoordinates(mapConfig, pitCoordinates, representation);
        }

        if (element.Name == "minerals")
        {
            Coordinate placeCoordinate = adjacentCoordinatesMountains[random.Next(adjacentCoordinatesMountains.Count)];
            representation[placeCoordinate.X, placeCoordinate.Y] = mineralSymbol;
            adjacentCoordinatesMountains.Remove(placeCoordinate);
        }

        if (element.Name == "water")
        {
            Coordinate placeCoordinate = adjacentCoordinatesPits[random.Next(adjacentCoordinatesPits.Count)];
            representation[placeCoordinate.X, placeCoordinate.Y] = waterSymbol;
            adjacentCoordinatesPits.Remove(placeCoordinate);
        }
    }

    private List<Coordinate> GetEmptyAdjacentCoordinates(MapConfiguration mapConfig, List<Coordinate> elementsLocation,
        string[,] representation)
    {
        ICoordinateCalculator coordinateCalculator = new CoordinateCalculator();
        List<Coordinate> coordinates = new List<Coordinate>();
        List<Coordinate> finalCoordinates = new List<Coordinate>();

        coordinates = coordinateCalculator.GetAdjacentCoordinates(elementsLocation, mapConfig.MapSize).ToList();

        foreach (var coordinate in coordinates)
        {
            if (representation[coordinate.X, coordinate.Y] == " ")
                finalCoordinates.Add(coordinate);
        }
        return finalCoordinates;
    }



}