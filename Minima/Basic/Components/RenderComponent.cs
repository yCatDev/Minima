using System;
using Minima.SFML.Graphics;
using SFML.Graphics;
using SFML.System;

namespace MinimaEngine
{
    public class RenderComponent: IComponent
    {
        
        public IDrawObject DrawObject;
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

        public RenderComponent()
        {
            
        }

        public void Start()
        {
            var _sprite = (Transformable)DrawObject;
            var bounds = DrawObject.GetGlobalBounds();
            _sprite.Origin = new Vector2f(bounds.Width/2, bounds.Height/2);
            if (DrawObject.Texture != null) DrawObject.Texture.Smooth = true;

            LocalPosition = _sprite.Position;
            Scale = _sprite.Scale;
        }
        
        public void SetParent(GameObject parent)
        {
            this.parent = (Transformable)parent.GetComponent<RenderComponent>().DrawObject;

        }

     
        
        
        public void Rotate(float angle)
        {
            angle = (float) (angle * (Math.PI / 180));
            float x1 = LocalPosition.X;
            float y1 = LocalPosition.Y;

            float x2 = (float) (x1 * Math.Cos(angle) - y1 * Math.Sin(angle));
            float y2 = (float) (x1 * Math.Sin(angle) + y1 * Math.Cos(angle));
            
            LocalPosition = new Vector2f(x2 , y2);
        }


        public Vector2f GetGlobalPosition() => current.Position;
        public void SetGlobalPosition(Vector2f newVec) => current.Position = newVec;
    }
}