using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningManager : MonoBehaviour
{
    [SerializeField]
    private GameObject backGround;
    [SerializeField]
    private GameObject storys_obj;
    [SerializeField]
    private GameObject[] storyImage;
    [SerializeField]
    private GameObject gameTitle;

    private float setTime;
    private int setCount;

    private bool isNotFirst = false;
    private bool isPlayStop = false;

    private void Start()
    {
        if(SaveLoadManager.instance.LoadData("OkOpening", 0) == 0)
        {
            isNotFirst = false;
        }
        else
        {
            isNotFirst = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayStop)
        {
            OpeningStoryStart();
        }
        if (isPlayStop && Input.GetMouseButtonDown(0))
        {
            GameStart();
        }

        if (Input.GetKey(KeyCode.Space) && !isNotFirst)
        {
            isPlayStop = true;
            backGround.SetActive(false);
            gameTitle.SetActive(true);
            storys_obj.SetActive(false);
        }
    }

    void OpeningStoryStart()
    {
        setTime += Time.deltaTime;

        switch (setCount)
        {
            case 0:
                storyImage[0].SetActive(true);
                storyImage[0].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 5);
                storyImage[0].GetComponent<RectTransform>().DOAnchorPosX(-480, 10);
                setTime = 0;
                setCount = 1;
                break;

            case 1:
                if (setTime > 3)
                {
                    storyImage[1].SetActive(true);
                    storyImage[1].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 5);
                    storyImage[1].GetComponent<RectTransform>().DOAnchorPosX(400, 10);
                    setCount = 2;
                    setTime = 0;
                }
                break;

            case 2:
                if(setTime > 6)
                {
                    storys_obj.GetComponent<RectTransform>().DOAnchorPosY(1000, 1);
                    storyImage[2].SetActive(true);
                    setCount = 3;
                    setTime = 0;
                }
                break;

            case 3:
                if(setTime > 5)
                {
                    storyImage[2].SetActive(false);
                    storyImage[3].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 13);
                    setCount = 4;
                    setTime = 0;
                }
                break;

            case 4:
                if(setTime > 5)
                {
                    storyImage[4].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 7);
                    setCount = 5;
                    setTime = 0;
                }
                break;

            case 5:
                if(setTime > 5)
                {
                    storyImage[3].SetActive(false);
                    storyImage[4].GetComponent<RectTransform>().DOAnchorPosY(-1800, 3);
                    setCount = 6;
                    setTime = 0;
                }
                break;

            case 6:
                if (setTime > 3)
                {
                    storyImage[5].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 5);
                    setCount = 7;
                    setTime = 0;
                }
                break;

            case 7:
                if (setTime > 14)
                {
                    storyImage[11].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 4);
                    setCount = 8;
                    setTime = 0;
                }
                else if (setTime > 12)
                {
                    storyImage[10].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 4);
                }
                else if (setTime > 10)
                {
                    storyImage[9].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 4);
                }
                else if (setTime > 8)
                {
                    storyImage[8].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 4);
                }
                else if (setTime > 6)
                {
                    storyImage[7].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 4);
                }
                else if (setTime > 4)
                {
                    storyImage[6].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 4);
                }
                break;

            case 8:
                if (setTime > 5)
                {
                    for (int i = 5; i < 11; i++)
                    {
                        storyImage[i].SetActive(false);
                    }
                    storyImage[11].GetComponent<RectTransform>().DOAnchorPosY(1000, 10);
                    storyImage[4].GetComponent<RectTransform>().DOAnchorPosY(-1000, 5);
                    setCount = 9;
                    setTime = 0;
                }
                break;

            case 9:
                if(setTime > 6)
                {
                    storyImage[12].GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 3);
                    setCount = 10;
                    setTime = 0;
                }
                break;
            case 10:
                if(setTime > 5)
                {
                    storyImage[13].SetActive(true);
                    storyImage[13].GetComponent<RectTransform>().DOSizeDelta(new Vector2(501, 430.5f), 0.5f);
                    setCount = 11;
                    setTime = 0;
                }
                break;
            case 11:
                if (setTime > 5)
                {
                    backGround.SetActive(false);
                    storys_obj.SetActive(false);
                    SaveLoadManager.instance.SaveData("OkOpening", 1);
                    isNotFirst = true;
                    isPlayStop = true;
                    gameTitle.SetActive(true);
                    setCount = 12;
                    setTime = 0;
                }
                break;
            case 12:
                break;
        }
    }

    void GameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
