
using MinimaEngine;
using SFML.Graphics;

namespace MinimaEngine
{
    public class TransformSystem: ISystem
    {
        public void Update()
        {
            var enities = 
                Minima.Engine.EntityManager.GetEnitiesByComponent<TransformComponent>();
            foreach (var enitity in enities)
            {
                
            }
            
        }
        
    }
}