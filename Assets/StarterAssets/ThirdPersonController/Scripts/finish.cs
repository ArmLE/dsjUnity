using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaAlTocar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Este método se llama cuando el jugador toca el collider del prefab

        // Verificar si el objeto que tocó es el jugador
        if (other.CompareTag("Player"))
        {
            // Cambiar a la escena2
            SceneManager.LoadScene("Nivel2");
        }
    }
}
