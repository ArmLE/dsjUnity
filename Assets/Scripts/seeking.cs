using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeking : MonoBehaviour
{
    // Velocidad del objeto
    public float speed = 5.0f;
    // Precisión
    public float accuracy = 0.01f;

    // Método para buscar el objetivo
    void Seek(Transform target)
    {
        // Verificar si el objetivo no es nulo
        if (target == null)
        {
            Debug.LogWarning("El objetivo es nulo. No se puede buscar.");
            return;
        }

        // Calcular la dirección hacia el objetivo
        Vector3 direction = (target.position - transform.position).normalized;

        // Calcular la rotación hacia el objetivo
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        // Aplicar la rotación gradualmente
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);

        // Mover hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Método llamado en cada fotograma
    void Update()
    {
        // Encontrar el objeto "Player" por su etiqueta
        GameObject player = GameObject.FindWithTag("Player");

        // Llamar al método Seek con el objeto "Player" como objetivo
        Seek(player.transform);
    }
}
