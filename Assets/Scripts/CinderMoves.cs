using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinderMoves : MonoBehaviour
{
    public GameObject kindle;

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
        GameObject obj = Instantiate(kindle, casterPosition, Quaternion.identity) as GameObject;
        obj.transform.Rotate(0,0, aimAngle - 90);
        obj.GetComponent<CinderKindle>().SetDirection(obj.transform.right);
    }
}
