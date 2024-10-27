using System.Collections.Generic;
using VRage.Game;

namespace IngameScript
{
    partial class Program
    {
        public class BluePrinttype
        {
            static Dictionary<string, MyDefinitionId?> _BluePrints = new Dictionary<string, MyDefinitionId?>();
            static public MyDefinitionId? GetBluePrint(string SubType)
            {
                if (_BluePrints.ContainsKey(SubType) == false)
                {
                    MyDefinitionId defID;
                    if (MyDefinitionId.TryParse(Snippets.S_BPDef + SubType, out defID))
                    {
                        _BluePrints.Add(SubType, defID);
                    }
                    else
                    {
                        _BluePrints.Add(SubType, null);
                    }
                }
                return _BluePrints[SubType];
            }
        }
    }
}
