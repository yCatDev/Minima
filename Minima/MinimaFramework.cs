using System;
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
        public Minima()
        {
            GameObjectManager = new GameObjectManager();
            SystemManager = new SystemManager();
            ObjectBuffer = new ObjectBuffer();
            
            _instance = this;
        }

        public static Minima GetInstance() => _instance;
        
        public void InitWindow(uint width, uint height, string title)
        {
            Window = new RenderWindow(new VideoMode( width, height), title, Styles.Close);
            Window.SetFramerateLimit(FPS);
            Window.SetVerticalSyncEnabled(true);
            _dt  = new Clock();
            _perfomance = new Clock();
            _dt.Restart();
            Window.Closed += (sender, e) => Quit();
        }

        public bool Update()
        {
            if (_dt.ElapsedTime.AsMilliseconds() > 1/FPS*100)
            {
                
                Window.DispatchEvents();
                Window.Clear(Color.Black);

                _perfomance.Restart();
                SystemManager.Update();
                Console.WriteLine(_perfomance.ElapsedTime.AsMilliseconds());
                Window.Display();
                
                _dt.Restart();
            }

            return Window.IsOpen;
        }
        
        public void Quit()
        {
            Window.Close();
        }
    }
}