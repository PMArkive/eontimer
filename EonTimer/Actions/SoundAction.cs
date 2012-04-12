using System;
using System.IO;
using System.Media;

namespace EonTimer
{
    public class SoundAction : ICountdownAction
    {
        public SoundPlayer SoundPlayer { get; set; }

        public SoundAction()
        {
            SoundPlayer = new SoundPlayer();
            SoundPlayer.LoadAsync();
        }
        public SoundAction(Stream sound)
        {
            SoundPlayer = new SoundPlayer(sound);
            SoundPlayer.LoadAsync();
        }

        public void Action()
        {
            SoundPlayer.Play();
        }
    }
}
