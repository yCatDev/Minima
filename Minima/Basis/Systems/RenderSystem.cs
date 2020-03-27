using SFML.Graphics;

namespace MinimaFramework.Basis.Systems
{
    public class RenderSystem: GameSystem
    {
        public override void OnUpdate(GameObject gameObject)
        {
            var a = gameObject.GetComponent<RenderComponent>();
            var b = gameObject.GetComponent<TransformComponent>();
            a.Drawable.Draw(Minima.GetInstance().Window, b._it.Transform);
        }
    }
}