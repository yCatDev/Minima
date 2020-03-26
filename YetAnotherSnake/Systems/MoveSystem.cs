using MinimaEngine;
using SFML.Graphics;
using SFML.System;

namespace YetAnotherSnake
{
    public class MoveSystem: ISystem
    {
        public void Update()
        {
            var enities = 
                MinimaEngine.Minima.Engine.EntityManager.GetEnitiesComponents<RenderComponent>();
            
            foreach (var eniity in enities)
            {
                if (InputManager.IsMousePressed(InputManager.MouseButton.Left))
                    eniity.LocalPosition = new Vector2f(eniity.current.Position.X+0.01f, eniity.current.Position.Y);
            }
        }
    }
}