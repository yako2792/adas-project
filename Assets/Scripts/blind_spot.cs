using UnityEngine;

public class blind_spot : MonoBehaviour
{
    public GameObject leftIndicator;
    public GameObject rightIndicator;
    public GameObject leftSensor;
    public GameObject rightSensor;
    public GameObject hostVehicle;
    public float globalClosest = 8f;
    get_sensor_info leftInfo;
    get_sensor_info rightInfo;

    void Start()
    {   
        leftInfo = leftSensor.GetComponent<get_sensor_info>();
        rightInfo = rightSensor.GetComponent<get_sensor_info>();
    }

    void Update()
    {
        checkBackLeftPanel();
        checkBackRightPanel();
    }

    public void checkBackLeftPanel()
    {
        float enemyDistance;
        float closestDistance = globalClosest;
        Vector3 enemyPositionOriginal;
        
        leftIndicator.SetActive(false);
        foreach (string key in leftInfo.objectsPosition.Keys)
        {
            enemyPositionOriginal = leftInfo.objectsPosition[key];
            enemyDistance = getDistance(enemyPositionOriginal);
            if (enemyDistance < closestDistance)
            {
                leftIndicator.SetActive(true);
            } 
        }
    }

    public void checkBackRightPanel()
    {
        float enemyDistance;
        float closestDistance = globalClosest;
        Vector3 enemyPositionOriginal;

        rightIndicator.SetActive(false);
        foreach (string key in rightInfo.objectsPosition.Keys)
        {
            enemyPositionOriginal = rightInfo.objectsPosition[key];
            enemyDistance = getDistance(enemyPositionOriginal);
            if (enemyDistance < closestDistance)
            {
                rightIndicator.SetActive(true);
            }
        }
    }

    public float getDistance(Vector3 enemyPosition)
    {
        float enemyDistance = Vector3.Distance(getHostPostion(), enemyPosition);
        return enemyDistance;
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
}
