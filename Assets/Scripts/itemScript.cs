using UnityEngine;

public class itemScript : MonoBehaviour
{
    Quaternion orginalRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orginalRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Playerinteraction.AddObject(gameObject,orginalRotation);
        Debug.Log(gameObject + " enter");
    }
    private void OnCollisionExit(Collision collision)
    {
        Playerinteraction.RemoveObject();
        Debug.Log(gameObject + " exit");
    }
}
