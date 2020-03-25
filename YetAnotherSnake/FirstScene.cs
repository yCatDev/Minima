using System.Threading;
using MinimaEngine;

namespace YetAnotherSnake
{
    public class FirstScene: Scene
    {
        public FirstScene(string name) : base(name)
        {
        }

        public override void Start()
        {
            TestObject testObject = new TestObject("test",this);
        }
    }
}