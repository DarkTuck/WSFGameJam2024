using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;
public class PlayerMovement : MonoBehaviour
{
    Actions actions; //popi�cie do klasy z inputem
    [SerializeField][Foldout("Settings")] float speed = 5;
    
    //[SerializeField] Animator animator;
    //[SerializeField] PlayerWeapon weaponScript;
    //[SerializeField] ParticleSystem dustParticle;
    private Rigidbody rb;
    private InputAction move; //odbiera input z akcji move
    // Start is called before the first frame update
    private void OnEnable()
    {
        //g��wnie popina input do warto�ci w skrypcie
        actions.Player.Enable();
        move = actions.Player.Move;
    }
    private void OnDisable()
    {
        //zwalnianie ramu.exe
        actions.Player.Disable();
    }

    private void Awake()
    {
        //Jeba� r�czne popinaie
        rb = GetComponent<Rigidbody>();
        actions = new Actions();
        //weaponScript = GetComponentInChildren<PlayerWeapon>();

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