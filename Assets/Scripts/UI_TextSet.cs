using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_TextSet : MonoBehaviour
{
    public Text upText;
    public Text downText;
    public Text targetText;
    public string textFile;
    public GameObject targetImage;
    public GameObject targetObject;
    public Camera cam;
    public Vector3 newPos;
    public Vector3 uiScale;
    public GameObject morseSound;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(targetObject != null)
        TargetChase();
    }

    void TargetChase()
    {
        newPos = cam.WorldToScreenPoint(targetObject.transform.position);
        if (newPos.x < 0) newPos.x = 0;
        if (newPos.x > Screen.width) newPos.x = Screen.width;
        if (newPos.y < 0) newPos.y = 0;
        if (newPos.y > Screen.height) newPos.y = Screen.height;
        if (newPos.z < 0)
        {
            targetImage.SetActive(false);
        }
        else
        {
            targetImage.SetActive(true);
            if (newPos.z < 15)
            {
                float a = (15 - newPos.z) * 0.1f;
                if (a < 0.3f) a = 0.3f;
                targetImage.transform.localScale = a * new Vector3(1, 1, 1);
            }
            else
            {
                targetImage.transform.localScale = 0.3f * new Vector3(1, 1, 1);
            }

            if (newPos.z < 10)
            {
                uiScale = new Vector3(1, 1, 1);
            }

            else
            {
                uiScale = new Vector3(0, 0, 0);
            }
            targetImage.transform.GetChild(0).localScale = Vector3.Lerp(targetImage.transform.GetChild(0).localScale, uiScale, Time.deltaTime * 5);


        }
        targetImage.transform.position = newPos;
    }

    public void TextSetUp(string text)
    {
        textFile = text;
        StartCoroutine("SlowTextUp");
    }

    IEnumerator SlowTextUp()
    {
        string newStr = "";
        for (int i = 0; i < textFile.Length; i++)
        {
            if(textFile[i] == ' ')
            {
                morseSound.GetComponent<AudioSource>().volume = 0;
            }
            else
            {
                morseSound.GetComponent<AudioSource>().volume = 1;
            }
            newStr += textFile[i];
            downText.text = newStr;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.05f);
        morseSound.GetComponent<AudioSource>().volume = 0;
    }
}
