using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Beatmap : MonoBehaviour
{
    private Beatdata[] bd_beatList;

    private uint ui_delayUntilNextBeat;
    private uint ui_delayTimer;

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

    void Start ()
    {
        // Initlialise variables
        ui_delayTimer = 0;

        // Test read
        ReadFromFile("/test.txt");
    }

    private void Update()
    {
        // Converts the deltatime to milliseconds and increments timer by it
        ui_delayTimer += (uint)(Time.deltaTime * 1000);
    }
}
