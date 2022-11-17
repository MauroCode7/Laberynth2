using UnityEngine;
using UnityEngine.UI;


public class GameHUD : MonoBehaviour
{
    public Text textoPuntaje;
    public static int Osos = 0;
    
    
    
    
    
    void Update()
    {
        textoPuntaje.text = "x :" + Osos.ToString();

    }
   

}
