using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float moveSpeed = 5;
    private bool moveUp = true;
    public float maxY = 0;
    public float minY = 0;
    private bool stopped = false;
    public int stopPos = 0;
    public bool suavize = false;
    public float stopInterval = 0;
    private float stopTimer = 0;
    
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
            
            if (pos.y > maxY || pos.y < minY)
                moveUp = !moveUp;
            if(suavize && (pos.y > (maxY - maxY * 20 / 100) || pos.y < (minY - minY * 20 / 100))){
                pos.y += moveSpeed/4 * Time.fixedDeltaTime * (moveUp? 1: - 1); 
            }
            else{
                pos.y += moveSpeed * Time.fixedDeltaTime * (moveUp ? 1 : -1);
            }
            transform.position = pos;
        }
    }
    private void checkStop(Vector2 pos){
        if((int)pos.y == stopPos && stopTimer <= stopInterval){
            stopped = true;
            stopTimer +=Time.deltaTime;
        }
        else{
            stopped = false;
        }
    }
}
