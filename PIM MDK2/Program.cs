// Program.cs
using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using VRage.Game.ModAPI.Ingame;

namespace IngameScript
{
    /// <summary>
    /// Main program class for managing jobs and tracking inventory.
    /// </summary>
    partial class Program : MyGridProgram
    {
        // Array of jobs to execute in sequence
        private readonly Job[] _jobs;

        // Inventory dictionary: maps item types to their total quantities
        private readonly Dictionary<MyItemType, float> _inventory = new Dictionary<MyItemType, float>();

        // Index of the currently running job
        private int _currentJobIndex;

        // Frequency at which this script updates (e.g., every 10 ticks)
        private readonly UpdateFrequency _updateFrequency = UpdateFrequency.Update10;

        public Program()
        {
            // Set the update frequency for this script
            Runtime.UpdateFrequency = _updateFrequency;

            // Initialize job list, injecting this Program instance into each job
            _jobs = new Job[]
            {
                new InventoryCount(this),
                // add other jobs here, e.g. new SomeOtherJob(this, cooldownSeconds),
            };

            // Preload common item types into cache
            ItemType.GetOreItemType(Snippets.S_Gold);
            ItemType.GetIngotItemType(Snippets.S_Gold);
            ItemType.GetComponentItemType(Snippets.S_Motor);
            ItemType.GetOreItemType(Snippets.S_Platinum);

            // Display all cached item types
            Echo(ItemType.GetAllItemTypes());

            // Example blueprint lookups
            var b = BluePrinttype.GetBluePrint(Snippets.S_SP);
            var b2 = BluePrinttype.GetBluePrint(Snippets.S_Motor + Snippets.S_C);
            Echo(b.ToString());
            Echo(b2.ToString());
        }

        public void Save()
        {
            // Called when the programmable block needs to save its state.
            // Use this to write any persistent data to the Storage field.
            // Remove this method if no state persistence is required.
        }

        public void Main(string argument, UpdateType updateSource)
        {
            // Handle manual or timer-triggered invocations
            if (updateSource == UpdateType.Terminal || updateSource == UpdateType.Trigger)
            {
                Echo("Argument: " + argument);
                return;
            }

            // Handle periodic updates based on the set frequency
            if (updateSource.HasFlag(_updateFrequency))
            {
                // Run jobs until we reach the instruction count limit for this tick
                while (Runtime.CurrentInstructionCount < 1000)
                {
                    var result = _jobs[_currentJobIndex].Schedule();
                    if (result == Job.ScheduleResult.Done)
                    {
                        // Move to the next job, wrapping around if necessary
                        _currentJobIndex = (_currentJobIndex + 1) % _jobs.Length;
                    }
                    else
                    {
                        // Current job still has work pending
                        break;
                    }
                }
            }
        }

        // Expose inventory to jobs
        public Dictionary<MyItemType, float> Inventory => _inventory;
    }
}
