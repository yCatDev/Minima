using MinimaEngine;
using SFML.Graphics;
using SFML.System;

namespace YetAnotherSnake
{
    public class TestTestObject: GameObject
    {
        public TestTestObject(string name, Scene scene) : base(name, scene)
        {
            AddComponent(new RenderComponent()
            {
                DrawObject = new RectangleShape()
                {
                    FillColor = Color.White,
                    Size = new Vector2f(10,100)
                }
            });
        }
    }
}