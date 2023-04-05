using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.Output.Service;

public class MapFileWriter : IMapFileWriter
{
    public void WriteMapFile(Map map, string file)
    {
        
        var path =
            "C:\\Users\\Adriana\\Desktop\\proiecte\\OOP\\mars-exploration-1-csharp-calinadriana\\Codecool.MarsExploration\\Resources\\map1.txt";
        File.WriteAllText(path, map.Representation.ToString());
    }
}