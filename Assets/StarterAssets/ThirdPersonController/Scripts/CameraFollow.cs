using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    float distanceToPlayer = 10.0f;
    float fixedHeight = 4.0f;

    private void Update()
    {
        Vector3 targetPos = new Vector3(transform.position.x, fixedHeight, player.position.z - distanceToPlayer);
        transform.position = targetPos;
    }
}
