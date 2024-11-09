using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
public class TaskScript : MonoBehaviour
{
    [SerializeField] TMP_Text _tmpProText;
    public string writer;
    [SerializeField]string text1, text2;
    public bool write;
    [SerializeField] float delayBeforeStart = 0f, delayBeforeEnd = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;
    Coroutine typing;
    IEnumerator TypeWriterTMP()
    {
        bool specialChar = false; //for example if we did not use it if we have "example\t shit" then the output will be: "example    t shit" 
        _tmpProText.text = leadingCharBeforeDelay ? leadingChar : "";
        char[] write = writer.ToCharArray();
        yield return new WaitForSeconds(delayBeforeStart);
        for (int i = 0; i <= write.Length - 1; i++)
        {
            //if (_tmpProText.text.Length > 0)
            //{
            //    _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
            //}
            if (specialChar) { specialChar = false; continue; }
            if (write[i].ToString() == @"\")
            {
                //this hell of a switch let's you use special characters in inspector and expect code like output on screen
                switch (write[i].ToString() + write[i + 1].ToString())
                {
                    case @"\n":
                        _tmpProText.text += "\n";
                        break;
                    case @"\\":
                        _tmpProText.text += "\\";
                        break;
                    case @"\r":
                        _tmpProText.text += "\r";
                        break;
                    case @"\t":
                        _tmpProText.text += "\t";
                        break;
                    case "\"":
                        _tmpProText.text += "\"";
                        break;
                    case @"\'":
                        _tmpProText.text += "\'";
                        break;
                }
                specialChar = true;
                continue;
            }
            _tmpProText.text += write[i];
            _tmpProText.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }
        yield return new WaitForSeconds(delayBeforeEnd);

        if (leadingChar != "")
        {
            _tmpProText.text = _tmpProText.text.Substring(0, _tmpProText.text.Length - leadingChar.Length);
        }
    }
    private void Start()
    {
        StartCoroutine("Type");
    }
    IEnumerator Type()
    {
        while (write)
        {
            writer = text1;
            yield return StartCoroutine("TypeWriterTMP");
            writer = text2;
            yield return StartCoroutine("TypeWriterTMP");
        }
    }
}
