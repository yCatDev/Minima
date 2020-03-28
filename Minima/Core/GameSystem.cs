using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinimaFramework
{
    public abstract class GameSystem
    {
        public List<Type> Components = new List<Type>();
        
        private bool p;

        protected GameSystem( params Type[] Components)
        {
            //Minima.GetInstance().SystemManager.RegSystem(this);
            this.Components = Components.ToList();
            
        }

        public void RegComponent<T>()
        {
            Components.Add(typeof(T));
        }
        
        internal void Update()
        {
           
                OnUpdateStart();
                var objects = Minima.GetInstance().ObjectBuffer.GetGameObjects(Components.ToArray());
                for (var index = 0; index < objects.Count; index++)
                {
                    var a = Minima.GetInstance().GameObjectManager.GetGameObjectByID(objects[index]);
                    OnUpdate(a);
                }

                OnUpdateEnd(objects);
           

        }


        public abstract void OnUpdateStart();
        public abstract void OnUpdate(GameObject gameObject);
        public abstract void OnUpdateEnd(IEnumerable<ObjectID> objectIds);
        
        
    }
}