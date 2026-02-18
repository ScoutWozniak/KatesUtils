using UnityEngine;

public class FreeCam : MonoBehaviour
{
    public float mouseSensitivity = 0.02f;
    // Update is called once per frame
    void Update()
    {
        float newRotX = transform.localEulerAngles.x + Input.GetAxis("Mouse X") * mouseSensitivity;
        float newRotY = transform.localEulerAngles.y + Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(newRotX, newRotY, 0);
        
    }
}
