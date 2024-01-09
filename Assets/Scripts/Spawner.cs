using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum GizmoType { Never, SelectedOnly, Always }

    public Boid prefab;
    public float spawnRadius = 10;
    public int spawnCount = 10;
    public Color colour;
    public GizmoType showSpawnRegion;

    // Nuevo atributo para definir las dimensiones del cubo
    public Vector3 cubeDimensions = new Vector3(20, 20, 20);

    void Awake()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 pos = GenerateRandomPositionInCube();
            Boid boid = Instantiate(prefab);
            boid.transform.position = pos;
            boid.transform.forward = Random.insideUnitSphere;

            boid.SetColour(colour);
        }
    }

    private void OnDrawGizmos()
    {
        if (showSpawnRegion == GizmoType.Always)
        {
            DrawGizmos();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (showSpawnRegion == GizmoType.SelectedOnly)
        {
            DrawGizmos();
        }
    }

    void DrawGizmos()
    {
        Gizmos.color = new Color(colour.r, colour.g, colour.b, 0.3f);
        Gizmos.DrawSphere(transform.position, spawnRadius);

        // Dibujar el cubo delimitador
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, cubeDimensions);
    }

    Vector3 GenerateRandomPositionInCube()
    {
        Vector3 center = transform.position;
        Vector3 halfExtents = cubeDimensions * 0.5f;

        // Generar una posición aleatoria dentro del cubo delimitador
        Vector3 randomPos = center + new Vector3(
            Random.Range(-halfExtents.x, halfExtents.x),
            Random.Range(-halfExtents.y, halfExtents.y),
            Random.Range(-halfExtents.z, halfExtents.z)
        );

        // Ajustar la posición para que esté dentro del cubo
        randomPos.x = Mathf.Clamp(randomPos.x, center.x - halfExtents.x, center.x + halfExtents.x);
        randomPos.y = Mathf.Clamp(randomPos.y, center.y - halfExtents.y, center.y + halfExtents.y);
        randomPos.z = Mathf.Clamp(randomPos.z, center.z - halfExtents.z, center.z + halfExtents.z);

        return randomPos;
    }
}
