using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Blinds;

    [SerializeField]
    private GameObject guide;
    [SerializeField]
    private GameObject chatObj;
    [SerializeField]
    private TextMeshProUGUI chatText;

    private string[] guideDialogue;
    private int setCount;

    private bool tutoEnd;

    void Start()
    {
        GameManager.instance.isGameStop = true;
        guideDialogue = new string[] { "방법을 알려드리기 전, \n저는 OOO이라고합니다.",
            "좌측 배경을 누르면 \n\n회사 운영에 필요한 코인을 획득할 수 있습니다.",
            "좌측 상단에 보이시는 것들은 \n현재 가지고 있는 코인, 클릭당 코인, \n초당 코인을 나타냅니다.",
            "우측 상단에 보이는 업그레이드를 눌러보실까요?",
            "업그레이드는 회사의 부품을 \n업그레이드하여 \n획득할 코인을 증가시켜 줍니다.",
            "그럼, 다음 직원을 눌러보실까요?",
            "고용을 누르시면 고용할 수 있는 \n직원이 뜹니다.\n직원의 특성은 획득 재화에 \n영향을 미치게 됩니다." ,
            "그리고 직원 고용에는 5,000코인이 드니 명심해 주세요 !",
            "회사를 눌러보실까요?",
            "회사를 업그레이드하기 위해서는 \n각 조건을 충족시켜야 합니다.",
            "설명은 여기까지입니다, \n이제 회사를 운영해 보세요 !",
            ""};


    }

    private void Update()
    {
        if (!tutoEnd)
        {
            TutorialOn();
        }
    }

    void TutorialOn()
    {
        if (setCount < guideDialogue.Length)
        {
            if (Input.GetMouseButtonDown(0))
            {
                chatText.text = guideDialogue[setCount];
                setCount++;
                TutorialGuide();
                if (setCount == 3 || setCount == 12)
                {
                    GameManager.instance.isGameStop = false;
                }
                else
                {
                    GameManager.instance.isGameStop = true;
                }
            }
        }
        else
        {
            GameManager.instance.isGameStop = false;
            guide.SetActive(false);
            chatObj.SetActive(false);
            foreach (GameObject blind in Blinds)
            {
                blind.SetActive(false);
            }

            tutoEnd = true;
        }
    }
    void TutorialGuide()
    {
        switch (setCount)
        { // 0 : 왼쪽 // 1 : 오른쪽 // 2 : 업그레이드 // 3 :직원 // 4 :회사 // 5 : 고용
            case 0:
                // 소개
                break;

            case 1: // 방법을 알려주긴 전에 소개
                break;

            case 2:// 1 "좌측 배경을 누르면 \n\n회사 운영에 필요한 코인을 획득할 수 있습니다.",
                // 좌측배경 활성화 
                Blinds[0].SetActive(false);
                break;

            case 3:  //"좌측 상단에 보이시는 것들은 \n현재 가지고 있는 코인, 클릭당 코인, \n초당 코인을 나타냅니다.",

                break;

            case 4: // 2 "우측 상단에 보이는 업그레이드를 눌러보실까요?",
                // 좌측 비활성화 , 업그레이드 활성화
                Blinds[0].SetActive(true);
                Blinds[2].SetActive(false);
                break;

            case 5: //"업그레이드는 회사의 부품을 \n업그레이드하여 \n획득할 코인을 증가시켜 줍니다.",
                // 우측 활성화
                Blinds[1].SetActive(false);
                Blinds[5].SetActive(false);
                break;

            case 6://"그럼, 다음 직원을 눌러보실까요?",
                // 우측 비활성화 , 직원 활성화
                Blinds[1].SetActive(true);
                Blinds[2].SetActive(true);
                Blinds[3].SetActive(false);
                Blinds[5].SetActive(true);
                break;

            case 7: // "고용을 누르시면 고용할 수 있는 \n직원이 뜹니다.\n직원의 특성은 획득 재화에 \n영향을 미치게 됩니다."
                // 우측 활성화 , 고용 활성화
                Blinds[1].SetActive(true);
                Blinds[5].SetActive(false);
                break;

            case 8: // "그리고 직원 고용에는 5,000코인이 드니 명심해 주세요 !"
                Blinds[1].SetActive(false);
                break;

            case 9: //"회사를 눌러보실까요?",
                    // 회사 활성화
                Blinds[1].SetActive(true);
                Blinds[5].SetActive(true);
                Blinds[3].SetActive(true);
                Blinds[4].SetActive(false);
                break;

            case 10: // "회사를 업그레이드하기 위해서는 \n각 조건을 충족시켜야 합니다."
                Blinds[1].SetActive(false);
                Blinds[5].SetActive(false);
                break;

            case 11: // "설명은 여기까지입니다, \n이제 회사를 운영해 보세요 !"
                // 다 비활성화
                foreach (GameObject blind in Blinds)
                    blind.SetActive(false);
                break;

            case 12:

                break;

            default:

                break;
        }


    }
}
