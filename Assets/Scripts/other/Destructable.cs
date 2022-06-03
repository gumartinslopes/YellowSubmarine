using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public bool canTakeDamage = true;
    public int hitDmg = 10;
    public int hp = 1;
    public bool invicible = false;

    void Start()
    {
      hp = 1;
    }

    void Update()
    {
        gameOver();
        if(transform.position.x < 10f)
            canTakeDamage = true;
        if(transform.position.x < -10f)
          Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision){
      Bullet bullet = collision.GetComponent<Bullet>();
      if(bullet != null){
        if(canTakeDamage && !bullet.isEnemy){
            takeDmg(bullet.hitDmg);
            Destroy(bullet.gameObject);
        }
      }
      Destructable destructable = collision.GetComponent<Destructable>();
      if(destructable != null){
          takeDmg(destructable.hitDmg);
      }
    }

    private void gameOver(){
      if(hp <= 0)
          Destroy(gameObject);
    }

    private void takeDmg(int dmg){
        if(!invicible){
          hp -= dmg;
        }
    }
}
