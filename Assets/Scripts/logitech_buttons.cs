using UnityEngine;

public class logitech_buttons : MonoBehaviour
{
    public Camera camara1; // Primera cámara
    public Camera camara2; // Segunda cámara
    private bool cambioPendiente = false; // Indica si hay un cambio de cámara pendiente
    private bool camara1Activa = true; // Indica si la primera cámara está activa
    private float tiempoDeEspera = 0.5f; // Tiempo de espera antes de permitir otro cambio de cámara
    private float tiempoUltimoCambio = 0f; // Tiempo del último cambio de cámara
    
    void Update()
    {
        LogitechGSDK.DIJOYSTATE2ENGINES rec;
        rec = LogitechGSDK.LogiGetStateUnity(0);

        checkButtonStatus(rec);
    }

    public void checkButtonStatus(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    {
        // Si el botón se presiona
        if (rec.rgbButtons[8] != 0)
        {
            // Si no hay un cambio pendiente de cámara y ha pasado el tiempo de espera desde el último cambio
            if (!cambioPendiente && Time.time - tiempoUltimoCambio >= tiempoDeEspera)
            {
                // Cambia el estado de las cámaras
                camara1.gameObject.SetActive(camara1Activa);
                camara2.gameObject.SetActive(!camara1Activa);

                // Alterna el estado de la primera cámara
                camara1Activa = !camara1Activa;

                // Registra el tiempo del cambio de cámara
                tiempoUltimoCambio = Time.time;
            }
        }

        Quaternion rotacionInicialPadre = transform.rotation;

        if (rec.rgdwPOV[0] == 9000)
        {
            // Debug.Log("Right");
            Quaternion rotacionDeseada1p = rotacionInicialPadre * Quaternion.Euler(0, 45, 0);
            Quaternion rotacionDeseada3p = rotacionInicialPadre * Quaternion.Euler(0, 10, 0);

            if (camara1.isActiveAndEnabled)
            {
                camara1.transform.rotation = rotacionDeseada1p;
            }
            else if (camara2.isActiveAndEnabled)
            {
                camara2.transform.rotation = rotacionDeseada3p;
            }
        }
        else if (rec.rgdwPOV[0] == 27000)
        {
            // Debug.Log("Left");
            Quaternion rotacionDeseada1p = rotacionInicialPadre * Quaternion.Euler(0, -45, 0);
            Quaternion rotacionDeseada3p = rotacionInicialPadre * Quaternion.Euler(0, -10, 0);

            if (camara1.isActiveAndEnabled)
            {
                camara1.transform.rotation = rotacionDeseada1p;
            }
            else if (camara2.isActiveAndEnabled)
            {
                camara2.transform.rotation = rotacionDeseada3p;
            }
        }
        else
        {
            // Debug.Log("Center");
            Quaternion rotacionDeseada = rotacionInicialPadre * Quaternion.Euler(0, 0, 0);

            if (camara1.isActiveAndEnabled)
            {
                camara1.transform.rotation = rotacionDeseada;
            }
            else if (camara2.isActiveAndEnabled)
            {
                camara2.transform.rotation = rotacionDeseada;
            }
        }
    }
}
