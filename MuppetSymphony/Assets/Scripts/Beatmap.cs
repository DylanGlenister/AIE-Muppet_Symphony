using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Beatmap : MonoBehaviour
{
    private struct Beatdata
    {
        public ushort m_usLane;
        public uint m_uiDelay;
    }

    private uint m_uiDelayUntilNextBeat { get; set; }
    private uint m_uiDelayTimer { get; set; }

    public BeatActivation m_baBeatActivation;

    private Beatdata[] m_bdBeatdata;

    public GameObject m_goBeatPrefab;
    public GameObject m_goBeatBigPrefab;
    public GameObject[] m_goLaneList;

    public void ReadFromFile (string pLocation)
    {
        // Finds the filepath of the unityproject
        string path = Application.dataPath;
        //Debug.Log(path);
        //Debug.Log(path + "/Beatmaps" + pLocation);

        // Transfers the contents of a text file into a string array
        // Each line is the data for a single beat with position and delay info
        string[] lines = File.ReadAllLines(path + "/Beatmaps" + pLocation, System.Text.Encoding.UTF8);

        // Updates the beatlist to the length of the data imported
        m_bdBeatdata = new Beatdata[lines.Length];
        
        for (int i = 0; i < lines.Length; i++)
        {
            //Debug.Log(lines[i]);

            // Validates that the data is there
            if (lines == null)
                continue;

            Beatdata newBeat = new Beatdata();
            string[] data = lines[i].Split(',');
            //Debug.Log(data[0] + " - " + data[1]);
            // Applies the seperated data to the beat and adds it to the array
            newBeat.m_usLane = (ushort)int.Parse(data[0]);
            newBeat.m_uiDelay = (uint)int.Parse(data[1]);
            m_bdBeatdata[i] = newBeat;
        }

        m_uiDelayUntilNextBeat = m_bdBeatdata[0].m_uiDelay;
    }

    private void PopFirstBeat ()
    {
        // Creates a new beatdata list 1 shorter
        Beatdata[] newShortList = new Beatdata[m_bdBeatdata.Length - 1];

        for (int i = 0; i < newShortList.Length; i++)
        {
            newShortList[i] = m_bdBeatdata[i + 1];
        }

        m_bdBeatdata = newShortList;
    }

    void Start ()
    {
        // Initlialise variables
        m_uiDelayTimer = 0;

        // Test read
        ReadFromFile("/test.txt");
    }

    private void Update ()
    {
        //Debug.Log(ui_delayTimer + ", " + ui_delayUntilNextBeat);

        if (m_bdBeatdata.Length > 0)
        {
            // Converts the deltatime to milliseconds and increments timer by it
            m_uiDelayTimer += (uint)(Time.deltaTime * 100);

            if (m_uiDelayTimer >= m_uiDelayUntilNextBeat)
            {
                if (m_bdBeatdata[0].m_usLane == 4)
                {
                    // This will spawn a massive 4 lane box that requires space to be pressed
                    GameObject newBeat = Instantiate(m_goBeatBigPrefab,
                        m_goLaneList[m_bdBeatdata[0].m_usLane].transform.position,
                        Quaternion.identity);

                    Beat beatInfo = newBeat.GetComponent<Beat>();
                    beatInfo.m_sSize = Beat.Size.big;
                    beatInfo.m_usLane = m_bdBeatdata[0].m_usLane;

                    m_baBeatActivation.m_lCurrentBeats.Add(newBeat);
                    PopFirstBeat();

                    if (m_bdBeatdata.Length > 0)
                        // Resets timers for next beat
                        m_uiDelayUntilNextBeat = m_bdBeatdata[0].m_uiDelay;
                }
                else
                {
                    // Creates a single beat in a single lane
                    GameObject newBeat = Instantiate(m_goBeatPrefab,
                        m_goLaneList[m_bdBeatdata[0].m_usLane].transform.position,
                        Quaternion.identity);

                    Beat beatInfo = newBeat.GetComponent<Beat>();
                    beatInfo.m_sSize = Beat.Size.regular;
                    beatInfo.m_usLane = m_bdBeatdata[0].m_usLane;

                    m_baBeatActivation.m_lCurrentBeats.Add(newBeat);
                    PopFirstBeat();

                    if (m_bdBeatdata.Length > 0)
                        // Resets timers for next beat
                        m_uiDelayUntilNextBeat = m_bdBeatdata[0].m_uiDelay;
                }
            }
        }
    }
}
