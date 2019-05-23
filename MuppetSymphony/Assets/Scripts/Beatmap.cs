using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Beatmap : MonoBehaviour
{
    private struct Beatdata
    {
        public ushort us_lane;
        public uint ui_delay;
    }

    private uint ui_delayUntilNextBeat { get; set; }
    private uint ui_delayTimer { get; set; }

    public BeatActivation ba_beatActivation;

    private Beatdata[] bd_beatList;

    public GameObject go_beatPrefab;
    public GameObject go_beatBigPrefab;
    public GameObject[] go_laneList;

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
        bd_beatList = new Beatdata[lines.Length];
        
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
            newBeat.us_lane = (ushort)int.Parse(data[0]);
            newBeat.ui_delay = (uint)int.Parse(data[1]);
            bd_beatList[i] = newBeat;
        }

        ui_delayUntilNextBeat = bd_beatList[0].ui_delay;
    }

    private void PopFirstBeat ()
    {
        // Creates a new beatdata list 1 shorter
        Beatdata[] newShortList = new Beatdata[bd_beatList.Length - 1];

        for (int i = 0; i < newShortList.Length; i++)
        {
            newShortList[i] = bd_beatList[i + 1];
        }

        bd_beatList = newShortList;
    }

    void Start ()
    {
        // Initlialise variables
        ui_delayTimer = 0;

        // Test read
        ReadFromFile("/test.txt");
    }

    private void Update ()
    {
        //Debug.Log(ui_delayTimer + ", " + ui_delayUntilNextBeat);

        if (bd_beatList.Length > 0)
        {
            // Converts the deltatime to milliseconds and increments timer by it
            ui_delayTimer += (uint)(Time.deltaTime * 100);

            if (ui_delayTimer >= ui_delayUntilNextBeat)
            {
                if (bd_beatList[0].us_lane == 4)
                {
                    // This will spawn a massive 4 lane box that requires space to be pressed
                    GameObject newBeat = Instantiate(go_beatBigPrefab,
                        go_laneList[bd_beatList[0].us_lane].transform.position,
                        Quaternion.identity);

                    Beat beatInfo = newBeat.GetComponent<Beat>();
                    beatInfo.s_size = Beat.Size.big;
                    beatInfo.us_lane = bd_beatList[0].us_lane;

                    ba_beatActivation.l_currentBeats.Add(newBeat);
                    PopFirstBeat();

                    if (bd_beatList.Length > 0)
                        // Resets timers for next beat
                        ui_delayUntilNextBeat = bd_beatList[0].ui_delay;
                }
                else
                {
                    // Creates a single beat in a single lane
                    GameObject newBeat = Instantiate(go_beatPrefab,
                        go_laneList[bd_beatList[0].us_lane].transform.position,
                        Quaternion.identity);

                    Beat beatInfo = newBeat.GetComponent<Beat>();
                    beatInfo.s_size = Beat.Size.big;
                    beatInfo.us_lane = bd_beatList[0].us_lane;

                    ba_beatActivation.l_currentBeats.Add(newBeat);
                    PopFirstBeat();

                    if (bd_beatList.Length > 0)
                        // Resets timers for next beat
                        ui_delayUntilNextBeat = bd_beatList[0].ui_delay;
                }
            }
        }
    }
}
