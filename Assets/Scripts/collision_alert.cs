using UnityEngine;
using UnityEngine.UI;

public class collision_alert : MonoBehaviour
{
    public GameObject hostVehicle;
    public GameObject sensorFrontLeft;
    public GameObject sensorFrontRight;
    public GameObject sensorBackLeft;
    public GameObject sensorBackRight;

    public GameObject lidarFront;
    public GameObject lidarBackLeft;
    public GameObject lidarBackRight;

    get_sensor_info frontInfo;
    get_sensor_info backLeftInfo;
    get_sensor_info backRightInfo;
    private Image sfl_image;
    private Image sfr_image;
    private Image sbl_image;
    private Image sbr_image;
    Color colorYellow = new Color(1.0f, 0.75f, 0.6f);
    Color colorOrange = new Color(1.0f, 0.5f, 0f);
    Color colorRed = new Color(1.0f, 0f, 0f);


    void Start() 
    {
        frontInfo = lidarFront.GetComponent<get_sensor_info>();
        backLeftInfo = lidarBackLeft.GetComponent<get_sensor_info>();
        backRightInfo = lidarBackRight.GetComponent<get_sensor_info>();

        sfl_image = sensorFrontLeft.GetComponent<Image>();
        sfr_image = sensorFrontRight.GetComponent<Image>();
        sbl_image = sensorBackLeft.GetComponent<Image>();
        sbr_image = sensorBackRight.GetComponent<Image>();
    }
    
    void Update()  
    {
        checkFrontPanel();
        checkBackLeftPanel();
        checkBackRightPanel();
    }

    public void checkFrontPanel()
    {
        float enemyDistance; 
        float closestDistance = 100;
        Vector3 enemyPositionOriginal = Vector3.zero;
        Vector3 enemyPositionTransform;
        Color colorState;

        foreach (string key in frontInfo.objectsPosition.Keys)
        {
            enemyPositionOriginal = frontInfo.objectsPosition[key];
            enemyDistance = getDistance(enemyPositionOriginal);
            if (enemyDistance < closestDistance)
            {
                closestDistance = enemyDistance;
            }
        }
        enemyPositionTransform = transformVector(enemyPositionOriginal, hostVehicle.transform.rotation.eulerAngles.y);
        colorState = getColorState(closestDistance);
        getSensorLedFront(enemyPositionTransform, colorState);
    }

    public void checkBackLeftPanel()
    {
        float enemyDistance;
        float closestDistance = 100;
        Vector3 enemyPositionOriginal;
        Color colorState;

        foreach (string key in backLeftInfo.objectsPosition.Keys)
        {
            enemyPositionOriginal = backLeftInfo.objectsPosition[key];
            enemyDistance = getDistance(enemyPositionOriginal);
            if (enemyDistance < closestDistance)
            {
                closestDistance = enemyDistance;
            }
        }
            colorState = getColorState(closestDistance);
            sbl_image.color = colorState;
    }
    public void checkBackRightPanel()
    {
        float enemyDistance;
        float closestDistance = 100;
        Vector3 enemyPositionOriginal;
        Color colorState;

        foreach (string key in backRightInfo.objectsPosition.Keys)
        {
            enemyPositionOriginal = backRightInfo.objectsPosition[key];
            enemyDistance = getDistance(enemyPositionOriginal);
            if (enemyDistance < closestDistance)
            {
                closestDistance = enemyDistance;
            }
        }
            colorState = getColorState(closestDistance);
            sbr_image.color = colorState;
    }

    public Vector3 getHostPostion()
    {
        Vector3 hostPosition = new Vector3 (
            hostVehicle.transform.localPosition.x,
            hostVehicle.transform.localPosition.y,
            hostVehicle.transform.localPosition.z
        );
        return hostPosition;
    }

    public Vector3 transformVector(Vector3 globalVector, float angle)
    {
        if (angle > 180f)
        {
            angle -= 360f;
        }

        Matrix4x4 rotationMatrix = Matrix4x4.Rotate(Quaternion.Euler(0f,-angle,0f));
        Vector3 hostPosition = getHostPostion();
        Vector3 localVector = globalVector - hostPosition;
        localVector = rotationMatrix.rotation * localVector;
        Debug.Log(localVector);
        return localVector;
    }

    public float getDistance(Vector3 enemyPosition)
    {
        float enemyDistance = Vector3.Distance(getHostPostion(), enemyPosition);
        return enemyDistance;
    }

    public Color getColorState(float closestDistance)
    {
        Color colorState = Color.white;
    
        if (closestDistance < 10)
        {
            // Debug.Log("Muy cerca! " + closestDistance);
            colorState = colorRed;
        }
        else
        {
            if (closestDistance < 25)
            {
                // Debug.Log("Cerca " + closestDistance);
                colorState = colorOrange;
            }
            else
            {
                if (closestDistance < 50)
                {
                    // Debug.Log("Lejos " + closestDistance);
                    colorState = colorYellow;
                }
                else
                {
                    colorState = Color.white;
                    // Debug.Log("Muy lejos " + closestDistance);
                }
            }
        }
        if (closestDistance<=0)
        {
            colorState = Color.white;
        }
        return colorState;
    }

    public void getSensorLedFront(Vector3 enemyPosition, Color colorState)
    {
        // Debug.Log(enemyPosition);
        if (enemyPosition.x < 0)
        {
            sfl_image.color = colorState;
            sfr_image.color = Color.white;
        }
        if (enemyPosition.x > 0)
        {
            sfl_image.color = Color.white;
            sfr_image.color = colorState;
        }
        if (enemyPosition.x == 0)
        {
            sfl_image.color = colorState;
            sfr_image.color = colorState;
        }

    }
}
