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
        if (!pl1.IsGrounded() && pl2.IsGrounded()) 
        {
            pl1.isRapel = true;
            pl2.isRapel = false;
            Debug.Log("Rapel");
        }
        //pl2 Rapel
        if (pl1.IsGrounded() && !pl2.IsGrounded())
        {
            pl1.isRapel = false;
            pl2.isRapel = true;
            Debug.Log("Rapel");
        }
        //Falling
        if (!pl1.IsGrounded() && !pl2.IsGrounded()!)
        {
            pl1.isRapel = false;
            pl2.isRapel = false;
            Debug.Log("Falling");
        }


    }
}
