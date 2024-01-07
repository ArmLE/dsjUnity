using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerObstacleLevel1 : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numeroCubos = 5;
    public float distanciaEntreCubos = 10.0f;
    public float alturaCubos = 10.0f; // Nueva variable para la altura de los cubos

    void Update()
    {
        if (numeroCubos > 0)
        {
            Vector3 randomSpawnPosition = GetRandomSpawnPosition();
            randomSpawnPosition.y = alturaCubos; // Establecer la altura de los cubos
            Instantiate(cubePrefab, randomSpawnPosition, Quaternion.identity);
            numeroCubos--;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        
        float minX = -20.0f;
        float maxX = 50.0f;
        float minZ = -75.0f;
        float maxZ = 70.0f;

        float x = Mathf.Round(Random.Range(minX, maxX) / distanciaEntreCubos) * distanciaEntreCubos;
        float y = 0.0f; // Mantén la coordenada Y en 0 inicialmente
        float z = Mathf.Round(Random.Range(minZ, maxZ) / distanciaEntreCubos) * distanciaEntreCubos;

        return new Vector3(x, y, z);
    }
}
