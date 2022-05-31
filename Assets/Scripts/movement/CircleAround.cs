using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAround : MonoBehaviour
{
    public GameObject rotationCenter;
    public float angularSpeed, rotationRadius, angle = 0;
    private float posX, posY;

    public bool rotateRight = true; 
    void Start()
    {
        
    }

    void Update()
    {
        posX = rotationCenter.transform.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.transform.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle += Time.deltaTime * angularSpeed;

        if(angle >= 360)
            angle = 0;

    }
}
