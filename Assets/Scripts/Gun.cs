using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool isRotative = false;
    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0.0f;
    public Bullet bullet;
    private Vector2 rotation;
    Vector2 direction;
    float shootTimer = 0f;
    float delayTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      direction = (transform.localRotation * Vector2.right).normalized;
      if(autoShoot){
        if(delayTimer >= shootDelaySeconds){
          if(shootTimer >= shootIntervalSeconds){
            Shoot();
            shootTimer = 0;
          }
          else{
            shootTimer += Time.deltaTime;
          }
        }
        else{
          delayTimer += Time.deltaTime;
        }
      }
      if(isRotative)
        Rotate();
    }
    public void Shoot(){
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet goBullet = go.GetComponent<Bullet>();
        goBullet.direction = direction;
    }
    public void Rotate(){
      transform.Rotate(0,0,.5f);
    }
}
