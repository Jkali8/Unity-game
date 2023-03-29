using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamehandler : MonoBehaviour
{
    public int coinCount = 0;
    public Text text;
    public EndZone end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Collected coins: " + coinCount + "/3";
        if(coinCount == 3)
        {
            end.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
