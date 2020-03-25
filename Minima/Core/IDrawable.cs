using SFML.Graphics;
using SFML.System;

namespace Minima.Core
{
    public abstract class IDrawable: Transformable, Drawable
    {
        public void Draw(RenderTarget target, RenderStates states)
        {
            
        }
    }
}