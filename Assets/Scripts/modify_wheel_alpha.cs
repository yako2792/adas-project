using UnityEngine;

public class modify_wheel_alpha : MonoBehaviour
{
    private car_movement car_movement;
    // Update is called once per frame
    void Update()
    {
        car_movement = GameObject.Find("Vehicle").GetComponent<car_movement>();
        transform.rotation = Quaternion.Euler(0f, car_movement.alphaValue, 0f);
    }
}
