using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_TextSet : MonoBehaviour
{
    public Text downText;
    public string textFile;
    public GameObject targetImage;
    public GameObject targetObject;
    public Camera cam;
    public Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SlowTextUp");
    }

    // Update is called once per frame
    void Update()
    {
        TargetChase();
    }

    void TargetChase()
    {
        newPos = cam.WorldToScreenPoint(targetObject.transform.position);
        if (newPos.x < 0) newPos.x = 0;
        if (newPos.x > Screen.width) newPos.x = Screen.width;
        if (newPos.y < 0) newPos.y = 0;
        if (newPos.y > Screen.height) newPos.y = Screen.height;
        if(newPos.z < 0)
        {
            targetImage.SetActive(false);
        }
        else
        {
            targetImage.SetActive(true);
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
        string newStr ="";
        for (int i = 0; i < textFile.Length; i++)
        {
            newStr += textFile[i];
            downText.text = newStr;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
