using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public GameObject player;
    public int eventNumber;
    public GameObject[] checkPos;
    UI_TextSet ui;
    public GameObject clickSound;
    bool ing;
    // Start is called before the first frame update
    void Start()
    {
        ui = GetComponent<UI_TextSet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ing == false)
        {

            switch (eventNumber)
            {
                case 0:
                    eventNumber++;
                    StartCoroutine("Event_01");
                    break;
                case 1:
                    if(Vector3.Distance(player.transform.position,checkPos[0].transform.position) < 10)
                    {
                        eventNumber++;
                        StartCoroutine("Event_02");
                    }
                    break;
                case 2:
                    if (Vector3.Distance(player.transform.position, checkPos[1].transform.position) < 10)
                    {
                        eventNumber++;
                        StartCoroutine("Event_03");
                    }
                    break;
                case 3:
                    if (Vector3.Distance(player.transform.position, checkPos[2].transform.position) < 10)
                    {
                        eventNumber++;
                        StartCoroutine("Event_04");
                    }
                    break;
            }
        }
    }

    IEnumerator Event_01()
    {
        ing = true;
        yield return new WaitForSeconds(3);
        ui.TextSetUp("요원 정신이 드십니까?");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("저는 전술어드바이저 AI입니다.");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("마지막 기록으로부터 999999......일이 지났습니다.");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("주변을 살펴 현 상황에 대한 정보를 조사하세요.");
        yield return new WaitForSeconds(3);
        ui.downText.text = "";
        ui.upText.text = "1. 현 상황을 알 수 있는 <color=#008000ff>정보</color> 찾기";
        clickSound.GetComponent<AudioSource>().Play();
        ui.targetImage.SetActive(true);
        ui.targetObject = checkPos[0];
        yield return new WaitForSeconds(0.1f);
        ui.targetText.text = "군 바리케이드";
        ing = false;
    }

    IEnumerator Event_02()
    {
        ing = true;
        yield return new WaitForSeconds(3);
        ui.TextSetUp("군 저지선을 발견했습니다.");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("생존자 파악되지 않음.");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("본대와 빠르게 합류해야 합니다.");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("사람이 있을 법한 곳을 찾으십시오.");
        yield return new WaitForSeconds(3);
        ui.downText.text = "";
        ui.upText.text = "<color=#808080ff>1. 주변의 상황을 알 수 있는 정보 찾기</color>\n2. 주변 <color=#008000ff>건물</color> 탐색";
        clickSound.GetComponent<AudioSource>().Play();
        ui.targetObject = checkPos[1];
        yield return new WaitForSeconds(0.1f);
        ui.targetText.text = "오래된 빌딩 입구";
        ing = false;
    }

    IEnumerator Event_03()
    {
        ing = true;
        yield return new WaitForSeconds(3);
        ui.TextSetUp("문이 잠겨있어 들어갈 수 없습니다.");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("다른 곳을 찾아보십시오.");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("아직 낙담하긴 이릅니다.");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("우린 전쟁에서 분명 이길겁니다.");
        yield return new WaitForSeconds(3);
        ui.downText.text = "";
        ui.upText.text = "<color=#808080ff>1. 주변의 상황을 알 수 있는 정보 찾기</color>\n<color=#808080ff>2. 주변 건물 탐색</color>\n3. <color=#008000ff>생존자</color> 흔적 탐색";
        clickSound.GetComponent<AudioSource>().Play();
        ui.targetObject = checkPos[2];
        yield return new WaitForSeconds(0.1f);
        ui.targetText.text = "멀쩡한 자동차";
        ing = false;
    }

    IEnumerator Event_04()
    {
        ing = true;
        yield return new WaitForSeconds(3);
        ui.TextSetUp("최근까지 사용된 흔적이 있습니다.");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("주변에 분명 생존자가 있을겁니다.");
        yield return new WaitForSeconds(3);
        ui.TextSetUp("자유롭게 주변을 탐색하세요.");
        yield return new WaitForSeconds(3);
        ui.downText.text = "";
        ui.upText.text = "<color=#808080ff>1. 주변의 상황을 알 수 있는 정보 찾기</color>\n<color=#808080ff>2. 주변 건물 탐색</color>\n<color=#808080ff>3. 생존자 흔적 탐색 </color>\n4. 자유롭게 주변 탐색";
        clickSound.GetComponent<AudioSource>().Play();
        ui.targetImage.SetActive(false);
        ui.targetObject = null;
        yield return new WaitForSeconds(0.1f);
        ing = false;
    }
    
}
