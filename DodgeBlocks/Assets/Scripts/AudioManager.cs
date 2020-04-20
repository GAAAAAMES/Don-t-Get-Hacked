using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public Sound[] sounds;
   public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {		
    	if(instance == null){
    		instance = this;
    	}else
    	{
    		Destroy(gameObject);
    		return;
    	}

    	DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds){
        	s.source  = gameObject.AddComponent<AudioSource>();
        	s.source.clip = s.clip;
        	s.source.volume = s.volume;
        	s.source.pitch = s.pitch;
        	s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Theme1");
    }

     public Sound findSound(string name){
    	Sound s = Array.Find(sounds,sound => sound.name == name);
    	if(s == null){
        		Debug.Log("Sound: "+name+" not found!");
        		return null;
        	}
    	return s;
      }

    public void Play(string name)
    {
    	Sound s = findSound(name);
        Debug.Log(s);
    	s.source.Play();
    }

    public void Stop(string name)
    {
    	Sound s = findSound(name);
    	s.source.Stop();
    }

    public void Pause(string name)
    {
        Sound s = findSound(name);
        s.source.Pause();
    }

    public void Resume(string name)
    {
        Play(name);
    }    

   public void Mute(string name){
 	Sound s = findSound(name);
    	s.source.mute = true;	   
   }
  
   public void Unmute(string name){
	Sound s = findSound(name);
    	s.source.mute = false;
   }


 

}
