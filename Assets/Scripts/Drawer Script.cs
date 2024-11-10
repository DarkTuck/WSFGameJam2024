using System.Collections;
using TMPro;
using UnityEngine;

public class DrawerScript : MonoBehaviour
{
    [SerializeField] GameObject drawerItem,UI;
    [SerializeField] Transform openPosition;
    [SerializeField] TMP_Text text;
    
    Vector3 closePosition;
    bool open,neverOpened=true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider collision)
    {
        Playerinteraction.AddInteract(gameObject,true);
        Debug.Log("addedDrawe");
    }
    private void OnTriggerExit(Collider collision)
    {
        Playerinteraction.RemoveInteract(true);
    }
    private void Start()
    {
        if (drawerItem != null)
        {
            drawerItem.SetActive(false);
        }
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
                if (neverOpened)
                {
                    neverOpened = false;
                    UI.SetActive(true);
                    StartCoroutine("RemoveUI");
                    text.text = "Where do you think you are going huh?";
                }
            }
            Debug.Log("open");
            return;
        }
        transform.position=closePosition;
        open = false;
    }
    IEnumerator RemoveUI()
    {
        yield return new WaitForSeconds(3);
        UI.SetActive(false);
    }
}
