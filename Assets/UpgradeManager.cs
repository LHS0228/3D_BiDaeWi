using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    public int computerLevel;
    public int airconLevel;

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

        return airconLevel * (int)( 0.5 * MoneyManager.instance.clickMoney);
    }

    public float GetComputerMoney()
    {
        return 0;
    }

    //코스트 소비 배율 관련
    public float GetAirconConst()
    {
        return airconFisrtConst * (int) Math.Pow(1.2f, airconLevel);
    }

    public float GetComputerConst()
    {
        return computerFisrtConst * (int) Math.Pow(1.2f, computerLevel);
    }
}
