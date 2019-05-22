using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Beatmap : MonoBehaviour
{
    Beat[] b_beatList;

    public void ReadFromFile (string pLocation)
    {
        // Finds the filepath of the unityproject
        string path = Application.dataPath;
        Debug.Log(path);
        Debug.Log(path + "/Beatmaps" + pLocation);

        string[] lines = File.ReadAllLines((path + "/Beatmaps" + pLocation), System.Text.Encoding.UTF8);

        for (int i = 0; i < lines.Length; i++)
        {
            Debug.Log(lines[i]);

            if (lines == null)
                continue;

            Beat newBeat = new Beat();
            string[] data = lines[i].Split(',');
            Debug.Log(data[0] + " - " + data[1]);
            newBeat.us_Lane = (ushort)int.Parse(data[0]);
            newBeat.ui_Delay = (uint)int.Parse(data[1]);
        }
    }

    void Start ()
    {
        ReadFromFile("/test.txt");
    }
}
