using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetToTheDoor.View
{
    class AudioPlayer
    {
        Song song;
        SoundEffect jumpSound, keyPickupSound, deathSound, turretShotSound;
        public AudioPlayer(ContentManager Content)
        {
            song = Content.Load<Song>("Pixelland");
            MediaPlayer.Play(song);
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.IsRepeating = true;

            jumpSound = Content.Load<SoundEffect>("JumpSound");
            keyPickupSound = Content.Load<SoundEffect>("KeyPickup");
            deathSound = Content.Load<SoundEffect>("Deathsound2");
            turretShotSound = Content.Load<SoundEffect>("LaserInterceptEgen");
        }

        public void jump()
        {
            jumpSound.Play(0.2f, 0, 0);
        }

        public void keyPickup()
        {
            keyPickupSound.Play(0.5f, 0, 0);
        }

        public void Death()
        {
            deathSound.Play(0.5f, 0, 0);
        }

        public void turretShot()
        {
            turretShotSound.Play(0.05f, 0, 0);
        }
    }
}
