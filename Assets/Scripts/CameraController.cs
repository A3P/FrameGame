using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


public class CameraController : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    private Camera cam;
    private Vector3 zOffset;
    public float maxViewportDistance;
    public float minViewportDistance;
    public float zoomDelta;

    // Start is called before the first frame update
    void Start()
    {
        zOffset = transform.position;
        cam = gameObject.GetComponent<Camera>();
    }

    // LateUpdate is used here since it will also include changes made in the most recent update
    void LateUpdate()
    {
        transform.position = zOffset + (player1.transform.position + player2.transform.position)/2;
        AdjustZoom();
    }

    float GetDistance() {
        Vector2 player1Viewport = Camera.main.WorldToViewportPoint(player1.transform.position);
        Vector2 player2Viewport = Camera.main.WorldToViewportPoint(player2.transform.position);
        float distance = Vector2.Distance(player2Viewport, player1Viewport);
        Debug.Log(distance);
        return distance;
    }

    void AdjustZoom() {
        float distance = GetDistance();
        if(distance > maxViewportDistance) {
            cam.orthographicSize += zoomDelta * Time.deltaTime;
        } else if (distance < minViewportDistance && cam.orthographicSize > 1.5f) {
            cam.orthographicSize -= zoomDelta * Time.deltaTime;
        }

    }
}
