using System;
using SFML.Graphics;

namespace Minima.SFML.Graphics
{
    public abstract class DrawObject: Transformable, Drawable
    {
        protected DrawObject(in IntPtr zero)
        : base(zero)
        {
        }

        public abstract void Draw(RenderTarget target, RenderStates states);

    }
}