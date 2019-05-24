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
    
    public ushort m_usLane;
    public float m_fSpeed = 200.0f;
 
    Rigidbody2D m_rbRigidbody;

    // Start is called before the first frame update
    void Start ()
    {
        m_rbRigidbody = GetComponent<Rigidbody2D>();
        m_rbRigidbody.AddForce(new Vector2(0, -m_fSpeed));
    }
}