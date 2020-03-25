using System.Collections.Generic;
using SFML.Graphics;


namespace MinimaEngine
{
    public class SystemManager
    {
        private HashSet<ISystem> _systems;

        public SystemManager()
        {
            _systems = new HashSet<ISystem>();
            RegisterSystem<RenderSystem>();
            RegisterSystem<TransformSystem>();
        }

        public void RegisterSystem<T>() where T: ISystem, new()
        {
            _systems.Add(new T());
        }
        
        public void Update()
        {
            foreach (var system in _systems)
            {
                system.Update();
            }
        }
    }
}