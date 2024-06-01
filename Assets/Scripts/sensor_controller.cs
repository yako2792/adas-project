using UnityEngine;

public class sensor_controller : MonoBehaviour
{
    public float maxDistance = 100f;
    public delegate void ObjectsInfoEventHandler(string name, Vector3 position);
    public event ObjectsInfoEventHandler OnObjectsInfo;
    public Vector3 objectPosition;
    public string objectName;
    // public float distanceToObject;
    
    
    void Update()
    {
        getRayEverytime(true);
        getRayWhenObject(true);
        // lookForObjects();
    }

    // My functions 
    void getRayWhenObject(bool check)
    {   
        if (check)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance))
            {   
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    objectName = hitInfo.collider.gameObject.name;
                    objectPosition = hitInfo.collider.gameObject.transform.position;
                    // distanceToObject = Vector3.Distance(transform.position, objectPosition);

                    OnObjectsInfo?.Invoke(objectName, objectPosition);
                    Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
                    // Debug.Log("Object position: " + objectPosition);
                    // Debug.Log("Object distance: " + distanceToObject);
                }
            }
            else
            {
                objectName = "Null";
                objectPosition = new Vector3 (0,0,0);
            }
        }
    }

    void getRayEverytime(bool check)
    {   
        if (check)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 100f);
        }
    }
}
