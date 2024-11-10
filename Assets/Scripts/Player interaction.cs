using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerinteraction : MonoBehaviour
{
    [SerializeField]Transform itemSlot,dropSlot;
    [SerializeField] TMP_Text text;
    [SerializeField] GameObject ui;
    [SerializeField] int timeTillText=5;
    [SerializeField] string textAtStart = "I need to get out now";
    bool slotOcupied = false, isDrawer = false, firstAxepickup=true;
    Actions action;
    public static Playerinteraction instance=>_instance;
    private static Playerinteraction _instance;
    public static Transform playerTransform { get; private set; }
    GameObject holdObject,interactObject;
    Quaternion objectOriginalRotation;
    bool canInteract=false;
    public static void AddObject(GameObject obj,Quaternion quaternion)
    {
        if (!instance.slotOcupied)
        {
            instance.holdObject = obj;
            instance.objectOriginalRotation = quaternion;
        }
    }
    public static void AddInteract(GameObject obj, bool isDrawer=false)
    {
        Debug.Log("AddInteract");
        if (!instance.canInteract)
        {
            if (isDrawer)
            {
                instance.isDrawer = true;
            }
            instance.canInteract = true;
            instance.interactObject=obj;
        }
    }
    public static void RemoveInteract(bool isDrawer=false)
    {
        Debug.Log("RemoveInteract");
        if (isDrawer) { instance.isDrawer = false; }
        instance.canInteract = false;
        instance.interactObject=null;
    }
    public static void RemoveObject()
    {
        if (!instance.slotOcupied)
        {
            instance.holdObject = null;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else { _instance = this; }
        playerTransform = transform;
        action= new Actions();
    
    }

    private void OnEnable()
    {
        action.Player.Enable();
        action.Player.Interact.started += Interact;
        action.Player.Use.started += Use;
    }
    private void OnDisable()
    {
        action.Player.Disable();
        action.Player.Interact.started -= Interact;
        action.Player.Use.started -= Use;
    }
    IEnumerator StartingText()
    {
        yield return new WaitForSeconds(timeTillText);
        TaskScript.Write(textAtStart);
    }
    void Interact(InputAction.CallbackContext context)
    {
        if (!slotOcupied && holdObject!=null)
        { 
            holdObject.transform.position=itemSlot.position;
            holdObject.transform.rotation=itemSlot.rotation;
            slotOcupied=true;
            if (holdObject.tag == "axe")
            {
                if (firstAxepickup)
                {
                    firstAxepickup = false;
                    ui.SetActive(true);
                    StartCoroutine("RemoveUI");
                    text.text = "What the hell is wrong with you !?";
                }
            }
            holdObject.GetComponent<Collider>().enabled=false;
            return;
        }
        if (slotOcupied)
        {
            holdObject.transform.position = dropSlot.position;
            holdObject.transform.rotation = objectOriginalRotation;
            slotOcupied = false;
            holdObject.GetComponent <Collider>().enabled=true;
            return;
        }


    }
    IEnumerator RemoveUI()
    {
        yield return new WaitForSeconds(3);
        ui.SetActive(false);
    }
    void Use(InputAction.CallbackContext context)
    {
        Debug.Log("use");
        if (canInteract&&holdObject!=null&&!isDrawer)
        {
            Debug.Log(holdObject.tag);
            interactObject.GetComponent<interactScript>().Use(holdObject.tag);
            return;
        }
        if (canInteract && holdObject == null && !isDrawer)
        {
            interactObject.GetComponent<interactScript>().Use("Null");
        }
        if (canInteract&&isDrawer)
        {
            interactObject.GetComponent<DrawerScript>().Use();
            return;
        }
        return;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("StartingText");   
    }

    // Update is called once per frame
    void Update()
    {
        if (slotOcupied)
        {
            holdObject.transform.position = itemSlot.position;
            holdObject.transform.rotation = itemSlot.rotation;
        }

    }
}
