using SeriousGameToolbox.Contracts;
using SeriousGameToolbox.I2D.Controls;
using System.Collections.Generic;

namespace SeriousGameToolbox.I2D
{
    /// <summary>
    /// The controller responsible for 2D handling (especially graphical user interface)
    /// </summary>
    public class I2DController : IUpdatable
    {
        List<ScreenControl> screens = new List<ScreenControl>(16);

        public I2DController()
        {
        }

        /// <summary>
        /// Add a screen to the list of screens that will be handled.
        /// </summary>
        protected void RegisterScreen(ScreenControl screen)
        {
            if (screen == null)
            {
                throw new System.ArgumentNullException("screen");
            }

            this.screens.Add(screen);
        }        

        public void Update(double dt)
        {

        }

        public virtual void Draw()
        {
            foreach (ScreenControl screen in screens)
            {
                screen.Draw();
            }
        }
    }
}
