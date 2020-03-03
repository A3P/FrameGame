using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPercent : MonoBehaviour
{
    private Text percentText;
    private float percent;
    public int playerNumber; 
    // Start is called before the first frame update
    void Start()
    {
        percentText = gameObject.GetComponent<Text>();
        percent = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddPercent(float damage)
    {
        percent += damage;
        percentText.text = "Player " + playerNumber + "\n" + percent + "%";
    }
}
