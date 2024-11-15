using System.Collections;
using UnityEngine;
using NaughtyAttributes;

public class JumpscareScript : MonoBehaviour
{
    [SerializeField][Foldout("timers")] int timer,movementBlockTimer;
    [SerializeField][Foldout("Horror Shit")] Transform playerSpawn;
    [SerializeField][Foldout("Horror Shit")] GameObject player;
    [SerializeField][Foldout("Horror Shit")] changeVolumeProfile changeVolumeScript;
    Coroutine jumpscareScriptCoroutine;
    bool wasTriggerd;
    private void OnTriggerExit(Collider collision)
    {
        jumpscareScriptCoroutine = StartCoroutine(JumpscareTimer());
        wasTriggerd = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (wasTriggerd)
        {
            StopCoroutine(jumpscareScriptCoroutine);
            jumpscareScriptCoroutine = null;
            wasTriggerd= false;
        }
    }
    IEnumerator JumpscareTimer()
    {
        yield return new WaitForSeconds(timer);

        JumpScare();
        StartCoroutine("ReturnToNormal");
    }
    public void JumpScare()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        changeVolumeScript.SetHorror();
        player.transform.position = playerSpawn.position;
        AudioManager.instance.PlayOneShot(AudioManager.instance.Horror, this.transform.position);
    }
    IEnumerator ReturnToNormal()
    {
        yield return new WaitForSeconds(movementBlockTimer);
        BackToNormal();
    }
    public void BackToNormal()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        changeVolumeScript.SetSweet();
    }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
