using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public float f_speed = 150.0f;
 
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, -f_speed));
    }

    // Update is called once per frame
    void Update ()
    {
    }
}
