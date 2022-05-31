using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastyDude : MonoBehaviour
{
    public float awaitTime = 0;
    public float moveSpeed = 5;
    private float initialX = 12.44f;
    private float initialY = -2.51f;
    private float finalX = 9.5f;
    private bool goingBack = false;
    void Start()
    {
        transform.position = new Vector2(initialX, initialY);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if(pos.x <= finalX){
            goingBack = true;
        }
        pos.x += moveSpeed * Time.fixedDeltaTime * ((goingBack)?  1 :  -1);
        transform.position = pos;
        if(pos.x > 13){
                Destroy(gameObject);
        }
    }
}
