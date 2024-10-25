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

        /// <summary>
        /// Checks if a block is part of the same construct as the programmable block.
        /// </summary>
        /// <param name="block">The block to check.</param>
        /// <returns>True if the block is part of the same construct, otherwise false.</returns>
        public bool IfBlockSameConstructAsPB(IMyTerminalBlock block)
        {
            return Me.IsSameConstructAs(block);
        }

        /// <summary>
        /// Initializes the program, sets the update frequency, and initializes jobs.
        /// </summary>
        public Program()
        {
            CurrentFrequency = UpdateFrequency.Update10;
            Runtime.UpdateFrequency = CurrentFrequency;
            jobs = new Job[] {
                    new InventoryCount(),
                };
            for (int i = 0; i < jobs.Length; i++)
            {
                jobs[i].SetProgram(this);
            }
        }

        /// <summary>
        /// Saves the state of the program. This method is optional and can be removed if not needed.
        /// </summary>
        public void Save()
        {
            // Called when the program needs to save its state. Use
            // this method to save your state to the Storage field
            // or some other means. 
            // 
            // This method is optional and can be removed if not
            // needed.
        }

        /// <summary>
        /// Main entry point of the script. Handles different update sources and schedules jobs.
        /// </summary>
        /// <param name="argument">The argument passed to the script.</param>
        /// <param name="updateSource">The source of the update.</param>
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
