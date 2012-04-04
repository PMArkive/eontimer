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
        }

        public void Action()
        {
            SoundPlayer.Play();
        }
    }
}
