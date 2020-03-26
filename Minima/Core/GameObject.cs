using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimaEngine
{
    public abstract class GameObject
    {
        private HashSet<IComponent> _components;
        
        public string Name;

        public GameObject(string name, Scene scene)
        {
            _components = new HashSet<IComponent>();
            Name = name;
            scene.RegisterGameObject(this);
        }

        public virtual void Start()
        {
            
        }

        public bool AddComponent<T>(T Component) where T: IComponent
        {
            if (HasComponent<T>())
                return false;
            else
            {
                _components.Add(Component);
                Component.Start();
                return true;
            }
        }

        public bool HasComponent<T>()
            => _components.OfType<T>().Any();

        public T GetComponent<T>() where T : IComponent
            => _components.OfType<T>().Cast<T>().FirstOrDefault();
    }
}