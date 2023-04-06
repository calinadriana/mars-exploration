using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Generator;

namespace Codecool.MarsExploration.Output.Service;

public class MapFileWriter : IMapFileWriter
{
    
    
    public void WriteMapFile(Map map, string file)
    {
           
        
        File.WriteAllText(file,map.ToString());
    }
}