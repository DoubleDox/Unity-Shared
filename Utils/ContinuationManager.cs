using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;

public static class ContinuationManager
{
    private class Job
    {
        public Job(System.Func<bool> completed, System.Action continueWith)
        {
            Completed = completed;
            ContinueWith = continueWith;
        }
        public System.Func<bool> Completed { get; private set; }
        public System.Action ContinueWith { get; private set; }
    }

    private static readonly List<Job> jobs = new List<Job>();

    public static void Add(System.Func<bool> completed, System.Action continueWith)
    {
        if (!jobs.Any()) EditorApplication.update += Update;
        jobs.Add(new Job(completed, continueWith));
    }

    private static void Update()
    {
        for (int i = 0; i >= 0 && i < jobs.Count; --i)
        {
            var jobIt = jobs[i];
            if (jobIt.Completed())
            {
                jobs.RemoveAt(i);
                jobIt.ContinueWith();
            }
        }
        if (!jobs.Any()) EditorApplication.update -= Update;
    }
}

#endif