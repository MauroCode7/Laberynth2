using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public AudioSource audiosrc;
    [SerializeField] HpPlayer _healthbar;

 
    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
    
    }

     private void PlayerHeal(int healing) 
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
        
    }

    private void OnTriggerEnter (Collider col)
    {

        if (col.gameObject.CompareTag("DmgSphere"))
        {
            PlayerTakeDmg(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
            _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
            
            
        }
    }

}
