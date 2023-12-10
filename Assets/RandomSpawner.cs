using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject cubePrefab;

    void Update()
    {
        do
        {
            StartCoroutine(Esperar());
            Debug.Log("Han pasado 5 segundos.");
            Vector3 randomSpawnPosition = new Vector3(UnityEngine.Random.Range(-30, 31), 5, UnityEngine.Random.Range(-30, 31));
            Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
        } while(cubePrefab != null);
        
    }
    bool EsMultiploDe3(DateTime tiempo)
    {
        int totalMinutos = tiempo.Hour * 60 + tiempo.Minute;
        return totalMinutos % 3 == 0;
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(20);
    }
}