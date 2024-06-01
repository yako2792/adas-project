using UnityEngine;

public class car_movement : MonoBehaviour
{
    // Vehicle parameters
    public float acceleration = 3.4722f; // Vehicle acceleration (m/s2)
    public float maxSpeed = 61.1111f; // Max vehicle velocity (m/s)
    public float maxReverseSpeed = 15.8333f; // Max vehicle reverse velocity (m/s)
    public float brakePower = 50f; // Break power (m/s2)
    public float friction = 0f; // Dynamic friction (m/s2)
    public float batalla = 2.6f; // Vehicle wheelbase (m)

    // Steering wheel variables
    public float wheelValues = 0f; // Wheel lectures (-32767 to 32767)
    public float alphaValue = 0f; // Wheel rotation angle (-45 to 45)
    public float distanciaEjeRotacion = 0f; // Rotational axis distance (m)
    public float pedalPressed = 32767f; // Brake pedal values (32767 to -32767)
    public Vector3 globalRotationalAxis; 

    public GameObject pauseCanvas;
    public GameObject clusterCanvas;

    // Valores privados
    public float velocity = 0f; // Instant vehicle velocity (m/s)


    void Update()
    {
        // Get Wheel Lectures
        LogitechGSDK.DIJOYSTATE2ENGINES rec;
        rec = LogitechGSDK.LogiGetStateUnity(0);

        // Check for events
        checkAccelerate(rec);
        checkReverse(rec);
        checkBrake(rec);
        checkRotation(rec);
        if (rec.rgbButtons[6] == 128)
        {
            checkPauseMenu();
        }
    }

    // Mathematical models
    float getPedalPression(float pedalValues)
    {
        float arguments = (pedalValues - 32767)/(32767);
        float pedalPression = - ((Mathf.Exp(arguments)-Mathf.Exp(-arguments))/(Mathf.Exp(arguments)+Mathf.Exp(-arguments)));
        return pedalPression;
    }
    float wheelToAlpha (float lectures)
    {
        float alpha = 0.00137333f * lectures;
        return alpha;
    }
    float getDistanciaEjeRotacion (float alpha) 
    {
        float angleInRadians = alpha * Mathf.Deg2Rad;
        float distancia = (Mathf.Cos(angleInRadians)/Mathf.Sin(angleInRadians))*batalla;

        return distancia;
    }
    // Movements
    void checkAccelerate(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    {
        // Acelerador
        if (rec.rgbButtons[12] != 0 && getPedalPression(rec.lY) != 0)
        {
            float accelerationThisFrame = getPedalPression(rec.lY) * acceleration * Time.deltaTime;
            velocity += accelerationThisFrame;
            if (velocity > maxSpeed)
            {
                velocity = maxSpeed;
            }
        }

        // Friccion
        else if (getPedalPression(rec.lY) == 0)
        {   
            float frictionThisFrame = friction * Time.deltaTime;
            if (velocity > 1f)
            {
                velocity -= frictionThisFrame;
            }
            else if (velocity < -1f)
            {
                velocity += frictionThisFrame;
            }
            else
            {
                velocity = 0f;
            }
        }
    }
    void checkReverse(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    {
        // Reversa
        if (rec.rgbButtons[17] != 0)
        {
            float accelerationThisFrame = getPedalPression(rec.lY) * acceleration * Time.deltaTime;
            velocity -= accelerationThisFrame;
            if (velocity > maxReverseSpeed)
            {
                velocity = maxReverseSpeed;
            }
        }
    }
    void checkBrake(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    {
        // Freno
        if (getPedalPression(rec.lRz) != 0)
        {
            float brakeThisFrame =  getPedalPression(rec.lRz) * brakePower * Time.deltaTime;


            if (velocity > 1f)
            {
                velocity -= brakeThisFrame;
            }
            else if (velocity < -1f)
            {
                velocity += brakeThisFrame;
            }
            else 
            {
                velocity = 0;
            }
        }
    }
    void checkRotation(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    {
        wheelValues = rec.lX;

        // Write values to alpha
        alphaValue = wheelToAlpha(wheelValues);
        distanciaEjeRotacion = getDistanciaEjeRotacion(alphaValue);

        
        // Comienza el movimiento
        float displacementThisFrame = velocity * Time.deltaTime;
        if (distanciaEjeRotacion == 0f || float.IsInfinity(distanciaEjeRotacion))
        {
            // Si el eje de rotación es 0 o infinito
            transform.position += transform.forward * displacementThisFrame;
        }
        else 
        {
            // De lo contrario
            Vector3 localRotationalAxis = new Vector3(distanciaEjeRotacion, 0f, -0.6f);
            globalRotationalAxis = transform.TransformPoint(localRotationalAxis);
            // Calculamos el desplazamiento angular
            float angularDisplacement = (displacementThisFrame*360.0f)/(2.0f * Mathf.PI * distanciaEjeRotacion);
            // Nos desplazamos
            transform.RotateAround(globalRotationalAxis, Vector3.up, angularDisplacement);
        }
    }

    void checkPauseMenu()
    {
        pauseCanvas.SetActive(true);
        clusterCanvas.SetActive(false);
    }
}
