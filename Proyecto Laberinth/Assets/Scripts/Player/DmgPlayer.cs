using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgPlayer : MonoBehaviour
{
    public bool ingreso = false;
   
    void Update()
    {   
        if (ingreso == true)
        {
           PlayerTakeDmg(5);
           Debug.Log(GameManager.gameManager._playerHealth.Health);

        }
        
    }

     private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);

    }

     private void OnTriggerEnter (Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            ingreso = true;
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ingreso = false;
        }
    }
}
