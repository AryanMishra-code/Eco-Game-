using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

namespace Audio
{
    public enum SoundName
    {
        Move_Ground,
    }
    
    [System.Serializable]
    public class Sound
    {
        [HideInInspector]
        public AudioSource source;

        public SoundName name;
        public SoundType type;
        public List<AudioClip> clips = new List<AudioClip>();

        [Space]

        public bool loop = false;

        [Range(0f, 256f)] public float priority = 128f;
        [Range(0, 1)] public float volume = 1f;
        [Range(0.1f, 3f)] public float pitch = 1f;

        [Space] [Header("3D sound settings")]

        [Range(0f, 1f)] public float spatialBlend = 1f;
        [Range(0f, 5f)] public float dopplerLevel = 1f;

        public float minDistance = 1f;
        public float maxDistance = 500f;
    }

    public enum SoundType
    {
        _3D, 
        _2D
    }
}