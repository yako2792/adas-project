using UnityEngine;

public class MovimientoNPC : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento del NPC
    public float distanciaMaxima = 20f; // Distancia máxima que el NPC puede recorrer desde su punto de origen
    private Vector3 puntoOrigen; // Punto de origen del NPC

    void Start()
    {
        puntoOrigen = transform.position; // Guarda la posición inicial como punto de origen
    }

    void Update()
    {
        // Calcula el desplazamiento en la dirección del eje Z
        float desplazamientoZ = velocidad * Time.deltaTime;
        
        // Mueve al NPC en la dirección del eje Z
        transform.Translate(Vector3.forward * desplazamientoZ);

        // Si la distancia desde el punto de origen es mayor que la distancia máxima permitida
        if (Vector3.Distance(transform.position, puntoOrigen) >= distanciaMaxima)
        {
            // Devuelve al NPC a su punto de origen
            transform.position = puntoOrigen;
        }
    }
}
