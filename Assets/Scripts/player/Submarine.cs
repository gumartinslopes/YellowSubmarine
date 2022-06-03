using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {
    public bool invencible = false;
    public int level = 1;
    public int hp = 100;
    public int score = 0;
    public int hitDmg = 5;

    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;
    private bool speedUp;
    private float moveSpeed = 5;


    private float dmgBlinkCounter = 0f;
    private float dmgInterval = 1f;
    private float dmgBlinkInterval = 0.5f;
    private bool isInvisible = false;

    private Gun[] guns;

    void Start() {
        guns = transform.GetComponentsInChildren<Gun>();
    }

    void Update() {
        //checagem de movimentação
        this.moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        this.moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        this.moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        this.moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        this.speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        //chcagem de tiro

        if (Input.GetKey(KeyCode.Space)) {
            guns[0].Shoot();
            if (level > 2) {
                guns[1].Shoot();
                guns[2].Shoot();
                if (level > 3) {
                    guns[3].Shoot();
                    guns[4].Shoot();
                }
            }

        }
        else if (Input.GetKey(KeyCode.C))
            guns[5].Shoot();
        if(isInvisible)
            dmgBlinkCounter += Time.fixedDeltaTime; 
    }

    private void FixedUpdate() {
        gameOver();
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime * 2;

        if (speedUp) {
            moveAmount *= 2;
        }

        Vector2 move = Vector2.zero;

        if (moveUp) {
            move.y += moveAmount;
        }

        if (moveDown) {
            move.y -= moveAmount;
        }

        if (moveLeft) {
            move.x -= moveAmount;
        }

        if (moveRight) {
            move.x += moveAmount;
        }

        //equalizando a velocidade diagonal com a dos outros eixos
        float moveMagnitude = Mathf.Sqrt((move.x * move.x) + (move.y * move.y));

        if (moveMagnitude > moveAmount) {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        pos += move;

        if (pos.x <= -10.7) {
            pos.x = -10.7f;
        }

        if (pos.x >= 7f) {
            pos.x = 7f;
        }

        if (pos.y <= -3.43f) {
            pos.y = -3.43f;
        }

        if (pos.y >= 3.660f) {
            pos.y = 3.66f;
        }

        transform.position = pos;
        invisible();
    }

    //colisão
    private void OnTriggerEnter2D(Collider2D collision) {
        Bullet bullet = collision.GetComponent<Bullet>();

        //Item de HP
        if (collision.gameObject.CompareTag("PowerUpHp"))
        {
            AumentarVida(collision.gameObject.GetComponent<ItemHp>().hpPlus);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("PowerUpShootingRating"))
        {
            UpShootingRate(collision.gameObject.GetComponent<ShootingRateUp>().shootIntervalSeconds);
            Destroy(collision.gameObject);
        }

        if (bullet != null) {
            if (bullet.isEnemy) {
                takeDmg(bullet.hitDmg);
                Destroy(bullet.gameObject);
            }
        }
        Destructable destructable = collision.GetComponent<Destructable>();
        if (destructable != null) {
            takeDmg(destructable.hitDmg);
            //Destroy(destructable.gameObject);
        }
    }

    private void gameOver() {
        if (hp <= 0)
            Destroy(gameObject);
    }

    private void takeDmg(int dmg) {
        if(!invencible && !isInvisible){
            hp -= dmg;
            isInvisible = true;
            
        }
    }

    private void AumentarVida(int hpUp)
    {
        hp += hpUp;
    }

    private void UpShootingRate(float ShootingRate)
    {
        guns[0].UpShootingRateGun(ShootingRate);
    }

    private void invisible(){
        if(dmgBlinkCounter <= dmgInterval && isInvisible){        
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 1f, 1f, 0.5f);
        }
        else{
            dmgBlinkCounter = 0f;
            transform.GetComponent<SpriteRenderer>().color = new Color(1, 1f, 1f, 1f);
            isInvisible = false;
        }
    }
}
