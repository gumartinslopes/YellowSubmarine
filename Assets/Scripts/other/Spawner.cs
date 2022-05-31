using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate;
    public float awaitInitTime;
    private float timeCounter = 0f;
    public float lifetime = 60f;
    
    private float nextSpawn = 0f;
    void Start()
    {

    }

    void Update()
    {
        if(timeCounter > awaitInitTime){
          if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;
            Instantiate(enemy, transform.position, enemy.transform.rotation);
          }
        }
        timeCounter += Time.deltaTime;
        checkLifetime();
    }
    private void checkLifetime(){
      if((timeCounter - awaitInitTime) > lifetime){
        Destroy(gameObject);
      }
    }
}
