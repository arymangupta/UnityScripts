using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{

    private bool timerActive;

    private float maxTimeOut = 5f;
    

    private float currentTime;
    public Timer(float timeOut , bool start =false){
        maxTimeOut = timeOut;
        timerActive = start;
        currentTime = maxTimeOut;
        
    }

    public void RunTimer(){
        if(!timerActive){
            Debug.LogError("Timer is not active");
            return;
        }
        if(currentTime <= 0) return;
        currentTime -=Time.deltaTime;
    }

    public bool IsTimeOut(){
        if(currentTime <= 0)
            return true;
        return false;
    }

    public void RestTimer() {
        currentTime = maxTimeOut;
        timerActive = true;
    }

    public void StopTimer(){
        timerActive = false;
    }

    public int TimeRemaining(){
        return (int) currentTime;
    }

    public void SetTimer(float time){
        maxTimeOut = time;
    }
}
