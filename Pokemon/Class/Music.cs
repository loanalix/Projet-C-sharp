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
        private static SoundPlayer backgroundMusicPlayer; 
        private static SoundPlayer MusicPlayer;    

        // Méthode pour jouer la musique de fond
        public static void BackGroundMusic(string filepath)
        {
            backgroundMusicPlayer = new SoundPlayer(filepath);
            backgroundMusicPlayer.PlayLooping(); 
        }

        // Méthode pour jouer une musique spécifique
        public static void PlayMusic(string filepath)
        {
            MusicPlayer = new SoundPlayer(filepath);
            MusicPlayer.Play();



        }
    }
}
