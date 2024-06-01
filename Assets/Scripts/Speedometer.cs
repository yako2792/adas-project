using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    //public Rigidbody target;
    public GameObject target;

    public float maxSpeed_Speedometer = 0f; // La velocidad máxima del objetivo ** EN KM/H **
    public float maxSpeed_RPM = 0f; // La velocidad máxima del objetivo ** EN KM/H **

    public float minSpeedArrowAngle_Speedometer;
    public float maxSpeedArrowAngle_Speedometer;

    public float minSpeedArrowAngle_RPM;
    public float maxSpeedArrowAngle_RPM;

    [Header("UI")]
    public Text speedLabel; // La etiqueta que muestra la velocidad;
    public RectTransform arrow_speedometer; // La flecha en el velocímetro
    public RectTransform arrow_RPM; // La flecha en el velocímetro
    public float speed_speedometer = 0.0f;
    private float speed = 0.0f;

    private void Update()
    {
        car_movement variable = target.GetComponent<car_movement>();
        speed_speedometer = variable.velocity * 3.5f;

        if (speedLabel != null)
            speedLabel.text = ((int)speed_speedometer) + " km/h";

        if (arrow_speedometer != null && maxSpeed_Speedometer > 0f)
        {
            float speedRatio_speedometer = speed_speedometer / maxSpeed_Speedometer;
            arrow_speedometer.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle_Speedometer, maxSpeedArrowAngle_Speedometer, speedRatio_speedometer));
        }

        if (arrow_RPM != null && maxSpeed_RPM > 0f)
        {
            if (speed_speedometer>0 && speed_speedometer<=17){
                maxSpeed_RPM = 15;
                minSpeedArrowAngle_RPM = 20;
                maxSpeedArrowAngle_RPM = -160;
                speed = speed_speedometer;
                 float speedRatio_RPM = speed / maxSpeed_RPM;
                arrow_RPM.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle_RPM, maxSpeedArrowAngle_RPM, speedRatio_RPM));
            }
            else if (speed_speedometer>17 && speed_speedometer<=26){
                maxSpeed_RPM = 15;
                minSpeedArrowAngle_RPM = 20;
                maxSpeedArrowAngle_RPM = -160;
                speed = speed_speedometer -10;
                 float speedRatio_RPM = speed / maxSpeed_RPM;
                arrow_RPM.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle_RPM, maxSpeedArrowAngle_RPM, speedRatio_RPM));
            }

            else if (speed_speedometer>26 && speed_speedometer<=35){
                maxSpeed_RPM = 15;
                minSpeedArrowAngle_RPM = 20;
                maxSpeedArrowAngle_RPM = -160;
                speed = speed_speedometer -19;
                 float speedRatio_RPM = speed / maxSpeed_RPM;
                arrow_RPM.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle_RPM, maxSpeedArrowAngle_RPM, speedRatio_RPM));
            }
            else if (speed_speedometer>35 && speed_speedometer<=45){
                maxSpeed_RPM = 15;
                minSpeedArrowAngle_RPM = 20;
                maxSpeedArrowAngle_RPM = -160;
                speed = speed_speedometer-28;
                 float speedRatio_RPM = speed / maxSpeed_RPM;
                arrow_RPM.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle_RPM, maxSpeedArrowAngle_RPM, speedRatio_RPM));
            }

            else if (speed_speedometer>45 && speed_speedometer<=55){
                maxSpeed_RPM = 15;
                minSpeedArrowAngle_RPM = 20;
                maxSpeedArrowAngle_RPM = -160;
                speed = speed_speedometer-38;
                 float speedRatio_RPM = speed / maxSpeed_RPM;
                arrow_RPM.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle_RPM, maxSpeedArrowAngle_RPM, speedRatio_RPM));
            }

            else {
                maxSpeed_RPM = 15;
                minSpeedArrowAngle_RPM = 20;
                maxSpeedArrowAngle_RPM = -160;
                speed = speed_speedometer-48;
                 float speedRatio_RPM = speed / maxSpeed_RPM;
                arrow_RPM.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle_RPM, maxSpeedArrowAngle_RPM, speedRatio_RPM));
            }
           
        }
    }
}
