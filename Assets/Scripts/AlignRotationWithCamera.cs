using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
        transform.rotation = new Quaternion(0,cam.rotation.y,cam.rotation.z,cam.rotation.w);
    }
}
