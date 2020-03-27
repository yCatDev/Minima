using System;

namespace MinimaFramework
{
    public class GameComponent
    {
        public ComponentID Id;

        public GameComponent()
        {
            Id = new ComponentID();
        }

        internal void Init(GameObject gameObject)
        {
            Minima.GetInstance().ObjectBuffer.AddGameObject(this.GetType(),gameObject);
        }
        
    }
}