using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmJigglePhysics : MonoBehaviour
{

    public KeyCode LPlayer_LArm_Move = KeyCode.Q;
    public KeyCode LPlayer_RArm_Move = KeyCode.W;

    public Rigidbody2D LPlayer_LArm;
    public Rigidbody2D LPlayer_RArm;

    public KeyCode RPlayer_LArm_Move = KeyCode.O;
    public KeyCode RPlayer_RArm_Move = KeyCode.P;
    
    public Rigidbody2D RPlayer_LArm;
    public Rigidbody2D RPlayer_RArm;
    
    public KeyCode Players_BothArms = KeyCode.Space;

    public float forceApplied = 1000;



    // Update is called once per frame
    void Update()
    {
        // Mve the Left Arm of the Left Player
        if (Input.GetKeyDown(LPlayer_LArm_Move))
            LPlayer_LArm.AddForce(new Vector2(0, forceApplied) * transform.up);

        // Move the Right Arm of the Left Player
        if (Input.GetKeyDown(LPlayer_RArm_Move))
            LPlayer_RArm.AddForce(new Vector2(0, forceApplied) * transform.up);

        // Move the Left Arm of the Right Player
        if (Input.GetKeyDown(RPlayer_LArm_Move))
            RPlayer_LArm.AddForce(new Vector2(0, forceApplied) * transform.up);

        // Move the Right Arm of the Right Player
        if (Input.GetKeyDown(RPlayer_RArm_Move))
            RPlayer_RArm.AddForce(new Vector2(0, forceApplied) * transform.up);

        // Move both Arms on both Players
        if (Input.GetKeyDown(Players_BothArms))
        {
            LPlayer_LArm.AddForce(new Vector2(0, forceApplied) * transform.up);
            LPlayer_RArm.AddForce(new Vector2(0, forceApplied) * transform.up);
            RPlayer_LArm.AddForce(new Vector2(0, forceApplied) * transform.up);
            RPlayer_RArm.AddForce(new Vector2(0, forceApplied) * transform.up);
        }
    }
}
