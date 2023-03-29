using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject skeletonPrefab;
    // Start is called before the first frame update

    public float skeletonInterval = 3.5f;
    void Start()
    {
        StartCoroutine(spwanSkeleton(skeletonInterval, skeletonPrefab));
    }

    // Update is called once per frame
    private IEnumerator spwanSkeleton(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-20f, 20f), -1.8f), Quaternion.identity);
        StartCoroutine(spwanSkeleton(interval, enemy));
    }

}
