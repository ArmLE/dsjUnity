using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numeroCubos = 5;
    public float distanciaEntreCubos = 10.0f;

    void Update()
    {
        if (numeroCubos > 0)
        {
            Vector3 randomSpawnPosition = GetRandomSpawnPosition();
            Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
            numeroCubos--;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        float minX = -9.0f;
        float maxX = 17.0f;
        float minZ = -200.0f;
        float maxZ = 230.0f;

        float x = Mathf.Round(Random.Range(minX, maxX) / distanciaEntreCubos) * distanciaEntreCubos;
        float y = 0.0f; // Otra opción es usar un valor específico de y si lo deseas
        float z = Mathf.Round(Random.Range(minZ, maxZ) / distanciaEntreCubos) * distanciaEntreCubos;

        return new Vector3(x, y, z);
    }
}
