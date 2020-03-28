using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClockManager : MonoBehaviour
{

    public Text digitalClock;
    public Transform secondsHand;
    public Transform minutesHand;
    public Transform hoursHand;


    void Update()
    {
        DateTime time = DateTime.Now;

        updateAnalog(time);
        updateDigital(time);
        
    }

    private void updateAnalog(DateTime time){

        int second = time.Second;
        int minute = time.Minute;
        int hour = time.Hour;

        int secondsRot = second * -6;
        secondsHand.rotation = Quaternion.Euler(0, 0, secondsRot);

        int minutesRot =  minute * -6;
        minutesHand.rotation = Quaternion.Euler(0, 0, minutesRot);

        int hoursRot = hour * -30;
        hoursHand.rotation = Quaternion.Euler(0, 0, hoursRot);

    }

    private void updateDigital (DateTime time){

        String timeString = time.ToString("HH.mm.ss");
        
        digitalClock.text = timeString;

    }
    
}