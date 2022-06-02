using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate;
    public float awaitInitTime;
    public float lifetime = 60f;
    public bool active = true;

    private float nextSpawn = 0f;
    private float timeCounter = 0f;

    void Start()
    {

    }

    void Update()
    {
        if(timeCounter > awaitInitTime){
          if(Time.time > nextSpawn && active){
            nextSpawn = Time.time + spawnRate;
            Instantiate(enemy, transform.position, enemy.transform.rotation);
          }
        }
        timeCounter += Time.deltaTime;
        checkLifetime();
    }

    private void checkLifetime(){
      if((timeCounter - awaitInitTime) > lifetime){
        active = false;
      }
    }
}
