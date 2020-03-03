using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
public int playerNumber;
public float movementSpeed;
public Animator animator;
SpriteRenderer spriteRendererCmp;
private int stunTime;
private int stunLength;
private Vector3 kbDirection;
private float kb;
public GameObject percentText;
float percent {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        spriteRendererCmp = GetComponent<SpriteRenderer>();
        gameObject.GetComponent<CinderMoves>().playerNumber = this.playerNumber;    
        percent = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector;
        movementVector.x = Input.GetAxis("Horizontal"+playerNumber) * movementSpeed;
        movementVector.y = Input.GetAxis("Vertical"+playerNumber) * movementSpeed;
        Debug.Log("Player #" + playerNumber + " movementVector: " + movementVector);
        Vector3 velocity = movementVector * movementSpeed;

        SetFaceDirection(movementVector.x);

        SetIsMoving(velocity);

        if(Time.frameCount > (stunTime + stunLength)){
            transform.position += velocity;
        } else {
            Vector3 kbVeloctiy = Vector3.Lerp(kbDirection*kb, Vector3.zero, (Time.frameCount - stunTime)/stunLength);
            transform.position += kbVeloctiy;
        }

        float aimAngle = getAimAngle();

        if (Input.GetButton("Fire"+playerNumber))
        {
            Debug.Log("Fire Button is pressed for player: " + playerNumber);
            GetComponent<CinderMoves>().castKindle(transform.position , aimAngle);
        }
    }

    float getAimAngle()
    {
         // Creates an angle from the axes.
            Vector2 aimVector;
            aimVector.x = Input.GetAxis("HorizontalTurn"+playerNumber);
            aimVector.y = Input.GetAxis("VerticalTurn"+playerNumber);
            aimVector.Normalize();
            // Debug.Log(aimVector);
            float aimAngle = (Mathf.Atan2(aimVector.x, aimVector.y) * 180 / Mathf.PI);

            // Debug.Log(aimAngle);
            return aimAngle;
            // transform.eulerAngles = new Vector3 (0f, 0f, 90 - aimAngle);

            // GameObject ball = Instantiate(fireBall, transform.position, Quaternion.identity) as GameObject;
            // ball.GetComponent<CinderKindle>().SetOwner(this.gameObject);

            // nextCooldown = Time.time + cooldownTime;
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

    public void KnockBack(Vector3 kbDirection, float bkb, float kbg, int stunGrowth) {
        this.kbDirection = kbDirection;
        this.kb = bkb + (kbg * percent / 10);
        this.stunTime = Time.frameCount;
        this.stunLength  = stunGrowth;
    }

    public void addPercent(float percent) {
        this.percent += percent;
        percentText.GetComponent<PlayerPercent>().setPercent(this.percent);
    }
}