using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationRate = 2f;
    public float timeOut = 5f;
    public int randomNumber = 10;

    private Quaternion myRotation;
    private int flipRotation = 1;

    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(timeOut , true);
        myRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer.RunTimer();
        RotateAroundZ();
        FlipRotation();
    }

    void RotateAroundZ(){
        transform.Rotate(Vector3.forward*rotationRate*flipRotation*Time.deltaTime);
    }

    void FlipRotation(){
        if(timer.IsTimeOut()){
            int rand = Random.Range(0 ,randomNumber);
            if(rand < randomNumber){
                flipRotation*=-1;
            }
            timer.RestTimer();
        }
    }
}
