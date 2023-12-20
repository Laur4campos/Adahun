using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speedParalax;
    public Renderer paralax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        paralax.material.mainTextureOffset += new Vector2(speedParalax * Time.deltaTime, 0f);
    }
}
