using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool isRotative = false;
    public bool autoShoot = false;
    public bool inverted = false; 
    public bool rotateRight = true;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0.0f;
    public Bullet bullet;
    public float minAngle = 0f;
    public float maxAngle = 0f;

    

    private Vector2 rotation;
    private Vector2 direction;
    private float shootTimer = 0f;
    private float delayTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
      //transform.Rotate(0,0,maxAngle);
    }

    // Update is called once per frame
    void Update()
    {

      direction = (transform.localRotation * ((inverted)?Vector2.left:Vector2.right)).normalized;
      if(autoShoot){
        Shoot();
      }

      
      
      if(isRotative)
        Rotate();
    }

    public void Shoot(){
      if(delayTimer >= shootDelaySeconds){
          if(shootTimer >= shootIntervalSeconds){
            GameObject go = Instantiate(bullet.gameObject, new Vector2(transform.position.x, transform.position.y-1.4f), Quaternion.identity);
            Bullet goBullet = go.GetComponent<Bullet>();
            goBullet.direction = direction;
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

    public void Rotate(){
      if(isRotative){
        if(transform.localRotation.z <= minAngle/100 || transform.localRotation.z > maxAngle/100){
          //Debug.Log("Z" + transform.localRotation.z);
          rotateRight = !rotateRight;
        }
        transform.Rotate(0,0,.5f * ((rotateRight)?1f:-1f));
      }
    }
}
