using UnityEngine;

public class itemScript : MonoBehaviour
{
    Quaternion orginalRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orginalRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        Playerinteraction.AddObject(gameObject,orginalRotation);
        Debug.Log(gameObject + " enter");
    }
    private void OnTriggerExit(Collider other)
    {
        Playerinteraction.RemoveObject();
        Debug.Log(gameObject + " exit");
    }
}
