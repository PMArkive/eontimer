using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.IO;
using System.Threading;

namespace ToastTimer
{
    class SoundAction : CountdownAction
    {
        SoundPlayer soundPlayer;

        public SoundAction()
        {
            soundPlayer = new SoundPlayer();
        }

        public SoundAction(Stream sound, Boolean playSound)
        {
            soundPlayer = new SoundPlayer(sound);
            if (playSound)
                soundPlayer.Play();
            else
                soundPlayer.LoadAsync();
        }

        public void Action()
        {
            soundPlayer.Play();
        }
    }
}
