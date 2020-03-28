using System;
using System.Collections.Generic;
using System.Threading;
using MinimaFramework;
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


            var ms = new MoveSystem(typeof(TransformComponent), typeof(MoveComponent));
            Minima.GetInstance().SystemManager.RegSystem(ms);

            Random random = new Random();
            Texture t = new Texture("test.png");
            for (int i = 0; i < 5000; i++)
            {
                var test = new GameObject($"test{i}");
                test.AddComponent(new RenderComponent()
                {
                    Drawable = new Sprite(t)
                    {

                    }

                });
                test.AddComponent(new TransformComponent()
                {
                    LocalPosition = new Vector2f(random.Next(0, 500), random.Next(0, 500))
                });
                test.AddComponent(new MoveComponent());
                test.GetComponent<MoveComponent>().GenDir();
            }


            
            minima.Run();
        }
    }
}
