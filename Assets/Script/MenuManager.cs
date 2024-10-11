using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("메뉴"), SerializeField]
    private GameObject optionMenu;
    [SerializeField]
    private GameObject resetMenu;

    public void OnOptionMenu()
    {
        optionMenu.SetActive(true);
    }

    public void OnResetMenu()
    {
        resetMenu.SetActive(true);
    }

    public void OffOptionMenu()
    {
        optionMenu.SetActive(false);
    }

    public void OffResetMenu()
    {
        resetMenu.SetActive(false);
    }

    public void Reset()
    {
        //변수 초기화 및 씬 첫 게임 로딩으로 변환.
    }
}
