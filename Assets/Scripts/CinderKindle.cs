using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinderKindle : MonoBehaviour
{

    public int duration;
    public float speed;
    public float power;
    private Vector3 direction;
    private GameObject player;
    private int spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.frameCount;
        Debug.Log(Time.frameCount);
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
}
