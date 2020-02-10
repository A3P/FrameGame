using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1Controls : MonoBehaviour
{
public int playerNumber;
public float movementSpeed;
public Animator animator;

SpriteRenderer spriteRendererCmp;

    // Start is called before the first frame update
    void Start()
    {
        spriteRendererCmp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector;
        movementVector.x = Input.GetAxis("Horizontal"+playerNumber) * movementSpeed;
        movementVector.y = Input.GetAxis("Vertical"+playerNumber) * movementSpeed;
        Vector3 velocity = movementVector * movementSpeed;
        
        SetFaceDirection(movementVector.x);

        SetIsMoving(velocity);

        transform.position += velocity;
    }

    // Determines if the player is moving for the sprite animation transition
    void SetIsMoving(Vector3 velocity) {
        bool isMoving = (velocity == Vector3.zero) ? false : true; 
            animator.SetBool("isMoving", isMoving);
    }

    // Flips the sprite based on the horizontal axis input
    void SetFaceDirection(float x) {
        if(x>0){
            spriteRendererCmp.flipX = true;
        } else if(x<0) {
            spriteRendererCmp.flipX = false;
        }
    }
}