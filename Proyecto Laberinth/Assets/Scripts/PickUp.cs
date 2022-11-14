using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    

public class PickUp : MonoBehaviour
{

    bool ingreso = false;
    public int totalOsos;

    void Start()
    {
        totalOsos = PlayerPrefs.GetInt("Osos");
    }

    void Update()
    {
        if (ingreso && Input.GetKey(KeyCode.E))
        {
            totalOsos += 1;
            PlayerPrefs.SetInt("Osos", totalOsos);
            Destroy(gameObject);
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
            

        }
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

    private void PlayerHeal(int healing) 
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);

    }
}