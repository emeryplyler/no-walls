using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public int ID;
        public AudioClip clip;
        [Range(0, 1)]
        public float volume;
        [Range(-3, 3)]
        public float pitch;
        public bool looping;
    }
    public List<Sound> sounds = new List<Sound>();

    public static SoundManager instance;

    public AudioSource music;
    public AudioSource global;

    private void Awake()
    {
        instance = this;


    }

    private void Start()
    {
        //PlayHere(0, music);
    }

    private Sound getSoundFromID(int soundID)
    {
        for (int i = 0; i < sounds.Count; i++)
        {
            if (sounds[i].ID == soundID)
            {
                return sounds[i];
            }
        }
        Debug.LogError("Tried to get sound with invalid ID. ID: " + soundID);
        return null;
    }

    public void SetMusicVolume(float vol, bool playIfPaused = true)
    {
        music.volume = vol;
        if (playIfPaused && !music.isPlaying)
        {
            music.Play();
        }
    }

    public void StopSoundHere(int soundID, AudioSource source)
    {
        Sound toPlay = getSoundFromID(soundID);

        if (source.clip == toPlay.clip && source.isPlaying)
        {
            source.Stop();
        }
    }

    public void PlayGlobal(int soundID, float volume = -1)
    {
        PlayHere(soundID, global, volume);
    }

    public void PlayHere(int soundID, AudioSource source, float volume = -1, bool restart = false)
    {
        Sound toPlay = getSoundFromID(soundID);

        source.volume = volume == -1 ? toPlay.volume : volume;
        source.pitch = toPlay.pitch;
        source.loop = toPlay.looping;

        if (source.clip != toPlay.clip || !source.isPlaying || restart == true)
        {
            source.clip = toPlay.clip;
            source.Play();
        }
    }
}