using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class get_sensor_info : MonoBehaviour
{
    public Text sensorText;
    public Dictionary<string, Vector3> objectsPosition;
    public Dictionary<string, Vector3> lastSensorInfo = new Dictionary<string, Vector3>();
    public sensor_controller[] sensorInfo;
    void Start()
    {
        sensorInfo = GetComponentsInChildren<sensor_controller>();
        objectsPosition = new Dictionary<string, Vector3>();
    }

    void Update()
    {
        for (int i = 0; i < sensorInfo.Length; i++)
        {   
            if (sensorInfo[i].objectName != "Null")
            {
                checkInVehiclesDictionary(
                    sensorInfo[i].objectName,
                    sensorInfo[i].objectPosition
                    );
            }
        }
        writeInTextEditor();
    }

    void checkInVehiclesDictionary(string name, Vector3 position)
    {
        if (!objectsPosition.ContainsKey(name))
        {
            if (name != "")
            {
                objectsPosition.Add(name, position);
            }
            // Debug.Log("Car added");
        }
        else 
        {
            objectsPosition[name] = position;
            // Debug.Log("Car modified");
        }
    }

    void writeInTextEditor()
    {
        string finalSensorText = "";
        List<string> keysToRemove = new List<string>();

        foreach (var key in objectsPosition.Keys)
        {
            if (lastSensorInfo.ContainsKey(key) && lastSensorInfo[key].Equals(objectsPosition[key]))
            {
                keysToRemove.Add(key);
            }
            else if (lastSensorInfo.ContainsKey(key) && !lastSensorInfo[key].Equals(objectsPosition[key]))
            {
                lastSensorInfo[key] = objectsPosition[key];
            }
            else
            {
                lastSensorInfo.Add(key, objectsPosition[key]);  
            }
        }
        
        foreach (var key in keysToRemove)
        {
            objectsPosition.Remove(key);
        }

        keysToRemove.Clear();

        foreach (var key in objectsPosition.Keys)
        {
            finalSensorText += key + ": " + objectsPosition[key] + "\n";
        }

        sensorText.text = finalSensorText;
    }
}
