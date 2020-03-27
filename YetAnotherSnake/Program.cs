using System;
using System.Collections.Generic;
using System.Threading;
using MinimaFramework;
using MinimaFramework.Basis.Systems;
using SFML.Graphics;
using SFML.System;


namespace YetAnotherSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            Minima minima = new Minima();
            minima.InitWindow(800, 600, "Minima test");
            
            RenderSystem rs = new RenderSystem();
            TransformSystem ts = new TransformSystem();
            rs.RegComponent<RenderComponent>();
            ts.RegComponent<TransformComponent>();
            minima.SystemManager.RegSystem(rs);
            minima.SystemManager.RegSystem(ts);


            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                var test = new GameObject("test");
                test.AddComponent(new RenderComponent()
                {
                    Drawable = new CircleShape()
                    {
                        FillColor = Color.White,
                        Radius = 100f
                    }
                });
                test.AddComponent(new TransformComponent()
                {
                    LocalPosition = new Vector2f(random.Next(0,500), random.Next(0,500))
                });
            }
           
           
            
            while (minima.Update())
            {
                
            }
        }
    }
}
