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
        transform.rotation = new Quaternion(0, cam.rotation.y, 0, cam.rotation.w);
    }
    //[SerializeField] Transform player;
    //Transform cam;
    //private void Start()
    //{
    //    cam = Camera.main.transform;
    //}
    //private void Update()
    //{
    //    //transform.rotation = new Quaternion(0, player.rotation.y, 0, player.rotation.w);
    //    transform.rotation = Quaternion.LookRotation(transform.position, cam.position);
    //}
}
