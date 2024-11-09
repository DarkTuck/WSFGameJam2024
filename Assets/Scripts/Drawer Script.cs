using UnityEngine;

public class DrawerScript : MonoBehaviour
{
    [SerializeField] GameObject drawerItem;
    [SerializeField] Transform openPosition;
    Vector3 closePosition;
    bool open;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        Playerinteraction.AddInteract(gameObject,true);
    }
    private void OnCollisionExit(Collision collision)
    {
        Playerinteraction.RemoveInteract(true);
    }
    private void Start()
    {
        drawerItem.SetActive(false);
        closePosition=transform.position;
    }
    public void Use()
    {
        if (!open)
        {
            open = true;
            transform.position=openPosition.position;
            if (drawerItem != null)
            {
                drawerItem.SetActive(true);
            }
            Debug.Log("open");
            return;
        }
        transform.position=closePosition;
        open = false;
    }
}
