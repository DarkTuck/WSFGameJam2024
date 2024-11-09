using UnityEngine;

public class interactScript : MonoBehaviour
{
    [SerializeField] string exeptedTag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision other)
    {
        Playerinteraction.AddInteract(gameObject);
    }
    private void OnCollisionExit(Collision other)
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
