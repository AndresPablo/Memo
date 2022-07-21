using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class TimerVisual : MonoBehaviour
{
    public TextMeshProUGUI timeLabel;

    void Start()
    {
        Timer.OnTick += UpdateTimeDisplay;
    }

    private void UpdateTimeDisplay(float t)
    {
        int seconds;
        int minutes;

        minutes = (int)t/60;
        seconds = (int)t % 60;

        string newText = minutes +":" + seconds;
        timeLabel.text = newText;
    }
}
