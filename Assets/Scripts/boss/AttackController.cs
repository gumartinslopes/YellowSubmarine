using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private float timeCounter = 0f;
    private float timeAttack1 = 15.5f;
    private float timeAttack2 = 28.533f;
    private float timeAttack3 = 41.51f;
    private float timeAttack4 = 68.1f;
    private float timeAttack5 = 79.18f;
    private int currentAttack = -1;
    private GunGroup guns;

    void Start()
    {
        guns = transform.GetComponentInChildren<GunGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //SpawnGroup spawns = transform.GetComponentInChildren<SpawnGroup>();
        
        if(timeCounter < timeAttack1){
            EM1A();
            currentAttack = 0;
        }
        else if(timeCounter >= timeAttack1 && timeCounter < timeAttack2){
            EM2A();
            currentAttack = 1;
        } 
        else if(timeCounter >= timeAttack2 && timeCounter < timeAttack3){
            setupMediumAttack();
            currentAttack = 2;
        }  
        else if(timeCounter >= timeAttack3 && timeCounter < timeAttack4){
            setupHardAttack();
            currentAttack = 3;
        }  
        else if(timeCounter >= timeAttack4 && timeCounter < timeAttack5){
            setupUltraHardAttack();
            currentAttack = 4;
        } 
        else {
            setupUltraHardAttack2();
            currentAttack = 5;
        }
        
        timeCounter+= Time.deltaTime;
    }

    public void stopAttack(){
        guns.activeWeapons = 0;
        guns.globalIsRotative = false;
    }

    public void EM1A(){
        UpDown UpDownMovement = transform.parent.GetComponent<UpDown>();  
        UpDownMovement.stopInterval = 0f;

        guns.activeWeapons = 1;
        guns.globalIsRotative = false;
        guns.globalAutoShoot = true; 
        guns.globalShootIntervalSeconds = 1.5f;
        guns.globalShootDelaySeconds = 0f;
        
    }

    public void EM2A(){
        if(currentAttack !=1){
            guns.activeWeapons = 3;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 1.5f;
            guns.globalShootDelaySeconds = 0f;
        }
    }

    public void setupIziAttack(){
        if(currentAttack != 2){
            UpDown UpDownMovement = transform.parent.GetComponent<UpDown>();  
            UpDownMovement.stopInterval = 1f;

            guns.activeWeapons = 1;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 5f;
            guns.globalShootDelaySeconds = 0f;
        }
    }

    public void setupMediumAttack(){
        if(currentAttack != 2){
            UpDown UpDownMovement = transform.parent.GetComponent<UpDown>();  
            UpDownMovement.stopInterval = 1f;

            guns.activeWeapons = 5;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 1f;
            guns.globalShootDelaySeconds = 0f;
        }
    }
    public void setupHardAttack(){
        if(currentAttack != 3){
            guns.activeWeapons = 8;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 0.07f;
            guns.globalShootDelaySeconds = 0f;
        }
    }
    public void setupUltraHardAttack(){
        if(currentAttack != 4){
            disableSpawners();
            guns.activeWeapons = 8;
            guns.globalIsRotative = true;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 0.07f;
            guns.globalShootDelaySeconds = 0f;
            guns.fullRotation = true;
        }
    }
    public void setupUltraHardAttack2(){
        if(currentAttack != 5){
            Spawner []spawners = transform.GetComponentsInChildren<Spawner>();
            UpDown UpDownMovement = transform.parent.GetComponent<UpDown>();   

            UpDownMovement.moveSpeed = 20;
            UpDownMovement.maxY = 3f;
            UpDownMovement.minY = -3f;
            UpDownMovement.stopInterval = 0f;

            guns.resetRotation();
            guns.activeWeapons = 8;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 0.07f;
            guns.globalShootDelaySeconds = 0f;
            guns.fullRotation = false;

            
            spawners[0].active = true;
            spawners[1].active = true;
            spawners[2].active = true;
            spawners[3].active = true;
        }
    }

    public void disableSpawners(){
        Spawner []spawners = transform.GetComponentsInChildren<Spawner>();
        foreach (Spawner spawner in spawners)
        {   
            spawner.active = false;
        }
    }
}
