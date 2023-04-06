using System.ComponentModel.Design;
using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public class MapElementPlacer : IMapElementPlacer
{
    public bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        var maxX = coordinate.X + element.Dimension;
        var maxY = coordinate.Y + element.Dimension;
        
        if (maxX > map.GetLength(0) || maxY > map.GetLength(1)) return false;

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

    //private int startRow = 0;
    //private int endRow = 1;
    //private int startCol = 2;
    //    private int endCol = 3;
    public void PlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        int maxX = coordinate.X + element.Dimension;
        int maxY = coordinate.Y + element.Dimension;
        int elementI = 0;
        for (int i = coordinate.X; i < maxX; i++)
        {
            int elementJ = 0;
            for (int j = coordinate.Y; j < maxY; j++)
            {
                map[i, j] = element.Representation[elementI, elementJ];
                elementJ++;
            }

            elementI++;
        }
    
    //int maxX = coordinate.X + element.Dimension;
    //int maxY = coordinate.Y + element.Dimension;
    //int iEl = 0;

    //for (int i = coordinate.X; i < maxX; i++)
    //{
    //    int jEl = 0;
    //    for (int j = coordinate.Y; j < maxY; j++)
    //    {
    //        map[i,j] = element.Representation[iEl,jEl];
    //        jEl++;
    //    }

    //    iEl++;
    //}

    //map[coordinate.X, coordinate.Y] = element.Name;
    //if (element.Representation.Length > 1)
    //{
    //   int[] mapCoord = GetMapSpace(map, element.Representation.Length);
    //    for (int mapRow = mapCoord[startRow], x=0; mapRow < mapCoord[endRow]; mapRow++, x++)
    //    {
    //        for (int mapCol = mapCoord[startCol], y=0; mapCol < mapCoord[endCol]; mapCol++,y++)
    //        {
    //            map[mapRow, mapCol] = element.Representation[x,y];
    //        }
    //    }
    //}
    //else
    //{
    //    map[coordinate.X, coordinate.Y] = element.Representation[0, 0];
    //}
}

    //private int[] GetMapSpace(string[,]map, int elementSize)
    //{
    //    //int startRow = 0, endRow = 0;
    //    //int startCol = 0, endCol = 0;
    //    int[] result = new int[4]{startRow,startCol,endRow,endCol};
    //    //(int, int)[] result = new[] {(startRow, startCol), (startRow, endCol), (endRow, startCol), (endRow, endCol) };
    //    int elementFreeSpaces = 0;
    //    bool CheckForFreeSpaces = true;
    //    return result;
    //    int i = 0, j = 0;
    //    while (CheckForFreeSpaces)
    //    {
    //        bool isPlaceFree = true;
    //        for ( i = 0; i < elementSize && isPlaceFree; i++)
    //        {
    //            for ( j = 0; j < elementSize && isPlaceFree; j++)
    //            {
    //                if (map[i, j] != null)
    //                {
    //                    isPlaceFree = false;
    //                }
    //            }
    //        }
    //        if (isPlaceFree)
    //        {
    //            result[startRow] = i;
    //            result[endRow] = i+elementSize;
    //            result[startCol] = j;
    //            result[endCol] = j+elementSize;
    //            CheckForFreeSpaces = false;

    //        }

    //    }
        

    //}
}