using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoPlayer : MonoBehaviour
{
    public float velocidade; // Ajuste conforme necessário
    public Rigidbody2D PlayerRb;
    private float movePlayer;

    public float jumpForce; // força do pulo 
    public bool pulo, isgrounded;

    void Update()
    {
        movePlayer = Input.GetAxis("Horizontal");
        PlayerRb.velocity = new Vector2(movePlayer * velocidade, PlayerRb.velocity.y);

        pulo = Input.GetButtonDown("Jump"); // Corrigido aqui, "Jump" em vez de "jump"

        if(pulo == true && isgrounded == true)
        {
            PlayerRb.AddForce(new Vector2(0, jumpForce));
            isgrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("chao"))
        {
            isgrounded = true;
        }
    }

}
