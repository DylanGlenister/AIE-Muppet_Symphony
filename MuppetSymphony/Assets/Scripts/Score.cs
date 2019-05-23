using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private uint ui_score { get; set; }

    public void AddScore (uint pValue)
    {
        ui_score += pValue;
        Debug.Log(ui_score);
    }

    public void SubtractScore (uint pValue)
    {
        if (pValue > ui_score)
            ui_score = 0;
        else
            ui_score -= pValue;

        Debug.Log(ui_score);
    }

    // Start is called before the first frame update
    void Start ()
    {
        ui_score = 0;
        Debug.Log(ui_score);
    }

    // Update is called once per frame
    void Update ()
    {
        
    }
}
