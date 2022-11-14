using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerTakeDmg(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);

    }

     private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);

    }
}
