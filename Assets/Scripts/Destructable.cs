using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < 10f)
            canBeDestroyed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        Bullet bullet = collision.GetComponent<Bullet>();
        if(canBeDestroyed & bullet != null){
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
