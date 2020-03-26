using System;
using System.Linq;
using Minima.SFML.Graphics;
using MinimaEngine;
using SFML.Graphics;

namespace MinimaEngine
{
    public class RenderSystem: ISystem
    {
        public void Update()
        {
            var enities = 
                Minima.Engine.EntityManager.GetEnitiesComponents<RenderComponent>();
            
            foreach (var e in enities)
            {
                e.current.Position = e.LocalPosition + e.parent.Position;
                e.current.Rotation = e.LocalRotation;
                e.current.Scale = e.Scale;

                    var a = (Transformable)e.DrawObject;
                    a.Position = e.current.Position;
                    a.Rotation = e.current.Rotation;
                    a.Scale = e.current.Scale;
                
                Minima.Engine.Window.Draw((Drawable)e.DrawObject);
            }
            
        }
        
        
        
    }
}