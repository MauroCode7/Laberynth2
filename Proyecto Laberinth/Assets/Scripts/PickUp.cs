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


}