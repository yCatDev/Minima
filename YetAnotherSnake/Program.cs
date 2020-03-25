using System;
using System.Collections.Generic;
using System.Threading;
using MinimaEngine;


namespace YetAnotherSnake
{
    class Program
    {    
        static void Main(string[] args)
        {
            MinimaEngine.Minima minima = new MinimaEngine.Minima("Test");
            FirstScene scene = new FirstScene("Scene");
            scene.LoadAndRun();
           
            while (minima.Update())
            {
                
            }
        }
    }
}