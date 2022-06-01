using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private float timeCounter = 0f;
    public float timeAttack1 = 10f;
    public float timeAttack2 = 20f;
    public float timeAttack3 = 30f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GunGroup guns = transform.GetComponentInChildren<GunGroup>();
        if(timeCounter < timeAttack1){
            guns.activeWeapons = 1;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalInverted = true; 
            guns.globalShootIntervalSeconds = 1.5f;
            guns.globalShootDelaySeconds = 0f;
        }
        else if(timeCounter >= timeAttack1 && timeCounter < timeAttack2){
            guns.activeWeapons = 2;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalInverted = true; 
            guns.globalShootIntervalSeconds = 1.5f;
            guns.globalShootDelaySeconds = 0f;
        } 
        else if(timeCounter >= timeAttack2 && timeCounter < timeAttack3){
            guns.activeWeapons = 3;
            guns.globalIsRotative = true;
            guns.globalAutoShoot = true; 
            guns.globalInverted = true; 
            guns.globalShootIntervalSeconds = 0.1f;
            guns.globalShootDelaySeconds = 0f;
        }  
        else{
            guns.activeWeapons = 5;
            guns.globalIsRotative = true;
            guns.globalAutoShoot = true; 
            guns.globalInverted = true; 
            guns.globalShootIntervalSeconds = 0.1f;
            guns.globalShootDelaySeconds = 0f;
        }
        timeCounter+= Time.deltaTime;
    }
}
