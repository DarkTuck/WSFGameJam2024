using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignRotationWithCamera : MonoBehaviour
{
    Transform cam;
    private void Start()
    {
        cam = Camera.main.transform;
    }
    void Update()
    {
        transform.rotation = cam.rotation;
    }
}
