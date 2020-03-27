using System;
using System.Collections.Generic;

namespace MinimaFramework
{
    public abstract class GameSystem
    {
        public List<Type> Components = new List<Type>();

        public void RegComponent<T>()
        {
            Components.Add(typeof(T));
        }
        
        internal void Update()
        {
            var objects = Minima.GetInstance().ObjectBuffer.GetGameObjects(Components.ToArray());
            for (var index = 0; index < objects.Count; index++)
            {
                var objectId = objects[index];
                var a = Minima.GetInstance().GameObjectManager.GetGameObjectByID(objectId);
                OnUpdate(a);
            }
        }
        public abstract void OnUpdate(GameObject gameObject);
    }
}