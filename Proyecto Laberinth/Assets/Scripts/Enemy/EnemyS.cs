using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{
    public AudioSource audiosrc;

    public Animator animator;
    
    [SerializeField] private AudioClip attackSound1;

    [SerializeField] private AudioClip attackSound2;
    
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    public void ChangeClipAndAttack(AudioClip clip)
    {
        audiosrc.clip = clip;
        audiosrc.Play();
    }

    public void Attack1()
    {
        
        {
            ChangeClipAndAttack(attackSound1);
        }
        
    }

     public void attack2()
    {
        //Attack code
        ChangeClipAndAttack(attackSound2);
    }

    
}
