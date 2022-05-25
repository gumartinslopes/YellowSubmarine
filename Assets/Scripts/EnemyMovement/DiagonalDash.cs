using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalDash : MonoBehaviour
{
    public float moveSpeed;
    public float dashInterval;
    public float dashTime;
    public float awaitInitTime;
    public float dashDelay;
    public float gravityDelay;
    private Rigidbody2D rgbd;
    
    void Start()
    {
      dashInterval = dashInterval + dashTime;
      rgbd = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
      Vector2 pos = transform.position;
      if(Time.time > awaitInitTime  + dashDelay){
        
        if(Time.time % (dashInterval+dashDelay) + 0.7   > dashInterval + dashDelay){
          dash(pos);
        }
        else{
          floatUp(pos);
        }
      }
    }
    private void dash(Vector2 pos){
        Vector2 move = Vector2.zero;
        float moveAmount = moveSpeed * Time.fixedDeltaTime * 2;
        float moveMagnitude = Mathf.Sqrt((move.x * move.x) + (move.y * move.y));

        if (moveMagnitude > moveAmount) {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }
        pos.y += moveSpeed * Time.fixedDeltaTime;
        pos.x -= moveSpeed * Time.fixedDeltaTime;
             
        
        transform.position = pos;   
    } 
    private void floatUp(Vector2 pos){
        rgbd.AddForce(new Vector2(0f, 1f), ForceMode2D.Impulse);
        //pos.y += gravityDelay * Time.fixedDeltaTime / 5; 
        //transform.position = pos;
    }
}
