using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour {
    // Attributes
    Gun[] guns;
    float moveSpeed = 5;
    int hp;
    bool invisible;
    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;
    bool speedUp;
    bool shoot;

    void Start() {
        guns = transform.GetComponentsInChildren<Gun>();
        hp = 10;
        invisible = false;
    }

    void Update() {
        //checagem de movimentação
        this.moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        this.moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        this.moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        this.moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        this.speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    
        //chcagem de tiro
        shoot = Input.GetKeyDown(KeyCode.Space);
        if(shoot){
            shoot = false;
            foreach(Gun gun in guns){
                gun.Shoot();
            }
        }
    }

    private void FixedUpdate() {
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

        if (pos.y <= -3f) {
            pos.y = -3f;
        }

        if (pos.y >= 5.0f) {
            pos.y = 5.0f;
        }

        transform.position = pos;
    }
}
