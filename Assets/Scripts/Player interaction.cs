using UnityEngine;
using UnityEngine.InputSystem;

public class Playerinteraction : MonoBehaviour
{
    [SerializeField]Transform itemSlot;
    bool slotOcupied = false;
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
    public static void AddInteract(GameObject obj)
    {
        Debug.Log("AddInteract");
        if (!instance.canInteract)
        {
            instance.canInteract = true;
            instance.interactObject=obj;
        }
    }
    public static void RemoveInteract()
    {
        Debug.Log("RemoveInteract");
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
    void Interact(InputAction.CallbackContext context)
    {
        if (!slotOcupied && holdObject!=null)
        { 
            holdObject.transform.position=itemSlot.position;
            holdObject.transform.rotation=itemSlot.rotation;
            slotOcupied=true;
            holdObject.GetComponent<Collider>().enabled=false;
            return;
        }
        if (slotOcupied)
        {
            holdObject.transform.position = transform.position;
            holdObject.transform.rotation = objectOriginalRotation;
            slotOcupied = false;
            holdObject.GetComponent <Collider>().enabled=true;
            return;
        }


    }
    void Use(InputAction.CallbackContext context)
    {
        Debug.Log("use");
        if (canInteract&&holdObject!=null)
        {
            Debug.Log(holdObject.tag);
            interactObject.GetComponent<interactScript>().Use(holdObject.tag);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
