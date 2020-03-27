using SFML.Graphics;
using SFML.System;

namespace MinimaFramework
{
    public class TransformComponent: GameComponent
    {
        public Transformable _parent;
        public Vector2f LocalPosition { get; set; }

        public Vector2f Scale { get; set; }

        public float LocalRotation { get; set; }
        internal Transformable _it;

        public TransformComponent()
        {
            Scale = new Vector2f(1,1);
            _it = new Transformable();
            _parent = new Transformable();
        }
    }
}