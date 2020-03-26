using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace MinimaEngine
{
    
    public class Minima
    {
        public const int FPS = 60;
        public static Minima Engine;
        public EntityManager EntityManager;
        public SystemManager SystemManager;
        public RenderWindow Window;
        
        private Clock _dt;
        public Camera Camera;
        
        public Minima(string title, int width = 1200, int height = 900, bool IsFullScreen = false)
        {
            EntityManager = new EntityManager();
            SystemManager = new SystemManager();
            
            Window = new RenderWindow(new VideoMode((uint) width, (uint) height), title, Styles.Close);
            Window.SetFramerateLimit(FPS);
            Window.SetVerticalSyncEnabled(true);
            _dt = new Clock();
            _dt.Restart();
            Window.Closed += (sender, e) => Quit();
            
            Camera = new Camera(Window);
            Engine = this;
        }
        
        
        public bool Update()
        {
            if (_dt.ElapsedTime.AsMilliseconds() > 1/FPS*100)
                {

                    Window.DispatchEvents();
                    Window.Clear(Color.Black);
                    Camera.FollowTarget(Window);
                    SystemManager.Update();
                    Window.Display();
                    _dt.Restart();
                }

            return Window.IsOpen;
        }
        
        public void Quit()
        {
            //logger.LogInfo("-Closing");
            Window.Close();
        }
    }
}