using System;

using MinimaEngine;
using SFML.Graphics;

namespace YetAnotherSnake
{
    public class TestObject: GameObject
    {
        public TestObject(string name, Scene scene) : base(name, scene)
        {
            
            AddComponent(new RenderComponent()
            {
                DrawObject = new CircleShape()
                {
                    FillColor = Color.White,
                    Radius = 10f
                }
            });
            AddComponent(new TransformComponent());
        }
    }
}