using Minima.Core;
using MinimaEngine;

namespace MinimaEngine
{
    public class TransformSystem: ISystem
    {
        public void Update()
        {
            var enities = 
                Minima.engine.EntityManager.GetEnitiesByComponent<TransformComponent>();
            foreach (var enitity in enities)
            {
                var e = enitity.GetComponent<TransformComponent>();
                e.current.Position = e.LocalPosition + e.parent.Position;
                e.current.Rotation = e.LocalRotation;
                e.current.Scale = e.Scale;
                if (enitity.HasComponent<RenderComponent>())
                {
                    var a = enitity.GetComponent<RenderComponent>();
                    a.DrawObject.Position = e.current.Position;
                    a.DrawObject.Rotation = e.current.Rotation;
                    a.DrawObject.Scale = e.current.Scale;
                }
            }
            
        }
        
    }
}