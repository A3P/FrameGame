using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinderKindle : MonoBehaviour
{

    public int duration;
    public float speed;
    public float percent;
    public int stunGrowth;
    public float bkb;
    public float kbg;
    private Vector3 direction;
    private GameObject player;
    private int spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.frameCount;
    }

    public void SetOwner(GameObject player) 
    {
        this.player = player;
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
         if(spawnTime + duration < Time.frameCount) {
             Destroy(gameObject);
         } else {
             transform.position+= direction * speed;
         }
    }

        void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("The col: " + col);
        if(col.gameObject != player) {
            Debug.Log("BOOM");
            Vector3 difference = col.transform.position - transform.position;
            difference.Normalize();
            col.gameObject.GetComponent<PlayerControls>().KnockBack(difference, bkb, stunGrowth);
            Destroy(gameObject);
        }
    }
}
