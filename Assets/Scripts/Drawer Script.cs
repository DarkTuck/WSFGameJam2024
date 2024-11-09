using UnityEngine;

public class DrawerScript : MonoBehaviour
{
    bool open;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        Playerinteraction.AddInteract(gameObject);
    }
    private void OnCollisionExit(Collision collision)
    {
        Playerinteraction.RemoveInteract();
    }
    public void Use()
    {
        if (!open)
        {
            open = true;
            Debug.Log("open");
            return;
        }
        open = false;
    }
}
