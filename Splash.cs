using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BashSpirt
{
    class Splash
    {
        //Delegate for cross thread call to close
        private delegate void CloseDelegate();

        //The type of form to be displayed as the splash screen.
        private static SplashForm splashForm;
        static public void ShowSplashScreen()
        {
            // Make sure it is only launched once.    
            if ( splashForm != null ) return;
            splashForm = new SplashForm();
            Thread thread = new Thread(new ThreadStart(Splash.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            if ( splashForm != null ) Application.Run(splashForm);
        }

        static public void CloseForm()
        {
            splashForm?.Invoke(new CloseDelegate(Splash.CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            if ( splashForm != null )
            {
                splashForm.Close();
                splashForm = null;
            };
        }
    }
}
