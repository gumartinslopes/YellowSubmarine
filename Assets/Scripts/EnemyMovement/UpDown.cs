using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float moveSpeed = 5;
    private bool moveUp = true;
    public float maxY = 0;
    public float minY = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void FixedUpdate(){
        Vector2 pos = transform.position;
        if (pos.y > maxY || pos.y < minY)
            moveUp = !moveUp;
        
        pos.y += moveSpeed * Time.fixedDeltaTime * (moveUp ? 1 : -1);
        transform.position = pos;
    }
}
