﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using MinimaEngine;
 using SimpleX.Coroutines;

namespace MinimaEngine
{
    
    public class TaskManager
    {
        private List<Func<IEnumerator>> Tasks;
        private CoroutineRunner _runner;
        public CoroutineHandle currentTask;

        public TaskManager()
        {
            Tasks = new List<Func<IEnumerator>>();
            _runner = new CoroutineRunner();
            
        }
        
        public TaskManager(params Func<IEnumerator>[] tasks)
        {
            Tasks = tasks.ToList();
            _runner = new CoroutineRunner();

        }

        public void AddTask(Func<IEnumerator> t)
            => Tasks.Add(t);

        public async void Run()
        {
            currentTask = _runner.Run(_run());
        }

        IEnumerator _run()
        {
            foreach (var task in Tasks)
            {
                yield return task.Invoke();
            }
            
        }

        // ReSharper disable once PossibleLossOfFraction
        public void Update() => _runner.Update(1/Minima.FPS);


    }
    
}