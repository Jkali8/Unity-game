using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAreaCheck : MonoBehaviour
{
    private enemyScript enemyParent;

    private void Awake()
    {
        enemyParent = GetComponentInParent<enemyScript>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
