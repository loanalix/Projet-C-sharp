using System;
using System.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Class
{
    public class Music
    {
        private static SoundPlayer musicPlayer;

        public static void PlayMusic(string filepath)
        {
            musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = filepath;
            musicPlayer.PlayLooping();
        }

        public static void ShortMusic(string filepath) 
        {
            musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = filepath;
            musicPlayer.Play();
        }

        public static void StopMusic()
        {
            if (musicPlayer != null)
            {
                musicPlayer.Stop();
                musicPlayer.Dispose();
            }
        }
    }
}
