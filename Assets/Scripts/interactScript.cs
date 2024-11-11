using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interactScript : MonoBehaviour
{
    [SerializeField] string exeptedTag;
    [SerializeField] JumpscareScript jScript;
    [SerializeField] int timeTillJumpscare=2;
    [SerializeField] GameObject kurwa,blackScreen,heartKey,soundTrack;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite sprite;
    [SerializeField] Transform playerSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        Playerinteraction.AddInteract(gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        Playerinteraction.RemoveInteract();
    }
    void JumpScare()
    {
        jScript.JumpScare();
        spriteRenderer.sprite = sprite;
        StartCoroutine("lastJump");
    }
    IEnumerator lastJump()
    {
        yield return new WaitForSeconds(timeTillJumpscare);
        soundTrack.SetActive(false);
        AudioManager.instance.PlayOneShot(AudioManager.instance.Jumpscare, playerSpawn.position);
        yield return new WaitForSeconds(timeTillJumpscare);
        blackScreen.SetActive(true);
        AudioManager.instance.PlayOneShot(AudioManager.instance.Slash,playerSpawn.position);
        heartKey.SetActive(true);
        yield return new WaitForSeconds (timeTillJumpscare);
        kurwa.SetActive(false);
        blackScreen.SetActive(false);
        jScript.BackToNormal();

    }
    IEnumerator JumpScareTimer()
    {
        yield return new WaitForSeconds(timeTillJumpscare);
        JumpScare();
    }
    public void Use(string tag)
    {
        if (tag == exeptedTag)
        {
            SceneManager.LoadScene("End");
            Debug.Log("LoadScene");
            //Playerinteraction.RemoveInteract();
            return;
        }
        if (tag == "Null")
        {
            TaskScript.Write("You will need a key");
            return;
        }
        if (tag == "axe")
        {
            TaskScript.Write("This won't work");
            StartCoroutine("JumpScareTimer");
            return;
        }
        TaskScript.Write("It's not this key");
    }
}
