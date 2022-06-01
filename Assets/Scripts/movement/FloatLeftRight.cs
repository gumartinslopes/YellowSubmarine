using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatLeftRight : MonoBehaviour
{
    public float maxX=  0f;
    public float minX = 0f;
    public float moveSpeed = 1f;
    private bool floatRight = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += moveSpeed * Time.fixedDeltaTime * ((floatRight)?1:-1);
        transform.position = pos;
        if(pos.x > maxX || pos.x < minX)
            floatRight  = ! floatRight;
    }
}
