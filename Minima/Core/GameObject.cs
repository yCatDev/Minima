using System;
using System.Collections.Generic;


namespace MinimaFramework
{
    public class GameObject
    {
        public ObjectID Id;
        public string Name, SceneID;
        private readonly Dictionary<Type,GameComponent> _components;
        
        public GameObject(string name)
        {
            Id = new ObjectID();
            Name = name;
            
            _components = new Dictionary<Type, GameComponent>();
            Minima.GetInstance().GameObjectManager.AddGameObject(this);
        }

        public T GetComponent<T>() where T: GameComponent
            => (T) _components[typeof(T)];
        public void AddComponent<T>(T component) where T : GameComponent
        {
            if (!_components.ContainsKey(typeof(T)))
            {
                _components.Add(typeof(T), component);
                component.Init(this);
            }
        }
    }
}