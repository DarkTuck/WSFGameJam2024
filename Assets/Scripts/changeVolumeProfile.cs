using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class changeVolumeProfile : MonoBehaviour
{
    [SerializeField]VolumeProfile sweet,horror;
    [SerializeField] Volume volume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetHorror()
    {
        volume.profile = horror;
    }
    public void SetSweet()
    {
        volume.profile = sweet;
    }
    private void Start()
    {
        SetSweet();
    }
}
