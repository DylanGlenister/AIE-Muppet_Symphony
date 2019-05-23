﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatActivation : MonoBehaviour
{
    public Score s_score;
    
    public List<GameObject> l_currentBeats;

    BoxCollider2D bc_boxCollider;

    // Start is called before the first frame update
    void Start ()
    {
        bc_boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (l_currentBeats.Count == 0)
            return;

        // Removes the oldest beat if it has passed the player
        if (l_currentBeats[0].transform.position.x < -9.5f)
        {
            Destroy(l_currentBeats[0]);
            l_currentBeats.RemoveAt(0);
            s_score.SubtractScore(10);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<GameObject> toBeDeleted = new List<GameObject>();
            foreach (GameObject beat in l_currentBeats)
            {
                // Late
                if (beat.transform.position.x < -7)
                {
                    toBeDeleted.Add(beat);
                    s_score.AddScore(10);
                }
                // Perfect
                else if (beat.transform.position.x < -6.75f)
                {
                    toBeDeleted.Add(beat);
                    s_score.AddScore(20);
                }
                // Early
                else if (beat.transform.position.x < -6)
                {
                    toBeDeleted.Add(beat);
                    s_score.AddScore(10);
                }
            }

            // If no beat were interacted with then punish the player
            if (toBeDeleted.Count > 0)
                s_score.SubtractScore(10);

            // Purge the to be deleted list
            foreach (GameObject beat in toBeDeleted)
            {
                l_currentBeats.Remove(beat);
                Destroy(beat);
            }

            toBeDeleted.Clear();
        }
    }
}