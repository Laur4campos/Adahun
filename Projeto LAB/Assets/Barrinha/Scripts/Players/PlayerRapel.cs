using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapel : MonoBehaviour
{
    [SerializeField] PlayerMovement1 pl1;
    [SerializeField] PlayerMovement2 pl2;
   
    void Update()
    {
        Rapel();
    }
    
    void Rapel()
    {
        //In the Ground
        if(pl1.IsGrounded() && pl2.IsGrounded())
        {            
            pl1.isRapel = false;
            pl2.isRapel = false;
            Debug.Log("In the Ground");
        }
        //pl1 Rapel
        if (pl1.GetPosition().y / 2 < pl2.GetPosition().y) 
        {
            pl1.isRapel = true;
            pl2.isRapel = false;
            Debug.Log("Rapel PL1: " + pl1.GetPosition().y +
                "Rapel PL2: " + pl2.GetPosition().y);
        }
        //pl2 Rapel
        if (pl2.GetPosition().y / 2 < pl1.GetPosition().y)
        {
            pl1.isRapel = false;
            pl2.isRapel = true;
            Debug.Log("Rapel PL2: " + pl2.GetPosition().y + 
                "Rapel PL1: " + pl1.GetPosition().y);
        }
        //Falling
        if (!pl1.IsGrounded() && !pl2.IsGrounded())
        {
            pl1.isRapel = false;
            pl2.isRapel = false;
            Debug.Log("Falling");
        }


    }
}
