using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public int computerLevel;
    public int airconLevel;

    [Header("초기값"), SerializeField]
    private int computerFisrtConst;
    [SerializeField]
    private int airconFisrtConst;

    [Header("업그레이드 관련 텍스트")]
    [SerializeField] private TextMeshProUGUI upgardeLevel_Computer_Text;
    [SerializeField] private TextMeshProUGUI upgardeLevel_Aircon_Text;
    [SerializeField] private TextMeshProUGUI upgradeCost_Computer_Text;
    [SerializeField] private TextMeshProUGUI upgradeCost_Aircon_Text;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpgardeText();
    }

    //돈 획득 배율 관련
    public float GetAirconMoney()// 레벨 x ( 0.5 * 클릭시 획득 골드)
    {
        return airconLevel * (0.5f *  airconFisrtConst);
    }

    public float GetComputerMoney()
    {
        return computerFisrtConst + (computerLevel * 10);
    }

    //코스트 소비 배율 관련
    public int GetAirconConst()
    {
        return Mathf.RoundToInt(airconFisrtConst * (float)(Mathf.Pow(1.2f, airconLevel))); // Mathf.Pow은 double형 반환이여서 float로 반환
    }

    public int GetComputerConst()
    {
        return Mathf.RoundToInt(computerFisrtConst * (float)(Mathf.Pow(1.2f, computerLevel)));
    }

    public void UpgradeFacilities(string type)
    {
        switch(type)
        {
            case "Aircon":
                if (MoneyManager.instance.money >= GetAirconConst())
                {
                    MoneyManager.instance.money -= GetAirconConst();
                    airconLevel++;
                    Debug.Log("에어컨 업그레이드 : " + airconLevel);
                }
                else
                {
                    Debug.Log("돈이 부족합니다");
                }
                break;

            case "Computer":
                if (MoneyManager.instance.money >= GetComputerConst())
                {
                    MoneyManager.instance.money -= GetComputerConst();
                    computerLevel++;
                    Debug.Log("컴퓨터 업그레이드: " + computerLevel);
                }
                else
                {
                    Debug.Log("돈이 부족합니다");
                }
                break;
        }

        UpgardeText();
        MoneyManager.instance.UITextUpdate();
    }

    public void UpgardeText()
    {
        upgardeLevel_Computer_Text.text = "Computer : " + computerLevel;
        upgardeLevel_Aircon_Text.text = "Aircon : " + airconLevel;
        upgradeCost_Computer_Text.text = GetComputerMoney() + "s / "+ GetComputerConst() + " Cost";
        upgradeCost_Aircon_Text.text = GetAirconMoney() + "click / " + GetAirconConst() + " Cost";
    }
}
