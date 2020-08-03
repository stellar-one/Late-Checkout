using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MouseLook : MonoBehaviour
{
    private GameObject raycastedObj;
    private GameObject placeHolder;
    public GameObject RaycastedObj { get { return raycastedObj; } set { raycastedObj = value; } }
    [SerializeField] private LayerMask layerMaskInteract;
    public Image uiCrosshair;
    public Transform playerBody;
    public PlayerController PC;
    float xRotation = 0f;
    // public float Sensitivity { get { return currentSensitivity; } }
    float currentSensitivity;
    public float maxSensitivity = 100f;
    // public TextMeshProUGUI sensitivityTxt;

    void Start()
    {
        currentSensitivity = 100f;
        // sensitivityTxt.text = "Sensitivity: " + currentSensitivity.ToString();
        Cursor.lockState = CursorLockMode.Locked;
        placeHolder = new GameObject();
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * currentSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * currentSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4f, layerMaskInteract.value))
        {
            uiCrosshair.color = Color.red;
            RaycastedObj = hit.collider.gameObject;
            Collider item = hit.collider;
            PC.TryInteraction(item);
        }
        else
        {
            PC.ResetMessagePanel();
            uiCrosshair.color = Color.white;
            RaycastedObj = placeHolder;
        }
    }
}