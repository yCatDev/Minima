using System;
using System.Threading;
using System.Xml;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MinimaFramework
{
    public partial class Minima
    {
        public const int FPS = 60;

        private static Minima _instance;
        public RenderWindow Window;
        public GameObjectManager GameObjectManager;
        public SystemManager SystemManager;
        public ObjectBuffer ObjectBuffer;
        private Clock _dt, _perfomance;
        public Camera Camera;
        public Thread RenderThread, UpdateThread;

        private RenderSystem rs;
        private TransformSystem ts;
        private static Mutex _mutex;

        public Minima()
        {
            GameObjectManager = new GameObjectManager();
            SystemManager = new SystemManager();
            ObjectBuffer = new ObjectBuffer();
            _mutex = new Mutex();
            _instance = this;
        }

        public static Minima GetInstance() => _instance;

        public void InitWindow(uint width, uint height, string title)
        {
            Window = new RenderWindow(new VideoMode(width, height), title, Styles.Close);
            Window.SetFramerateLimit(FPS);
            Window.SetVerticalSyncEnabled(true);
            _dt = new Clock();
            _perfomance = new Clock();
            _dt.Restart();
            Camera = new Camera(Window);
            Window.SetActive(false);

            Window.Closed += (sender, e) => Quit();
        }

        public void Run()
        {
            rs = new RenderSystem(typeof(RenderComponent), typeof(TransformComponent));
            ts = new TransformSystem(typeof(TransformComponent));
            SystemManager.RegSystem(ts);
            RenderThread = new Thread(() =>
            {
                Window.SetActive(true);
                while (Window.IsOpen)
                {
                    _mutex.WaitOne();

                    rs.Update();
                    Window.Display();
                    _mutex.ReleaseMutex();
                }
            });
            RenderThread.Start();

            while (Window.IsOpen)
            {
                _perfomance.Restart();
                Console.WriteLine(_dt.ElapsedTime.AsMilliseconds());
                if (_dt.ElapsedTime.AsMilliseconds() > 1000/FPS)
                {
                    Window.DispatchEvents();
                    SystemManager.Update();
                    _dt.Restart();
                }

                //Console.WriteLine(_perfomance.ElapsedTime.AsMilliseconds());
            }
        }

        public void Update()
        {
        }


        public void Quit()
        {
            Window.Close();
        }
    }
}