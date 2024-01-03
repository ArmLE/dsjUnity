using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    float distanceToPlayer = 15.0f;

    private void Update()
    {
        Vector3 targetPos = player.position + player.forward * -distanceToPlayer;
        targetPos.y = transform.position.y; // Mantener la misma altura relativa al jugador
        transform.position = targetPos;
    }
}
