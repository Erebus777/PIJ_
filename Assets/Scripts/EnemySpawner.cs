using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    public void Update()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        if (enemyCount < 10)
        {
            xPos = Random.Range(1, 15);
            zPos = Random.Range(1, 10);
            Instantiate(theEnemy, new Vector3(xPos, 2.55f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 3;
        }
    }

}
