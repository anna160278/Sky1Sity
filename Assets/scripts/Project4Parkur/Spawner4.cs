using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner4 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject heartPrefab;
    public GameObject[] islands;

    void Start()
    {
        islands = GameObject.FindGameObjectsWithTag("Island");

        for (int i = 0; i < islands.Length; i++) {
            Vector3 offset = new Vector3 (Random.Range(0,3), Random.Range(0, 3), Random.Range(0, 3));
            Vector3 position = islands[i].transform.position + offset;
            Instantiate(enemyPrefab, position, Quaternion.identity);
        }

        for (int i = 0; i < islands.Length; i++) {
            int rnd = Random.Range(1, 3);
            if (rnd == 1) {
                Vector3 offset = new Vector3(Random.Range(0, 3), 1, Random.Range(0, 3));
                Vector3 position = islands[i].transform.position + offset;
                Instantiate(heartPrefab, position, heartPrefab.transform.rotation);
            }
        }
    }
}
