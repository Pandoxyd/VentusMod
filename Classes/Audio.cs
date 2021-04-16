using System;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;
using Reactor;

namespace VentusMod.Classes
{
    public class Audio
    {
        public static GameObject Initialize()
        {
            Assets.VentusSounds = new GameObject("VentusSounds");
            Assets.VentusAudioSource = Assets.VentusSounds.AddComponent<AudioSource>();

            Assets.VentusSoundsAB = LoadAssetsBundle();

            Assets.JumpInSound = LoadAudioClip(Assets.VentusSoundsAB, "jump_in_sound");
            Assets.JumpOutSound = LoadAudioClip(Assets.VentusSoundsAB, "jump_out_sound");
            Assets.MoveVentSound = LoadAudioClip(Assets.VentusSoundsAB, "move_vent_sound");

            Assets.VentusSoundsAB.Unload(false);

            return Assets.VentusSounds;
        }
        public static AudioClip LoadAudioClip(AssetBundle ab, string name)
        {
            AudioClip audioBase = Reactor.Extensions.Extensions.LoadAsset<AudioClip>(ab, name);

            if (audioBase == null)
            {
                VentusPlugin.log.LogError("Failed to load AudioClip!");
                return null;
            }
            else
            {
                AudioClip audio = UnityEngine.Object.Instantiate(audioBase);
                return audio;
            }
        }

        public static AssetBundle LoadAssetsBundle()
        {
            string fullPath = Directory.GetCurrentDirectory() + @"\Assets\ventusbundle";

            AssetBundle ventusSounds = AssetBundle.LoadFromFile(fullPath);

            if (ventusSounds == null)
            {
                VentusPlugin.log.LogError("Failed to load the ventusbundle!");
                return null;
            }
            else
            {
                return ventusSounds;
            }
        }

        public static IEnumerator Play(AudioClip audioClip)
        {
            Assets.VentusAudioSource.clip = audioClip;
            SoundManager.Instance.PlaySound(audioClip, false, 1f);
            yield break;
        }

        public static void CoPlay(AudioClip audio)
        {
            IEnumerator currCoroutine = Play(audio);

            if (currCoroutine != null)
            {
                Coroutines.Stop(currCoroutine);
            }

            Coroutines.Start(currCoroutine);
        }

        public class Assets
        {
            public static AssetBundle VentusSoundsAB;
            public static GameObject VentusSounds;
            public static AudioSource VentusAudioSource;
            public static AudioClip JumpInSound, JumpOutSound, MoveVentSound;            
        }
        

    }
}
