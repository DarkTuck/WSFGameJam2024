using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;
using Unity.Cinemachine;
public class PlayerMovement : MonoBehaviour
{
    Actions actions; //popiêcie do klasy z inputem
    [SerializeField][Foldout("Settings")] float speed = 5;
    [SerializeField] CinemachineCamera camera;
    
    
    //[SerializeField] Animator animator;
    //[SerializeField] PlayerWeapon weaponScript;
    //[SerializeField] ParticleSystem dustParticle;
    private Rigidbody rb;
    private InputAction move; //odbiera input z akcji move
    // Start is called before the first frame update
    private void OnEnable()
    {
        //g³ównie popina input do wartoœci w skrypcie
        actions.Player.Enable();
        move = actions.Player.Move;
        actions.Player.Move.started += changeCamera;
        //camera = cameraObject.GetComponent<CinemachineCamera>();
    }
    private void OnDisable()
    {
        //zwalnianie ramu.exe
        actions.Player.Disable();
    }

    private void Awake()
    {
        //Jebaæ rêczne popinaie
        rb = GetComponent<Rigidbody>();
        actions = new Actions();
        camera.Lens.ModeOverride = LensSettings.OverrideModes.Orthographic;
        //weaponScript = GetComponentInChildren<PlayerWeapon>();

    }
    void changeCamera(InputAction.CallbackContext context)
    {
        camera.Lens.ModeOverride = LensSettings.OverrideModes.None;
        actions.Player.Move.started -= changeCamera;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection=new Vector3(move.ReadValue<Vector2>().x,0,move.ReadValue<Vector2>().y);
        transform.Translate(moveDirection*speed, Space.Self);
    }
    //SEX NIE ISTNIEJE
}
