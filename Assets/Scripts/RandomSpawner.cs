using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numeroCubos = 5;

    void Update()
    {
        if (Random.Range(1, 1000) == 73 && numeroCubos > 0) 
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 10, Random.Range(-10, 11));
            Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
            numeroCubos--;
        }
    }
}