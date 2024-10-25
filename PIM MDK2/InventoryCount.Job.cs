using System.Collections.Generic;
using VRage.Game.ModAPI.Ingame;

namespace IngameScript
{
    partial class Program
    {
        public class InventoryCount : Job
        {
            List<IMyInventoryOwner> myInventoryOwners = new List<IMyInventoryOwner>();
            int currentInventoryOwnerIndex;
            public InventoryCount() : base("InventoryCount")
            {
            }
            public override void InitJob()
            {
                _program.GridTerminalSystem.GetBlocksOfType<IMyInventoryOwner>(myInventoryOwners);
                currentInventoryOwnerIndex = 0;
                var keys = new List<MyItemType>(_program.inventory.Keys);
                for (var i = 0; i < keys.Count; i++) _program.inventory[keys[i]] = 0;
            }

            public override RunJobResult RunJob()
            {
                if (currentInventoryOwnerIndex >= myInventoryOwners.Count) return RunJobResult.Done;
                IMyInventoryOwner inventoryOwner = myInventoryOwners[currentInventoryOwnerIndex];
                for (int i = 0; i < inventoryOwner.InventoryCount; i++)
                {
                    IMyInventory inventory = inventoryOwner.GetInventory(i);
                    List<MyInventoryItem> items = new List<MyInventoryItem>();
                    inventory.GetItems(items);
                    for (int j = 0; j < items.Count; j++)
                    {
                        MyInventoryItem item = items[j];
                        if (_program.inventory.ContainsKey(item.Type))
                        {
                            _program.inventory[item.Type] += (float)item.Amount;
                        }
                        else
                        {
                            _program.inventory.Add(item.Type, (float)item.Amount);
                        }
                    }
                }
                currentInventoryOwnerIndex++;
                return RunJobResult.Run;
            }
        }
    }
}
