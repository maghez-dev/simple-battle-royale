using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;

    public int enemiesCreated;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemies());
    }

    IEnumerator CreateEnemies() {
        int numberOfEnemies = 20;
        float yPosition = 0.4f;

        while (enemiesCreated < numberOfEnemies) {

            var xPosition = Random.Range(-25, 25);
            var zPosition = Random.Range(-25, 25); 

            Instantiate(theEnemy, new Vector3(xPosition, yPosition, zPosition), Quaternion.identity);

            yield return new WaitForSeconds(0.1f);

            enemiesCreated += 1;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
