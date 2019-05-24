using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatActivation : MonoBehaviour
{
    public Score m_sScore;
    
    public List<GameObject> m_lCurrentBeats;

    BoxCollider2D m_bcBoxCollider;

    // Start is called before the first frame update
    void Start ()
    {
        m_bcBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (m_lCurrentBeats.Count == 0)
            return;

        // Removes the oldest beat if it has passed the player
        if (m_lCurrentBeats[0].transform.position.y < -1.0f)
        {
            Destroy(m_lCurrentBeats[0]);
            m_lCurrentBeats.RemoveAt(0);
            m_sScore.SubtractScore(10);
        }

        // Lane 1
        if (Input.GetKeyDown(KeyCode.D))
        {
            List<GameObject> toBeDeleted = new List<GameObject>();
            foreach (GameObject beat in m_lCurrentBeats)
            {
                if (beat.GetComponent<Beat>().m_usLane == 0)
                {
                    // Late
                    if (beat.transform.position.y < 0.75f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(10);
                    }
                    // Perfect
                    else if (beat.transform.position.y < 1.2f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(20);
                    }
                    // Early
                    else if (beat.transform.position.y < 2.0f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(10);
                    }
                }
            }

            // If no beats were interacted with then punish the player
            if (toBeDeleted.Count == 0)
                m_sScore.SubtractScore(10);

            // Purge the to be deleted list
            foreach (GameObject beat in toBeDeleted)
            {
                m_lCurrentBeats.Remove(beat);
                Destroy(beat);
            }

            toBeDeleted.Clear();
        }

        // Lane 2
        if (Input.GetKeyDown(KeyCode.F))
        {
            List<GameObject> toBeDeleted = new List<GameObject>();
            foreach (GameObject beat in m_lCurrentBeats)
            {
                if (beat.GetComponent<Beat>().m_usLane == 1)
                {
                    // Late
                    if (beat.transform.position.y < 0.75f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(10);
                    }
                    // Perfect
                    else if (beat.transform.position.y < 1.2f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(20);
                    }
                    // Early
                    else if (beat.transform.position.y < 2.0f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(10);
                    }
                }
            }

            // If no beats were interacted with then punish the player
            if (toBeDeleted.Count == 0)
                m_sScore.SubtractScore(10);

            // Purge the to be deleted list
            foreach (GameObject beat in toBeDeleted)
            {
                m_lCurrentBeats.Remove(beat);
                Destroy(beat);
            }

            toBeDeleted.Clear();
        }

        // Lane 3
        if (Input.GetKeyDown(KeyCode.J))
        {
            List<GameObject> toBeDeleted = new List<GameObject>();
            foreach (GameObject beat in m_lCurrentBeats)
            {
                if (beat.GetComponent<Beat>().m_usLane == 2)
                {
                    // Late
                    if (beat.transform.position.y < 0.75f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(10);
                    }
                    // Perfect
                    else if (beat.transform.position.y < 1.2f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(20);
                    }
                    // Early
                    else if (beat.transform.position.y < 2.0f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(10);
                    }
                }
            }

            // If no beats were interacted with then punish the player
            if (toBeDeleted.Count == 0)
                m_sScore.SubtractScore(10);

            // Purge the to be deleted list
            foreach (GameObject beat in toBeDeleted)
            {
                m_lCurrentBeats.Remove(beat);
                Destroy(beat);
            }

            toBeDeleted.Clear();
        }

        // Lane 4
        if (Input.GetKeyDown(KeyCode.K))
        {
            List<GameObject> toBeDeleted = new List<GameObject>();
            foreach (GameObject beat in m_lCurrentBeats)
            {
                if (beat.GetComponent<Beat>().m_usLane == 3)
                {
                    // Late
                    if (beat.transform.position.y < 0.75f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(10);
                    }
                    // Perfect
                    else if (beat.transform.position.y < 1.2f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(20);
                    }
                    // Early
                    else if (beat.transform.position.y < 2.0f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(10);
                    }
                }
            }

            // If no beats were interacted with then punish the player
            if (toBeDeleted.Count == 0)
                m_sScore.SubtractScore(10);

            // Purge the to be deleted list
            foreach (GameObject beat in toBeDeleted)
            {
                m_lCurrentBeats.Remove(beat);
                Destroy(beat);
            }

            toBeDeleted.Clear();
        }

        // Lane 5
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<GameObject> toBeDeleted = new List<GameObject>();
            foreach (GameObject beat in m_lCurrentBeats)
            {
                if (beat.GetComponent<Beat>().m_usLane == 4)
                {
                    // Late
                    if (beat.transform.position.y < 0.75f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(10);
                    }
                    // Perfect
                    else if (beat.transform.position.y < 1.2f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(20);
                    }
                    // Early
                    else if (beat.transform.position.y < 2.0f)
                    {
                        toBeDeleted.Add(beat);
                        m_sScore.AddScore(10);
                    }
                }
            }

            // If no beats were interacted with then punish the player
            if (toBeDeleted.Count > 0)
                m_sScore.SubtractScore(10);

            // Purge the to be deleted list
            foreach (GameObject beat in toBeDeleted)
            {
                m_lCurrentBeats.Remove(beat);
                Destroy(beat);
            }

            toBeDeleted.Clear();
        }
    }
}