using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    public enum Size
    {
        regular,
        big
    }

    public Size s_size { get; set; } = Size.regular;

    public ushort us_lane;
    public float f_speed = 200.0f;
 
    Rigidbody2D rb_rigidbody;

    // Start is called before the first frame update
    void Start ()
    {
        rb_rigidbody = GetComponent<Rigidbody2D>();
        rb_rigidbody.AddForce(new Vector2(-f_speed, 0));
    }

    // Update is called once per frame
    void Update ()
    {
    }
}