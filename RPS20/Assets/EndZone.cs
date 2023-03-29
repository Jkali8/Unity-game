using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{

    public GameObject text;
    public GameObject button1;
    public GameObject button2;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.SetActive(true);
        button1.SetActive(true);
        button2.SetActive(true);
    }
}
