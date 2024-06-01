
using UnityEngine;

public class rotate_sensor : MonoBehaviour
{
    public float rotationSpeed = 0f; // Velocidad de rotación del sensor tipo radar (grad/s)
    public float minRotation = 0f; // Rotación punto mínimo [-0.5 to 0.5](grad)
    public float maxRotation = 0f; // Rotación punto máximo [-0.5 to 0.5](grad)
    public float direction = 1f; // Dirección de rotación
    private float currentRotation = 0f;
    private Quaternion initialRotation; // Rotación inicial del sensor

    void Start()
    {
        initialRotation = transform.localRotation; // Guarda la rotación inicial del sensor en relación con su padre
    }

    // Update is called once per frame
    void Update()
    {
        rotateSensor();
    }

    // void rotateSensor()
    // {
    //     transform.localRotation = initialRotation; // Restaura la rotación inicial del sensor en relación con su padre
    //     transform.Rotate(Vector3.up * rotationSpeed * direction * Time.deltaTime, Space.Self); // Rota el sensor localmente
        
    //     if (transform.localRotation.eulerAngles.y >= maxRotation)
    //     {
    //         direction = -1f;
    //     }
    //     else if (transform.localRotation.eulerAngles.y <= minRotation)
    //     {
    //         direction = 1f;
    //     }
    // }
    void rotateSensor()
    {
        // Calcular la nueva rotación basada en la velocidad de rotación y el tiempo transcurrido
        float rotationAmount = rotationSpeed * direction * Time.deltaTime;

        // Actualizar la rotación actual
        currentRotation += rotationAmount;

        // Revertir la dirección si alcanza los límites
        if (currentRotation >= maxRotation || currentRotation <= minRotation)
        {
            direction *= -1f;
        }

        // Limitar la rotación dentro de los límites
        currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);

        // Aplicar la rotación al sensor
        transform.localRotation = Quaternion.Euler(0f, currentRotation, 0f);
    }

}

