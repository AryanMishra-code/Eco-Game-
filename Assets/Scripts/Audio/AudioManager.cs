using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Audio
{
    public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public List<Sound> sounds = new List<Sound>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }
    
    private void SetSoundConfigs(Sound sound)
		{
			GameObject soundObj = new GameObject();
			soundObj.name = sound.name.ToString();
			sound.source = soundObj.AddComponent<AudioSource>();
			sound.source.clip = sound.clips[0];
			sound.source.loop = sound.loop;
			sound.source.volume = sound.volume;
			sound.source.pitch = sound.pitch;
			sound.source.spatialBlend = sound.spatialBlend;
			sound.source.dopplerLevel = sound.dopplerLevel;
			sound.source.minDistance = sound.minDistance;
			sound.source.maxDistance = sound.maxDistance;
		}

		// SetSoundConfigs() overload
		private void SetSoundConfigs(Sound sound, Vector3 pos)
		{
			GameObject soundObj = new GameObject();
			soundObj.name = sound.name.ToString();
			soundObj.transform.position = pos;
			sound.source = soundObj.AddComponent<AudioSource>();
			sound.source.clip = sound.clips[0];
			sound.source.loop = sound.loop;
			sound.source.volume = sound.volume;
			sound.source.pitch = sound.pitch;
			sound.source.spatialBlend = sound.spatialBlend;
			sound.source.dopplerLevel = sound.dopplerLevel;
			sound.source.minDistance = sound.minDistance;
			sound.source.maxDistance = sound.maxDistance;
		}


		public void Play(SoundName name)
		{
			var sound = sounds.Find(s => s.name == name);
			if (sound == null)
			{
				Debug.LogError("Sound: " + name + " not found!");
				return;
			}
			var previousSoundObj = GameObject.Find(name.ToString());
			Destroy(previousSoundObj);
			SetSoundConfigs(sound);
			if (sound.clips.Count > 0) sound.source.clip = SetRandomClip(sound);
			sound.spatialBlend = 0;
			sound.source.Play();
		}
		
		// Play() overload 
		public void Play(SoundName name, Vector3 pos)
		{
			var sound = sounds.Find(s => s.name == name);
			if (sound == null)
			{
				Debug.LogError("Sound: " + name + " not found!");
				return;
			}
			var previousSoundObj = GameObject.Find(name.ToString());
			Destroy(previousSoundObj);
			SetSoundConfigs(sound, pos);
			if (sound.clips.Count > 0) sound.source.clip = SetRandomClip(sound);
			sound.source.Play();
		}

		private AudioClip SetRandomClip(Sound sound)
		{
			sound.source.clip = sound.clips[Random.Range(0, sound.clips.Count)];
			return sound.source.clip;
		}

		// Methods for the custom inspector funcionality 
		public void PlayWithIndex(int index)
		{
			SetSoundConfigsWithIndex(sounds[index]);
			sounds[index].source.Play();
		}

		private void SetSoundConfigsWithIndex(Sound sound)
		{
			sound.source = gameObject.GetComponent<AudioSource>();
			sound.source.clip = sound.clips[0];
			sound.source.loop = sound.loop;
			sound.source.volume = sound.volume;
			sound.source.pitch = sound.pitch;
			sound.source.spatialBlend = sound.spatialBlend;
			sound.source.dopplerLevel = sound.dopplerLevel;
			sound.source.minDistance = sound.minDistance;
			sound.source.maxDistance = sound.maxDistance;
		}
}
}
