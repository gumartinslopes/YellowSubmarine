using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGroup : MonoBehaviour
{
    public Bullet globalBullet;
    public bool globalIsRotative = false;
    public bool globalAutoShoot = false;
    public bool globalInverted = false; 
    public float globalShootIntervalSeconds = 0.5f;
    public float globalShootDelaySeconds = 0.0f;
    public int activeWeapons = 5;
    public Gun []guns;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        guns = transform.GetComponentsInChildren<Gun>();
        int upperBound = (activeWeapons < guns.Length)?activeWeapons:guns.Length;
        for (int i = 0; i < upperBound; i++){
            guns[i].bullet = globalBullet;
            guns[i].isRotative = globalIsRotative;
            guns[i].autoShoot = globalAutoShoot; 
            guns[i].inverted = globalInverted; 
            guns[i].shootIntervalSeconds = globalShootIntervalSeconds;
            guns[i].shootDelaySeconds = globalShootDelaySeconds;
        }
    }
}