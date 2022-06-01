using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogerio : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float awaitTime = 3.5f;
    public float initialAwaitTime = 5f;

    private float initialAwaitTimeCounter = 0f;
    private float initialX = 9.66f;
    private float initialY = -5.13f;
    private float finalY = -3.96f;
    private bool goingBack = false;
    private float delayTimer = 0f;
    private bool count = false;
    void Start()
    {
        transform.position = new Vector2(initialX, initialY);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if(initialAwaitTimeCounter > awaitTime){
            if(pos.y > finalY){
                goingBack = true;
                count = true;
            }
            if(count)
                delayTimer += Time.deltaTime;
            
            if (!goingBack)
                pos.y += moveSpeed * Time.fixedDeltaTime;
            
            else if(goingBack && delayTimer > awaitTime)
                pos.y -= moveSpeed * Time.fixedDeltaTime;
            
            transform.position = pos;
        }
        else
            initialAwaitTimeCounter += Time.fixedDeltaTime; 
        if(pos.y < -6)
            Destroy(gameObject);
    }
}
