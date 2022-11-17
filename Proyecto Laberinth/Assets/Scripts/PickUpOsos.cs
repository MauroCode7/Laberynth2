using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpOsos : MonoBehaviour
{
 
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameHUD.Osos++; 
            print(GameHUD.Osos);
        
        }
        

    }
}



