using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Prisoners_Management_System.views.components.dashboard.alert;

namespace Prisoners_Management_System.config
{
    internal class Sound
    {
        // declaring and initialize sound file path
        public static string sound = config.Path + "\\settings\\sound.txt";
        // declaring and initialize sound player
        static SoundPlayer player = new SoundPlayer();

        public void Sound1()
        {
            //player.Play();
            player.SoundLocation = @"" + config.Path + "\\audio\\click-tone.wav";
            player.SoundLocation = @"" + config.Path + "\\audio\\alert-bells-echo.wav";
            player.Play();
            player.SoundLocation = @"" + config.Path + "\\audio\\select-click.wav";
            //player.Play();
            //player.Play();
        }
        // Alert sound
        public void Alert(enmType type)
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                switch (type)
                {
                    case enmType.Success:
                        player.SoundLocation = @"" + config.Path + "\\audio\\notification.wav";
                        break;
                    case enmType.Error:
                        player.SoundLocation = @"" + config.Path + "\\audio\\click-error.wav";
                        break;
                    case enmType.Info:
                        player.SoundLocation = @"" + config.Path + "\\audio\\alert-bells-echo.wav";
                        break;
                    case enmType.Warning:
                        player.SoundLocation = @"" + config.Path + "\\audio\\click-error.wav";
                        break;
                }
                player.Play();
            }
        }
        // click sound
        public static void Click()
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + config.Path + "\\audio\\click-tone.wav";
                player.Play();
            }
        }
        // capture sound
        public static void Capture()
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + config.Path + "\\audio\\select-click.wav";
                player.Play();
            }
        }
        // remove sound
        public static void RemoveSound()
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + config.Path + "\\audio\\select-click.wav";
                player.Play();
            }
        }

        public void InputErrorSound()
        {
            if (Convert.ToBoolean(File.ReadAllText(sound)))
            {
                player.SoundLocation = @"" + config.Path + "\\audio\\click-error.wav";
                player.Play();
            }
        }
    }
}
