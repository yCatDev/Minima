using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using SFML.Graphics;
using SFML.System;

namespace MinimaFramework
{
    public class RenderSystem: GameSystem
    {
        public override void OnUpdateStart()
        {
            Minima.GetInstance().Window.Clear(Color.Black);
        }

        public override void OnUpdate(GameObject gameObject)
        {
            var a = gameObject.GetComponent<RenderComponent>();
            var b = gameObject.GetComponent<TransformComponent>();
            var s = (Sprite) a.Drawable;
            if (s.GetGlobalBounds().Intersects(Minima.GetInstance().Camera.GetView().Viewport))
            //if (IsInView(b.LocalPosition, s.TextureRect))
            a.Drawable.Draw(Minima.GetInstance().Window, b._it.Transform);
           
        }

        public override void OnUpdateEnd(IEnumerable<ObjectID> objectIds)
        {
           
        }

        public bool IsInView(Vector2f pos, IntRect rect)
            => (pos.X > 0 - rect.Width && pos.X < 800 && pos.Y > 0 - rect.Height && pos.Y < 600);

        public bool InRect(IntRect a, IntRect b)
            => a.Left > b.Width && a.Top > b.Height;
        
        public RenderSystem(params Type[] Components) : base(Components)
        {
            
        }
    }
}