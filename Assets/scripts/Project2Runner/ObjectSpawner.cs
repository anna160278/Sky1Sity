using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    public int amount = 10;

    void Start() {
        for (int i = 0; i < amount; i++) {
            // Создаем объект в случайных координатах
            Vector3 randomPosition = new Vector3(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y),
                Random.Range(minPosition.z, maxPosition.z)
            );
            Instantiate(objectPrefab, randomPosition, objectPrefab.transform.rotation);
        }
    }
}
