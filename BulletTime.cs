using UnityEngine;

public class BulletTime : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float timeResumeFactor = 0.5f;

    public void DoSlowMotion(){
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale*0.02f;
    }
    public void ResumeTime(){
        if(Time.timeScale ==1) return;
        
        Time.timeScale =1;
        Time.timeScale = Mathf.Clamp(Time.timeScale , 0f , 1f);
    }
}
