using SFML.Graphics;
using SFML.System;

namespace MinimaEngine
{
    public class TransformComponent: IComponent
    {
        public Transformable current;
        public Transformable parent;
        private Vector2f _localPosition;
        public Vector2f LocalPosition
        {
            get => _localPosition;
            set
            {
                _localPosition = value;
                current.Position = _localPosition + parent.Position;
            }
            
        }

        public Vector2f Scale
        {
            get => _scale;
            set
            {
                _scale = value;
            }
        }

        public float LocalRotation
        {
            get => _localRotation;
            set
            {
                _localRotation = value;
            }
        }
        
        private float _localRotation;
        private Vector2f _scale;
    }
}