using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinderMoves : MonoBehaviour
{
    public GameObject kindle;
    public int kindleCD;
    private int kindleFrameCount;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void castKindle(Vector3 casterPosition, float aimAngle)
    {
        if(kindleFrameCount + kindleCD < Time.frameCount) 
        {
            GameObject obj = Instantiate(kindle, casterPosition, Quaternion.identity) as GameObject;
            obj.GetComponent<CinderKindle>().SetOwner(gameObject);
            obj.transform.Rotate(0,0, aimAngle - 90);
            obj.GetComponent<CinderKindle>().SetDirection(obj.transform.right);
            kindleFrameCount = Time.frameCount;
        }
    }
}
