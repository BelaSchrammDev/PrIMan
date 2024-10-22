using Sandbox.ModAPI.Ingame;
using System.Collections.Generic;
using VRage.Game.ModAPI.Ingame;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        Job[] jobs;
        Dictionary<MyItemType, float> inventory = new Dictionary<MyItemType, float>();
        int CurrentJobIndex = 0;
        UpdateFrequency CurrentFrequency = UpdateFrequency.Update100;
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

        public void Save()
        {
            // Called when the program needs to save its state. Use
            // this method to save your state to the Storage field
            // or some other means. 
            // 
            // This method is optional and can be removed if not
            // needed.
        }

        string GetJobStatuses()
        {
            string result = "";
            for (int i = 0; i < jobs.Length; i++)
            {
                result += jobs[i].GetStatus() + "\n";
            }
            return result;
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
                    if (jobs[CurrentJobIndex].Schedule() == Job.ScheduleResult.NextJob)
                    {
                        CurrentJobIndex++;
                        if (CurrentJobIndex >= jobs.Length) CurrentJobIndex = 0;
                    }
                }
                Echo(GetJobStatuses());
            }
        }
    }
}
