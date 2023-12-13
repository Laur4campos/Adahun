using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject player1, player2;
    [SerializeField] GameObject tracker;
   
    void Update()
    {
        float distX = (player1.transform.position.x + player2.transform.position.x) / 2;
        float distY = (player2.transform.position.y + player2.transform.position.y) / 2;
        tracker.transform.position = new Vector2(distX, distY);
    }
}
