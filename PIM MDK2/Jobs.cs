using System;

namespace IngameScript
{
    partial class Program
    {
        public abstract class Job
        {
            public Program _program;
            public readonly string Jobname;
            private readonly TimeSpan cooldownMS;
            private DateTime lastRunEnd = DateTime.Now;
            public Job(string name, int icooldown = 0)
            {
                Jobname = name;
                cooldownMS = TimeSpan.FromSeconds(icooldown);
            }
            public void SetProgram(Program program)
            {
                _program = program;
            }
            private enum JobStatus
            {
                Init,
                InProgress,
                WaitForCoolDown,
            }
            public enum ScheduleResult
            {
                InProgress,
                NextJob,
            }
            public enum RunJobResult
            {
                Run,
                Done,
            }
            private JobStatus status = JobStatus.Init;
            public abstract void InitJob();
            public abstract RunJobResult RunJob();
            public ScheduleResult Schedule()
            {
                switch (status)
                {
                    case JobStatus.Init:
                        InitJob();
                        status = JobStatus.InProgress;
                        return ScheduleResult.InProgress;
                    case JobStatus.InProgress:
                        if (RunJob() == RunJobResult.Run) return ScheduleResult.InProgress;
                        status = JobStatus.WaitForCoolDown;
                        lastRunEnd = DateTime.Now;
                        return ScheduleResult.NextJob;
                    case JobStatus.WaitForCoolDown:
                        if (DateTime.Now - lastRunEnd > cooldownMS)
                        {
                            status = JobStatus.Init;
                            return ScheduleResult.InProgress;
                        }
                        return ScheduleResult.NextJob;
                }
                return ScheduleResult.NextJob;
            }
            public abstract string GetStatus();
            public string DebugStatus()
            {
                return status.ToString() + " - " + cooldownMS.ToString();
            }
        }
    }
}
