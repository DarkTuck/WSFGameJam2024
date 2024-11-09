using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0, cameraTransform.rotation.y, 0, cameraTransform.rotation.w);
    }
}
