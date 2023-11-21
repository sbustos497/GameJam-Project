using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimienti : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody2D rb;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y  = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        Run(dir);
        
        //mantener oara subir
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, 1 * speed));
        }
        //para bajar
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector2(0, -1 * speed));
        }

       
    
    }

    public void Run(Vector2 dir)
    {
        rb.AddForce( new Vector2(dir.x * speed, 0));
    }

   

}
