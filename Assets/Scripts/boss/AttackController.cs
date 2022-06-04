using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    
    public int attack = 0;
    
    private Observer obs;
    private float []attackIntervals;
    public float []attackTimes;
    private float timeCounter = 0f;
    private float timeAttack1 = 15.5f;
    private float timeAttack2 = 28.533f;
    private float timeAttack3 = 41.51f;
    private float timeAttack4 = 68.1f;
    private float timeAttack5 = 79.18f;
    private float iaTimeStart = 84.18f;
    private int currentAttack = -1;
    private GunGroup guns;
    Spawner[] spawners;

    void Start()
    {
        guns = transform.GetComponentInChildren<GunGroup>();
        spawners = transform.GetComponentsInChildren<Spawner>();
        obs = transform.GetComponentInChildren<Observer>();
        transform.parent.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
    
    // Update is called once per frame
    void Update()
    {   
        
        // //chooseAttack();
        if(timeCounter < timeAttack1){
            EM1A();
        }
        else if(timeCounter >= timeAttack1 && timeCounter < timeAttack2){
            EM2A();
        } 
        else if(timeCounter >= timeAttack2 && timeCounter < timeAttack3){
            NM1A();
        }  
        else if(timeCounter >= timeAttack3 && timeCounter < timeAttack4){
            HM1A();
        }  
        else if(timeCounter >= timeAttack4 && timeCounter < timeAttack5){
            HM2A();
        } 
        else if(timeCounter >= timeAttack5 && timeCounter < iaTimeStart){
            HM3A();
        } 
        
        timeCounter+= Time.deltaTime;
    }
    
    private void chooseAttack(){
        switch(attack){
            case 0: 
                EM1A();
                break;
            case 1:
                EM2A();
                break;
            case 2:
                EM3A();
                break;
            case 3: 
                NM1A();
                break;
            case 4:
                NM2A();
                break;
            case 5:
                NM3A();
                break;
            case 6: 
                HM1A();
                break;
            case 7: 
                HM2A();
                break;
            case 8:
                HM3A();
                break;
            default:
                stopAttack();   
                break;
        }
    }

    public void stopAttack(){
        guns.activeWeapons = 0;
        guns.globalIsRotative = false;
        currentAttack = -1;
        disableSpawners();
        
    }
    //--------------------------------------------------------------------------------------------
    //IZI MODE

    public void EM1A(){
        if(currentAttack != 0){
            UpDown UpDownMovement = transform.parent.GetComponent<UpDown>();  
            UpDownMovement.stopInterval = 0f;

            guns.activeWeapons = 1;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 1.5f;
            guns.globalShootDelaySeconds = 0f;

            disableSpawners();

            //transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.244f, 0.186f, 0.229f, 1f);
            currentAttack = 0;

            spawners[1].active = true;
        }
    }

    public void EM2A(){
        if(currentAttack != 1){
            UpDown UpDownMovement = transform.parent.GetComponent<UpDown>(); 
            UpDownMovement.stopInterval = 0f;

            guns.activeWeapons = 3;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 1.5f;
            guns.globalShootDelaySeconds = 0f;
            //transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.192f, 0.95f, 0.512f, 1f);
            disableSpawners();
            currentAttack = 1;
        }
    }

    public void EM3A(){
        if(currentAttack != 2){
            UpDown UpDownMovement = transform.parent.GetComponent<UpDown>();  
            UpDownMovement.stopInterval = 1f;
            
            spawners[0].active = true;

            guns.activeWeapons = 3;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 1f;
            guns.globalShootDelaySeconds = 0f;
           // transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.203f, 0.47f, 0.235f, 1f);
            currentAttack = 2;
        }
    }
    //____________________________________________________________________________________________

    //NORMAL MODE

    public void NM1A(){
        if(currentAttack != 3){
            UpDown UpDownMovement = transform.parent.GetComponent<UpDown>();  
            UpDownMovement.stopInterval = 1f;

            spawners[0].active = true;
            spawners[1].active = true;

            guns.activeWeapons = 5;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 1f;
            guns.globalShootDelaySeconds = 0f;
            //transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.162f, 0.186f, 0.162f, 1f);
            currentAttack = 3;
        }
    }

    public void NM2A()
    {
        if(currentAttack != 4){
            spawners[0].active = true;
            spawners[1].active = true;
            spawners[2].active = true;
            spawners[4].active = true;

            guns.activeWeapons = 5;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 0.5f;
            guns.globalShootDelaySeconds = 0f;

            //transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.160f, 0.212f, 0.108f, 1f);
            currentAttack = 4;
        }
    }

    public void NM3A()
    {
        if(currentAttack != 5){
            guns.activeWeapons = 5;

            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 0.5f;
            guns.globalShootDelaySeconds = 0f;

            spawners[0].active = true;
            spawners[1].active = true;
            spawners[2].active = true;
            spawners[3].active = true;
            
            //transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.10f, 0.66f, 0.11f, 1f);
            currentAttack = 5;
        }
    }
    //___________________________________________________________________________________________________

    //HARD MODE

    public void HM1A()
    {
        if(currentAttack != 6){
            disableSpawners();
            guns.activeWeapons = 8;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 0.07f;
            guns.globalShootDelaySeconds = 0f;
            guns.fullRotation = true;
            //transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.191f, 0.33f, 0.104f, 1f);
            currentAttack = 6;
        }
    }

    public void HM2A()
    {
        if(currentAttack != 7){
            guns.activeWeapons = 3;
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

            spawners[0].spawnRate = 1;
            spawners[1].spawnRate = 1;
            spawners[2].spawnRate = 1;

           //transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.168f, 0.34f, 0.34f, 1f);
            currentAttack = 7;
        }
    }

    public void HM3A()
    {
        if(currentAttack != 8){
            guns.activeWeapons = 5;
            guns.globalIsRotative = true;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 0.07f;
            guns.globalShootDelaySeconds = 0f;
            guns.fullRotation = true;
            spawners[0].active = true;
            spawners[1].active = true;
            spawners[2].active = true;
            spawners[3].active = true;
            spawners[4].active = true;
            spawners[5].active = true;

            spawners[0].spawnRate = 1;
            spawners[2].spawnRate = 1;
            
            //transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.255f, 0.0f, 0.0f, 1f);
        }
    }

    //________________________________________________________________________________________________________

    public void disableSpawners(){
        foreach (Spawner spawner in spawners)
        {   
            spawner.active = false;
            spawner.spawnRate = 10;
        }
    }

    public void reset(){
            UpDown UpDownMovement = transform.parent.GetComponent<UpDown>();   

            UpDownMovement.moveSpeed = 5;
            UpDownMovement.maxY = 1.63f;
            UpDownMovement.minY = -1.42f;
            UpDownMovement.stopInterval = 0f;
            UpDownMovement.stopInterval = 2f;
            UpDownMovement.suavize = true;

            guns.activeWeapons = 0;
            guns.globalIsRotative = false;
            guns.globalAutoShoot = true; 
            guns.globalShootIntervalSeconds = 1.5f;
            guns.globalShootDelaySeconds = 0f;
            guns.fullRotation = true;


            //transform.parent.GetComponent<SpriteRenderer>().color = new Color(1f,1f, 1f, 1f);
            currentAttack = -1;
            disableSpawners();
    }
}
