using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject bilnd;
    [SerializeField]
    private GameObject guide;
    [SerializeField]
    private GameObject chatObj;
    [SerializeField]
    private TextMeshProUGUI chatText;

    private string[] guideDialogue;
    private int setCount;

    private bool tutoEnd;

    // Start is called before the first frame update
    void Start()
    {
        guideDialogue = new string[] { "안녕하세요 가이드 아로나입니다.", "호에에에ㅔ 가ㅏㄱ가ㅏ간다라다ㅏㄴ마라다라", "가ㅏㄱ가ㅏ간다라다ㅏㄴ마라다라ㄴㄴ", "ㅇㅁㅁㅇ가아앙", "니가모태모태노코", "구구구구구국", "아아라아ㅏ" };
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
        if(setCount < guideDialogue.Length)
        {
            GameManager.instance.isGameStop = true;

            if (Input.GetMouseButtonDown(0))
            {
                chatText.text = guideDialogue[setCount];
                setCount++;
            }
        }
        else
        {
            GameManager.instance.isGameStop = false;
            guide.SetActive(false);
            chatObj.SetActive(false);
            bilnd.SetActive(false);
            tutoEnd = true;
        }
    }
}
