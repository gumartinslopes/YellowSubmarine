using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    public bool inverted;
    float sinCenterY;
    public float amplitude = 2;//amplitude do movimento de sine wave
    public float frequency = 2;   //frequência das ocilações de sine wave
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        if(inverted)
            sin *= - 1;
        pos.y = sin + sinCenterY;
        transform.position = pos;
    }
}
