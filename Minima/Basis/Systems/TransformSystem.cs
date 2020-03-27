using SFML.System;

namespace MinimaFramework.Basis.Systems
{
    
    public class TransformSystem: GameSystem
    {
        public override void OnUpdate(GameObject gameObject)
        {
            var a = gameObject.GetComponent<TransformComponent>();
            a.LocalPosition = new Vector2f(a.LocalPosition.X+0.1f, a.LocalPosition.Y);
            a._it.Position = a.LocalPosition + a._parent.Position;
            a._it.Rotation = a.LocalRotation;
            a._it.Scale = a.Scale;
        }
    }
}