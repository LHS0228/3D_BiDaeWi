using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public int computerLevel;
    public int airconLevel;

    [SerializeField]
    private int computerFisrtConst;
    private int airconFisrtConst;

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

    //돈 획득 배율 관련
    public float GetAirconMoney()// 레벨 x ( 0.5 * 클릭시 획득 골드)
    {

        return 0;
    }

    public float GetComputerMoney()
    {
        return computerFisrtConst + (computerLevel * 10);
    }

    //코스트 소비 배율 관련
    public float GetAirconConst()
    {
        return airconFisrtConst * (float)(Mathf.Pow(1.2f, airconLevel)); // Mathf.Pow은 double형 반환이여서 float로 반환
    }

    public float GetComputerConst()
    {
        return computerFisrtConst * (float)(Mathf.Pow(1.2f, computerLevel));
    }

    public void UpgradeComputer()
    {
        float cost = GetComputerConst();

        if (MoneyManager.instance.money >= cost)
        {
            MoneyManager.instance.money -= Mathf.RoundToInt(cost);
            computerLevel++;
            Debug.Log("Computer Upgrade : " + computerLevel);
            GetComputerMoney();
            MoneyManager.instance.clickMoney = Mathf.RoundToInt(GetComputerMoney());
        }
        else
        {
            Debug.Log("돈이 부족합니다");
        }
    }
}
