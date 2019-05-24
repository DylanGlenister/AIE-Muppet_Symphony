using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    [Header("Left Player Controls")]
    public KeyCode moveLeftPlayerLeftArm = KeyCode.Q;
    public KeyCode moveLeftPlayerRightArm = KeyCode.W;

    public Rigidbody2D leftPlayerLeftArm;
    public Rigidbody2D leftPlayerRightArm;

    [Header("Right Player Controls")]
    public KeyCode moveRightPlayerLeftArm = KeyCode.O;
    public KeyCode moveRightPlayerRightArm = KeyCode.P;

    public Rigidbody2D rightPlayerLeftArm;
    public Rigidbody2D rightPlayerRightArm;

    [Header("Misc")]
    public KeyCode moveBothPlayersBothArms = KeyCode.Space;
    public Vector2 forceApplied = new Vector2(0, 7500);
   

    // Update is called once per frame
    void Update()
    {
        // Move the Left Arm of the Left Player
        if (Input.GetKeyDown(moveLeftPlayerLeftArm))
            leftPlayerLeftArm.AddForce((forceApplied) * transform.up);

        // Move the Right Arm of the Left Player
        if (Input.GetKeyDown(moveLeftPlayerRightArm))
            leftPlayerRightArm.AddForce((forceApplied) * transform.up);

        // Move the Left Arm of the Right Player
        if (Input.GetKeyDown(moveRightPlayerLeftArm))
            rightPlayerLeftArm.AddForce((forceApplied) * transform.up);

        // Move the Right Arm of the Right Player
        if (Input.GetKeyDown(moveRightPlayerRightArm))
            rightPlayerRightArm.AddForce((forceApplied) * transform.up);

        // Move both Arms on both Players
        if (Input.GetKeyDown(moveBothPlayersBothArms))
        {
            leftPlayerLeftArm.AddForce((forceApplied) * transform.up);
            leftPlayerRightArm.AddForce((forceApplied) * transform.up);
            rightPlayerLeftArm.AddForce((forceApplied) * transform.up);
            rightPlayerRightArm.AddForce((forceApplied) * transform.up);
        }
    }

}
