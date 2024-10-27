using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using VRage.Game.ModAPI.Ingame;

namespace IngameScript
{
    /// <summary>
    /// Main program class for managing jobs and inventory.
    /// </summary>
    partial class Program : MyGridProgram
    {
        Job[] jobs;
        Dictionary<MyItemType, float> inventory = new Dictionary<MyItemType, float>();
        int CurrentJobIndex = 0;
        UpdateFrequency CurrentFrequency = UpdateFrequency.Update100;

        public bool IfBlockSameConstructAsPB(IMyTerminalBlock block)
        {
            return Me.IsSameConstructAs(block);
        }

        public Program()
        {
            //CurrentFrequency = UpdateFrequency.Update10;
            //Runtime.UpdateFrequency = CurrentFrequency;
            jobs = new Job[] {
                    new InventoryCount(),
                };
            for (int i = 0; i < jobs.Length; i++)
            {
                jobs[i].SetProgram(this);
            }
            ItemType.GetOreItemType(Snippets.S_Gold);
            ItemType.GetIngotItemType(Snippets.S_Gold);
            ItemType.GetComponentItemType(Snippets.S_Motor);
            ItemType.GetOreItemType(Snippets.S_Platinum);
            Echo(ItemType.GetAllItemTypes());
            var b = BluePrinttype.GetBluePrint(Snippets.S_SP);
            var b2 = BluePrinttype.GetBluePrint(Snippets.S_Motor + Snippets.S_C);
            Echo(b.ToString());
            Echo(b2.ToString());
        }

        public void Save()
        {
            // Called when the program needs to save its state. Use
            // this method to save your state to the Storage field
            // or some other means. 
            // 
            // This method is optional and can be removed if not
            // needed.
        }

        public void Main(string argument, UpdateType updateSource)
        {
            if (updateSource == UpdateType.Terminal || updateSource == UpdateType.Trigger)
            {
                Echo("Argument: " + argument);
            }
            else if (updateSource == UpdateType.Update10 || updateSource == UpdateType.Update100)
            {
                while (Runtime.CurrentInstructionCount < 1000)
                {
                    if (jobs[CurrentJobIndex].Schedule() == Job.ScheduleResult.Done)
                    {
                        CurrentJobIndex++;
                        if (CurrentJobIndex >= jobs.Length) CurrentJobIndex = 0;
                    }
                }
            }
        }
    }
}
