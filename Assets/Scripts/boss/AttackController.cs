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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GunGroup guns = transform.GetComponentInChildren<GunGroup>();
        
        //SpawnGroup spawns = transform.GetComponentInChildren<SpawnGroup>();
        
        if(timeCounter < timeAttack1){
            setupEasyAttack(guns);
            currentAttack = 0;
        }
        else if(timeCounter >= timeAttack1 && timeCounter < timeAttack2){
            setupEasyAttack2(guns);
            currentAttack = 1;
        } 
        else if(timeCounter >= timeAttack2 && timeCounter < timeAttack3){
            setupMediumAttack(guns);
            currentAttack = 2;
        }  
        else if(timeCounter >= timeAttack3 && timeCounter < timeAttack4){
            setupHardAttack(guns);
            currentAttack = 3;
        }  
        else if(timeCounter >= timeAttack4 && timeCounter < timeAttack5){
            setupUltraHardAttack(guns);
            currentAttack = 4;
        } 
        else {
            setupUltraHardAttack2(guns);
            currentAttack = 5;
        }
        
        timeCounter+= Time.deltaTime;
    }

    private void stopAttack(GunGroup guns){
        guns.activeWeapons = 0;
        guns.globalIsRotative = false;
    }

    private void setupEasyAttack(GunGroup guns){
        
        UpDown UpDownMovement = transform.parent.GetComponent<UpDown>();  
        UpDownMovement.stopInterval = 0f;

        guns.activeWeapons = 1;
        guns.globalIsRotative = false;
        guns.globalAutoShoot = true; 
        guns.globalShootIntervalSeconds = 1.5f;
        guns.globalShootDelaySeconds = 0f;
        
    }

    private void setupEasyAttack2(GunGroup guns){
        if(currentAttack !=1){
            guns.activeWeapons = 3;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 1.5f;
            guns.globalShootDelaySeconds = 0f;
        }
    }

    private void setupMediumAttack(GunGroup guns){
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
    private void setupHardAttack(GunGroup guns){
        if(currentAttack != 3){
            guns.activeWeapons = 8;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 0.07f;
            guns.globalShootDelaySeconds = 0f;
        }
    }
    private void setupUltraHardAttack(GunGroup guns){
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
    private void setupUltraHardAttack2(GunGroup guns){
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

    private void disableSpawners(){
        Spawner []spawners = transform.GetComponentsInChildren<Spawner>();
        foreach (Spawner spawner in spawners)
        {   
            spawner.active = false;
        }
    }
}
