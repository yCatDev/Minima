using MinimaEngine;

namespace YetAnotherSnake
{
    public class SecondScene: Scene
    {
        public SecondScene(string name) : base(name)
        {
        }

        public override void Start()
        {
            TestTestObject testObject = new TestTestObject("test2", this);
        }
    }
}