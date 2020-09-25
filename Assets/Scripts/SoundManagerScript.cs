using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip coin, fly, crash;
    static AudioSource audioSrc;
   
    void Start()
    {
        coin = Resources.Load<AudioClip> ("coin");
        fly = Resources.Load<AudioClip> ("fly");
        crash = Resources.Load<AudioClip> ("crash");
        audioSrc = GetComponent <AudioSource> ();
    }

    
   public static void playSoundCoin(){
       audioSrc.PlayOneShot (coin);
   }
    public static void playSoundFly(){
       audioSrc.PlayOneShot (fly);
   }
   public static void playSoundCrash(){
       audioSrc.PlayOneShot (crash);
   }
}
