using System.Collections.Generic;
using VRage.Game.ModAPI.Ingame;

namespace IngameScript
{
    partial class Program
    {
        public static class ItemType
        {
            static Dictionary<string, MyItemType> _OreTypes = new Dictionary<string, MyItemType>();
            static Dictionary<string, MyItemType> _IngotTypes = new Dictionary<string, MyItemType>();
            static Dictionary<string, MyItemType> _ComponentTypes = new Dictionary<string, MyItemType>();
            static public MyItemType GetOreItemType(string SubType)
            {
                if (_OreTypes.ContainsKey(SubType) == false)
                {
                    _OreTypes.Add(SubType, MyItemType.MakeOre(SubType));
                }
                return _OreTypes[SubType];
            }
            static public MyItemType GetIngotItemType(string SubType)
            {
                if (_IngotTypes.ContainsKey(SubType) == false)
                {
                    _IngotTypes.Add(SubType, MyItemType.MakeIngot(SubType));
                }
                return _IngotTypes[SubType];
            }
            static public MyItemType GetComponentItemType(string SubType)
            {
                if (_ComponentTypes.ContainsKey(SubType) == false)
                {
                    _ComponentTypes.Add(SubType, MyItemType.MakeComponent(SubType));
                }
                return _ComponentTypes[SubType];
            }
            static public string GetAllItemTypes()
            {
                string result = "Ore:\n";
                foreach (var itemtype in _OreTypes)
                {
                    result += itemtype.Key + " " + itemtype.Value + "\n";
                }
                result += "Ingot:\n";
                foreach (var itemtype in _IngotTypes)
                {
                    result += itemtype.Key + " " + itemtype.Value + "\n";
                }
                result += "Component:\n";
                foreach (var itemtype in _ComponentTypes)
                {
                    result += itemtype.Key + " " + itemtype.Value + "\n";
                }
                return result;
            }
        }
    }
}
