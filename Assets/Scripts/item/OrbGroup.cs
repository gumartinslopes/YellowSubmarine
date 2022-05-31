using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGroup : MonoBehaviour
{
    CircleAround[] orbs;
    public GameObject rotationCenter;
    public float angularSpeed;
    public float rotationRadius;
    void Start()
    {
        orbs = transform.GetComponentsInChildren<CircleAround>();
        foreach (CircleAround orb in orbs){
            orb.rotationCenter = rotationCenter;
            orb.angularSpeed = angularSpeed;
            orb.rotationRadius = rotationRadius;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
