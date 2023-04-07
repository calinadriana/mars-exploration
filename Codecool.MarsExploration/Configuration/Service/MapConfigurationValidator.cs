using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Codecool.MarsExploration.Configuration.Model;

namespace Codecool.MarsExploration.Configuration.Service;

public class MapConfigurationValidator : IMapConfigurationValidator
{
    public bool Validate(MapConfiguration mapConfig)
    {
        

        if (mapConfig.ElementToSpaceRatio != 0.5D)
        {
            Console.WriteLine($"Ratio Space is incorrect! Your size is {mapConfig.ElementToSpaceRatio}");
            return false;
        }
        foreach (var element in mapConfig.MapElementConfigurations)
        {
            if (!ValidatorObjects(element))
            {
                return false;
            }
        }

        

        return true;

        

        
    }
    private bool ValidatorObjects(MapElementConfiguration element)
    {
        if (element.Name == "mountain")
        {
            if (element.DimensionGrowth != 3 || element.ElementsToDimensions is Array &&
                ((Array)element.ElementsToDimensions).Rank < 2 || element.Symbol != "#")
            {
                Console.WriteLine($"You have one of the following issues:\n 1.Your dimension growth have to be 3, and yours is{element.DimensionGrowth}.\n 2.The object has to be multi-dimensional and yours is not.\n 3.You didn't place the correct symbol for the object. You symbol is{element.Symbol}");
                return false;
            }
        }

        if (element.Name == "pits")
        {
            if (element.DimensionGrowth != 10 || element.ElementsToDimensions is Array &&
                ((Array)element.ElementsToDimensions).Rank < 2 || element.Symbol != "&")
            {
                Console.WriteLine($"You have one of the following issues:\n 1.Your dimension growth have to be 3, and yours is{element.DimensionGrowth}.\n 2.The object has to be multi-dimensional and yours is not.\n 3.You didn't place the correct symbol for the object. You symbol is{element.Symbol}");
                return false;


            }
        }

        if (element.Name == "minerals")
        {
            if (element.Symbol != "%" || element.DimensionGrowth != 0 || element.ElementsToDimensions is Array &&
                ((Array)element.ElementsToDimensions).Rank > 1 || element.PreferredLocationSymbol != "#")
            {
                Console.WriteLine($"You have one of the following issues:\n 1.Your dimension growth have to be 3, and yours is{element.DimensionGrowth}.\n 2.The object has to be multi-dimensional and yours is not.\n 3.You did not place the mineral object next to mountains, because you're next to {element.PreferredLocationSymbol}.\n 4.You didn't place the correct symbol for the object. You symbol is{element.Symbol}");
                return false;
            }
        }

        if (element.Name == "water")
        {
            if (element.Symbol != "*" || element.DimensionGrowth != 0 || element.ElementsToDimensions is Array &&
                ((Array)element.ElementsToDimensions).Rank > 1 || element.PreferredLocationSymbol != "&")
            {
                Console.WriteLine($"You have one of the following issues:\n 1.Your dimension growth have to be 3, and yours is{element.DimensionGrowth}.\n 2.The object has to be multi-dimensional and yours is not.\n 3.You did not place the mineral object next to mountains, because you're next to {element.PreferredLocationSymbol}.\n 4.You didn't place the correct symbol for the object. You symbol is{element.Symbol}");
                return false;
            }
        }
        return true;
    }
}
