using System;
using System.Linq;
using MinimaEngine;
using SFML.Graphics;

namespace MinimaEngine
{
    public class RenderSystem: ISystem
    {
        public void Update()
        {
            var enities = 
                Minima.engine.EntityManager.GetEnitiesComponents<RenderComponent>();
            
            foreach (var eniity in enities)
            {
                Minima.engine.Window.Draw(eniity.DrawObject);
            }
        }
        
        
        
    }
}