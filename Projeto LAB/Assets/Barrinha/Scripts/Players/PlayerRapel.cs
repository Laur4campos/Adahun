using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapel : MonoBehaviour
{
    [SerializeField] PlayerMovement1 pl1, pl2;
    
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
            
        }
        //pl1 Rapel
        if (pl1.GetPosition().y < pl2.GetPosition().y && !pl1.IsGrounded()) 
        {
            pl1.isRapel = true;
            pl2.isRapel = false;
            
        }
        //pl2 Rapel
        if (pl2.GetPosition().y < pl1.GetPosition().y && !pl2.IsGrounded())
        {
            pl1.isRapel = false;
            pl2.isRapel = true;
            
        }
        //Falling
        if (!pl1.IsGrounded() && !pl2.IsGrounded())
        {
            pl1.isRapel = false;
            pl2.isRapel = false;
           
        }


    }
}
