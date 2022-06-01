using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float timeCounter = 0f;
    public float lifetime = 60f;
   
    void Start()
    {
        
    }
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter > lifetime)
        Destroy(gameObject);
    }
}
