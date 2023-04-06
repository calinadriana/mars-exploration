using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Builder;

namespace Codecool.MarsExploration.MapElements.Service.Generator;

public class MapElementsGenerator : IMapElementsGenerator
{
    private readonly MapElementBuilder builder;

    public MapElementsGenerator(MapElementBuilder builder)
    {
        this.builder = builder;
    }
    public IEnumerable<MapElement> CreateAll(MapConfiguration mapConfig)
    {
        List<MapElement> generatedElements = new List<MapElement>();
        foreach (var mapElementConfiguration in mapConfig.MapElementConfigurations)
        {
            foreach (var elementDimension in mapElementConfiguration.ElementsToDimensions) 
            {
                for (int i = 0; i < elementDimension.ElementCount; i++)
                {
                    var generatedElement = builder.Build(
                        elementDimension.Size,
                        mapElementConfiguration.Symbol,
                        mapElementConfiguration.Name,
                        mapElementConfiguration.DimensionGrowth,
                        mapElementConfiguration.PreferredLocationSymbol
                    );
                    generatedElements.Add(generatedElement);
                }
            }
        }

        return generatedElements;

    }
}