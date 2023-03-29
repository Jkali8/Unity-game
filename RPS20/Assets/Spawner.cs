using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject newEnemy = Instantiate(enemy, new Vector3( gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
