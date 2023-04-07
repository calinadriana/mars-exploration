using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.Configuration.Service;
using Codecool.MarsExploration.MapElements.Service.Builder;
using Codecool.MarsExploration.MapElements.Service.Generator;
using Codecool.MarsExploration.MapElements.Service.Placer;
using Codecool.MarsExploration.Output.Service;

internal class Program
{
    //You can change this to any directory you like
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        Console.WriteLine("Mars Exploration Sprint 1");
        var mapConfig = GetConfiguration();

        //IDimensionCalculator dimensionCalculator = new DimensionCalculator();
        //ICoordinateCalculator coordinateCalculator = new CoordinateCalculator();

        //IMapElementBuilder mapElementFactory = ;
        //IMapElementsGenerator mapElementsGenerator = null;

        //IMapConfigurationValidator mapConfigValidator = new MapConfigurationValidator();
        //IMapElementPlacer mapElementPlacer = null;

        IMapGenerator mapGenerator = new MapGenerator();

        CreateAndWriteMaps(1, mapGenerator, mapConfig);

        Console.WriteLine("Mars maps successfully generated.");
        Console.ReadKey();
    }

    private static void CreateAndWriteMaps(int count, IMapGenerator mapGenerator, MapConfiguration mapConfig)
    {
        
        MapFileWriter mapFileWriter = new ();
        
            var map = mapGenerator.Generate(mapConfig);
            var path =
                @"C:\Users\Adriana\Desktop\proiecte\OOP\mars-exploration-1-csharp-calinadriana\Codecool.MarsExploration\Resources\map1.txt";
            mapFileWriter.WriteMapFile(map, path);
        
        

    }

    private static MapConfiguration GetConfiguration()
    {
        const string mountainSymbol = "#";
        const string pitSymbol = "&";
        const string mineralSymbol = "%";
        const string waterSymbol = "*";

        var mountainsCfg = new MapElementConfiguration(mountainSymbol, "mountain", new[]
        {
            new ElementToSize(7, 20),
            new ElementToSize(6, 30),
        }, 3);

        var pityConfiguration = new MapElementConfiguration(pitSymbol, "pits", new[]
        {
            new ElementToSize(5, 10),
            new ElementToSize(7, 20),
        },10);
        var mineralsConfiguration = new MapElementConfiguration(mineralSymbol, "minerals", new[]
        {
            new ElementToSize(70, 1)
        }, 0, "#");
        var waterConfiguration = new MapElementConfiguration(waterSymbol, "water", new[]
        {
            new ElementToSize(90, 1)
        }, 0, "&");

        List<MapElementConfiguration> elementsCfg = new() { mountainsCfg, pityConfiguration, mineralsConfiguration, waterConfiguration };
        return new MapConfiguration(85, 0.5, elementsCfg);
    }
}
