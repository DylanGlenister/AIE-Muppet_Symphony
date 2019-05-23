using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatActivation : MonoBehaviour
{
    public Score s_score;

    public GameObject[] b_currentBeats;

    BoxCollider2D bc_boxCollider;

    private void PopFirstBeat()
    {
        // Creates a new gameobject list 1 shorter
        GameObject[] newShortList = new GameObject[b_currentBeats.Length - 1];

        for (int i = 0; i < newShortList.Length; i++)
        {
            newShortList[i] = b_currentBeats[i + 1];
        }

        b_currentBeats = newShortList;
    }

    // Start is called before the first frame update
    void Start ()
    {
        bc_boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (b_currentBeats.Length == 0)
            return;

        // Removes the oldest beat if it have passed the player
        if (b_currentBeats[0].transform.position.x < -9.5f)
        {
            Destroy(b_currentBeats[0]);
            PopFirstBeat();
            s_score.SubtractScore(10);
        }

        foreach (GameObject beat in b_currentBeats)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

            }
        }

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    s_score.SubtractScore(10);
        //}

        //if (am_mode == ActivationMode.Failure)
        //{
        //    //s_score.SubtractScore(20);
        //}

        //if (Input.GetKeyDown(KeyCode.D)
        //    && am_mode == ActivationMode.Late)
        //{
        //    s_score.AddScore(15);
        //}

        //if (Input.GetKeyDown(KeyCode.D)
        //    && am_mode == ActivationMode.Perfect)
        //{
        //    s_score.AddScore(30);
        //}

        //if (Input.GetKeyDown(KeyCode.D)
        //    && am_mode == ActivationMode.Early)
        //{
        //    s_score.AddScore(15);
        //}
    }
}
