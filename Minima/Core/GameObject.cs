using System;
using System.Collections.Generic;


namespace MinimaFramework
{
    public class GameObject
    {
        public ObjectID Id;
        public string Name;
        public Dictionary<Type,GameComponent> Components;
        
        public GameObject(string name)
        {
            Id = new ObjectID();
            Name = name;
            
            Components = new Dictionary<Type, GameComponent>();
            Minima.GetInstance().GameObjectManager.AddGameObject(this);
        }

        public T GetComponent<T>() where T: GameComponent
            => (T) Components[typeof(T)];
        public void AddComponent<T>(T component) where T : GameComponent
        {
            if (!Components.ContainsKey(typeof(T)))
            {
                Components.Add(typeof(T), component);
                component.Init(this);
            }
        }
    }
}