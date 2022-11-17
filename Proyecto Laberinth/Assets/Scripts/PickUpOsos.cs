using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpOsos : MonoBehaviour
{
    [SerializeField] HpPlayer _healthbar;
    PlayerBehaviour PH;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {   
            PlayerHeal(10);
            Destroy(gameObject);
            GameHUD.Osos++; 
            print(GameHUD.Osos);
            _healthbar.SetHealth(GameManager.gameManager._playerHealth.Health);
        
        }
        

    }


    private void PlayerHeal(int healing) 
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);

    }
}



