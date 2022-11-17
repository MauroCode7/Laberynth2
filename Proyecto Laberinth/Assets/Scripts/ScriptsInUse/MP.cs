using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AlienMovement : MonoBehaviour {
private Transform Player;
private Vector3 DirectionOfCharacter;
public float speed = 5.0f;
    //Use this for initialization
    void Start () 
    {
        Player = GameObject.FindWithTag("Player").transform; // labels player as the target for aliens
    }

    //Update is called once per frame
    void Update ()
    {
        transform.LookAt(Player); //this maks the enemy object look at what its following
        transform.Translate (Vector3.forward *speed*Time.deltaTime); //this maks the enemy object follow the player
        //birectionOtCharacter= Player.transtorm-position transtorm.position;
        //DirectionOfCharacter = DirectionOfCharacter . normalized;
        //transform. Translate (DirectionOfCharacter speed, Space. World) ;
    }
}
