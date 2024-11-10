using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class interactScript : MonoBehaviour
{
    [SerializeField] string exeptedTag;
    [SerializeField] JumpscareScript jScript;
    [SerializeField] int timeTillJumpscare=2;
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
            Playerinteraction.RemoveInteract();
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
            return;
        }
        TaskScript.Write("It's not this key");
    }
}
