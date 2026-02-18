using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public float mouseSensitivity = 0.02f;

    public float moveSpeed = 10.0f;
    
    public KeyCode toggleLooking = KeyCode.F;

    private bool _looking;
    private bool Looking
    {
        get => _looking;
        set {
            _looking = value;
            UpdateLooking(value);
        }
    }

    void Start()
    {
        Looking = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Looking = !Looking;
        }

        transform.position += (transform.right * (Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime));
        
        transform.position += (transform.forward * (Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime));

        if (Looking)
        {
            float newRotX = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * mouseSensitivity;
            float newRotY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.localEulerAngles = new Vector3(newRotX, newRotY, 0);
        }
        
    }

    void UpdateLooking(bool state)
    {
        Cursor.visible = !state;
        Cursor.lockState = state ? CursorLockMode.Locked : CursorLockMode.None;
    }
    
}
