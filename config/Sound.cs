using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Roll_Call_And_Management_System.views.components.dashboard.alert;

namespace Roll_Call_And_Management_System.config
{
    internal class Sound
    {
        private static string Path = Application.StartupPath;
        public static string sound = Path + "\\settings\\sound.txt";  
        static SoundPlayer player = new SoundPlayer();

        public void Sound1()
        {
            //player.Play();
            player.SoundLocation = @"" + Path + "\\audio\\click-tone.wav";
            player.SoundLocation = @"" + Path + "\\audio\\alert-bells-echo.wav";
            player.Play();
            player.SoundLocation = @"" + Path + "\\audio\\select-click.wav";
            //player.Play();
            //player.Play();
        }

        public void AlertSound(enmType type)
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                switch (type)
                {
                    case enmType.Success:
                        player.SoundLocation = @"" + Path + "\\audio\\notification.wav";
                        break;
                    case enmType.Error:
                        player.SoundLocation = @"" + Path + "\\audio\\click-error.wav";
                        break;
                    case enmType.Info:
                        player.SoundLocation = @"" + Path + "\\audio\\alert-bells-echo.wav";
                        break;
                    case enmType.Warning:
                        player.SoundLocation = @"" + Path + "\\audio\\click-error.wav";
                        break;
                }
                player.Play();
            }
        }

        public void ClickSound()
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + Path + "\\audio\\click-tone.wav";
                player.Play();
            }
        }

        public void CaptureSound()
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + Path + "\\audio\\select-click.wav";
                player.Play();
            }
        }

        public void RemoveSound()
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + Path + "\\audio\\select-click.wav";
                player.Play();
            }
        }

        public void InputErrorSound()
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + Path + "\\audio\\click-error.wav";
                player.Play();
            }
        }
    }
}
