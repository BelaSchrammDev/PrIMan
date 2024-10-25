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
            public virtual void SetProgram(Program program)
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
                Done,
            }
            public enum RunJobResult
            {
                Run,
                Done,
            }
            private JobStatus status = JobStatus.Init;
            public virtual void InitJob()
            {

            }
            public virtual RunJobResult RunJob()
            {
                return RunJobResult.Done;
            }
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
                        return ScheduleResult.Done;
                    case JobStatus.WaitForCoolDown:
                        if (DateTime.Now - lastRunEnd > cooldownMS)
                        {
                            status = JobStatus.Init;
                            return ScheduleResult.InProgress;
                        }
                        return ScheduleResult.Done;
                }
                return ScheduleResult.Done;
            }
        }

        public class MultiJob : Job
        {
            Job[] jobs;
            int currentJobIndex;
            public MultiJob(string name, Job[] ijobs) : base(name)
            {
                jobs = ijobs;
            }
            public override void SetProgram(Program program)
            {
                base.SetProgram(program);
                for (int i = 0; i < jobs.Length; i++)
                {
                    jobs[i].SetProgram(program);
                }
            }
            public override void InitJob()
            {
                currentJobIndex = 0;
            }
            public override RunJobResult RunJob()
            {
                if (jobs[currentJobIndex].Schedule() == ScheduleResult.Done)
                {
                    currentJobIndex++;
                    if (currentJobIndex >= jobs.Length)
                    {
                        return RunJobResult.Done;
                    }
                }
                return RunJobResult.Run;
            }
        }
    }
}
