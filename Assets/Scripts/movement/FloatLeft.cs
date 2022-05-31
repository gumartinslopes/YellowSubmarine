using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatLeft : MonoBehaviour
{
    public float moveSpeed = 5;
    public int stopPos = 0;
    public float stopInterval = 0;
    private float stopTime = 0;
    public bool stopped = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void FixedUpdate(){
        Vector2 pos = transform.position;
        checkStop(pos);
        if(!stopped){
            pos.x -= moveSpeed * Time.fixedDeltaTime;
            transform.position = pos;
            if(pos.x < -22)
                Destroy(gameObject);
        }

    }

    private void checkStop(Vector2 pos){
        if((int)pos.x == stopPos && stopTime <= stopInterval){
            stopped = true;
            stopTime +=Time.deltaTime;
        }
        else{
            stopped = false;
        }
    }
}
