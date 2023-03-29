using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamehandler2 : MonoBehaviour
{

    public GameObject text;
    public GameObject button1;
    public GameObject button2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Lmao");
            text.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
        }
    }


    public void PlayGame(int index)
    {
        SceneManager.LoadScene(0);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(2);
    }
}
