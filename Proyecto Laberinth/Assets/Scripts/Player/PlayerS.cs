using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{
    public AudioSource audiosrc;
    
    [SerializeField] private AudioClip healing1;

    [SerializeField] private AudioClip healing2;
    
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    public void ChangeClipAndAttack(AudioClip clip)
    {
        audiosrc.clip = clip;
        audiosrc.Play();
    }

    public void Healing1()
    {
        
        {
            ChangeClipAndAttack(healing1);
        }
        
    }

     public void Healing2()
    {
        //Attack code
        ChangeClipAndAttack(healing2);
    }
    

}

