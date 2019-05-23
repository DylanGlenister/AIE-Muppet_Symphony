using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatActivation : MonoBehaviour
{
    public enum ActivationMode
    {
        Failure = 0,
        Late,
        Perfect,
        Early
    }
    
    public ActivationMode am_mode;

    public Score s_score;
    private Beat[] b_currentBeats;

    BoxCollider2D bc_boxCollider;

    public void AddBeat (Beat pNewBeat)
    {
        if (b_currentBeats.Length == 0)
            b_currentBeats[0] = pNewBeat;
    }

    // Start is called before the first frame update
    void Start ()
    {
        bc_boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        // If beat x < -9.58

        if (Input.GetKeyDown(KeyCode.D))
        {
            s_score.SubtractScore(10);
        }

        if (am_mode == ActivationMode.Failure)
        {
            //s_score.SubtractScore(20);
        }

        if (Input.GetKeyDown(KeyCode.D)
            && am_mode == ActivationMode.Late)
        {
            s_score.AddScore(15);
        }

        if (Input.GetKeyDown(KeyCode.D)
            && am_mode == ActivationMode.Perfect)
        {
            s_score.AddScore(30);
        }

        if (Input.GetKeyDown(KeyCode.D)
            && am_mode == ActivationMode.Early)
        {
            s_score.AddScore(15);
        }
    }
}
