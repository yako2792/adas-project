using UnityEngine;
using UnityEngine.UI;

public class pause_menu : MonoBehaviour
{
    int buttonState = 0;
    public GameObject resumeButton;
    public GameObject resetButton;
    public GameObject exitButton;
    public GameObject playerObject;
    public GameObject clusterCanvas;
    car_movement playerScript;
    Image resumeImage;
    Image resetImage;
    Image exitImage;

    private bool cambioPendiente = false;
    private float tiempoDeEspera = 0.5f;
    private float tiempoUltimoCambio = 0f;
    // Start is called before the first frame update
    void Start()
    {
        resumeImage = resumeButton.GetComponent<Image>();
        resetImage = resetButton.GetComponent<Image>();
        exitImage = exitButton.GetComponent<Image>();

        playerScript = playerObject.GetComponent<car_movement>();
        playerScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        LogitechGSDK.DIJOYSTATE2ENGINES rec;
        rec = LogitechGSDK.LogiGetStateUnity(0);

        checkButtonSelection(rec);
        checkButtonPressed(rec);
    }

    void checkButtonSelection(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    {
        if (rec.rgdwPOV[0]==0)
        {
            // UP
            if (!cambioPendiente && Time.time - tiempoUltimoCambio >= tiempoDeEspera)
            {
                buttonState -= 1;
                tiempoUltimoCambio = Time.time;
            }
        }
        if (rec.rgdwPOV[0]==18000)
        {
            // DOWN
            if (!cambioPendiente && Time.time - tiempoUltimoCambio >= tiempoDeEspera)
            {
                buttonState += 1;
                tiempoUltimoCambio = Time.time;
            }
        }

        if (buttonState > 2)
        {
            buttonState = 2;
        }
        if (buttonState < 0)
        {
            buttonState = 0;
        }
    }

    void checkButtonPressed(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    {
        switch (buttonState)
        {
            case (0):
            {
                resumeImage.color = Color.gray;
                resetImage.color = Color.white;
                exitImage.color = Color.white;
                if (checkButtonIsPressed(rec))
                {
                    gameObject.SetActive(false);
                    clusterCanvas.SetActive(true);
                    playerScript.enabled = true;
                }
                break;
            }
            case (1):
            {
                resumeImage.color = Color.white;
                resetImage.color = Color.gray;
                exitImage.color = Color.white;
                if (checkButtonIsPressed(rec))
                {
                    playerScript.enabled = true;
                    playerObject.transform.position = new Vector3 (34.77f,68f,50.47f);
                    playerObject.transform.rotation = Quaternion.Euler(new Vector3 (0f, 180f, 0f)); 
                    clusterCanvas.SetActive(true);
                    gameObject.SetActive(false);
                }
                break;
            }
            case (2):
            {
                resumeImage.color = Color.white;
                resetImage.color = Color.white;
                exitImage.color = Color.gray;
                if (checkButtonIsPressed(rec))
                {
                    Application.Quit();
                }
                break;
            }

        }

    }

    bool checkButtonIsPressed(LogitechGSDK.DIJOYSTATE2ENGINES rec)
    {
        bool isPressed = false;
        if (rec.rgbButtons[0] == 128)
        {
            isPressed = true;
            
        }
        return isPressed;
    }
}
