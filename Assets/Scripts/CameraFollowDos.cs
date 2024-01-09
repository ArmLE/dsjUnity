using UnityEngine;

public class CameraFollowDos : MonoBehaviour
{[SerializeField] Transform player;
    float distanceToPlayer = 10.0f;
    float fixedHeight = 4.0f;

    private void Update()
    {
        // Mantener la distancia constante en el eje Z (profundidad)
        float newZ = player.position.z - distanceToPlayer;

        // Mover la cámara en los ejes X e Y según la posición del jugador
        Vector3 targetPos = new Vector3(player.position.x, fixedHeight, newZ);

        // Establecer la nueva posición de la cámara
        transform.position = targetPos;
    }
}
