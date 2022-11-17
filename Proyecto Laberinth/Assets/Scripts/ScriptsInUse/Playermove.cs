using System.Collections;
using UnityEngine;


public class Playermove: MonoBehaviour
{
    //Variables
    public static Vector3 playerPos;
    //just for Movement
    public float speed = 400f;
    private Rigidbody rb;
    // for facing the Mouse
    private Camera mainCamera;

    //Use this for initialization
    
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        
        mainCamera = FindObjectOfType<Camera>();

        StartCoroutine(TrackPlayer());
    }
    
    
    IEnumerator TrackPlayer ()
    {
        while (true)
        {
                playerPos = gameObject.transform.position ;
                yield return null;
        }
            
    }
    
    void FixedUpdate()
    {
        
        //Movement START
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); // movement is our direction vector

        rb.AddForce(movement * speed);
        //Movement END
        
        
        // //Face Mouse START
        // Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        // float raylength;
        
        // if (groundPlane.Raycast (cameraRay, out raylength))
        // {

        // }
        // }
        
    }      
           
}
