using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemiesCreated;

    void Start()
    {
        StartCoroutine(CreateEnemies());
    }

    IEnumerator CreateEnemies()
    {
        int numberOfEnemies = 20;
        var yPosition = 0.5f;

        while (enemiesCreated < numberOfEnemies)
        {
            var xPosition = Random.Range(-25, 25);
            var zPosition = Random.Range(-25, 25);
            
            Instantiate(enemyPrefab, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);
            
            enemiesCreated++;

            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        
    }
}
