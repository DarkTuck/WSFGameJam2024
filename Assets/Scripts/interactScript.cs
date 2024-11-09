using UnityEngine;

public class interactScript : MonoBehaviour
{
    [SerializeField] string exeptedTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        Playerinteraction.AddInteract(gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        Playerinteraction.RemoveInteract();
    }

    public void Use(string tag)
    {
        if (tag == exeptedTag)
        {
            Destroy(gameObject);
            Playerinteraction.RemoveInteract();
        }

    }
}
