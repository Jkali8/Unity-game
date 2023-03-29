using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{
    public GameObject gameHandler;
     

    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("gameHandler");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>())
        {
            gameHandler.GetComponent<gamehandler>().coinCount++;
            Destroy(gameObject);
        }
       
    }
}
