using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject[] animals;
    private int index;
    private Vector3 position;
    private Vector3 rotation;
    public float minZ = 60;
    public float maxZ = 120;
    public float spawnX = 120;

    private void Start() {
        InvokeRepeating("SpawnLeft", 2, 3);     // Starting in 2 seconds, every 3 seconds
        InvokeRepeating("SpawnRight", 3, 2 );     // Starting in 3 seconds, every 2 seconds
    }
    void SpawnLeft() {
        position = new Vector3(-spawnX, 0, Random.Range(minZ, maxZ));
        rotation = new Vector3(0, 90, 0);
        index = Random.Range(0, animals.Length);
        Instantiate(animals[index], position, Quaternion.Euler(rotation));
    }

    void SpawnRight() {
        position = new Vector3(spawnX, 0, Random.Range(minZ, maxZ));
        rotation = new Vector3(0, -90, 0);
        index = Random.Range(0, animals.Length);
        Instantiate(animals[index], position, Quaternion.Euler(rotation));
    }
}
