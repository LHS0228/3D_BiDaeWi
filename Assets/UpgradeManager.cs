using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    UpgradeManager instance;

    public int chairLevel;
    public int computerLevel;
    public int airconLevel;

    private int chairFisrtConst;
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
    public float ChairMoneyGet()
    {
        //이거는 초 당 획득
        return chairFisrtConst + (chairFisrtConst * (chairFisrtConst * 0.5f);
    }

    public float AirconMoneyGet()// 레벨 x ( 0.5 * 클릭시 획득 골드)
    {

        return airconLevel * (int)( 0.5 * MoneyManager.instance.clickMoney);
    }

    public float ComputerMoneyGet()
    {
        return 0;
    }

    //코스트 소비 배율 관련
    public float AirconConstGet()
    {
        return airconFisrtConst * (int) Math.Pow(1.2f, airconLevel);
    }

    public float ComputerConstGet()
    {
        return computerFisrtConst * (int) Math.Pow(1.2f, computerLevel);
    }

    public float ChairConstGet()
    {
        return chairFisrtConst * (int)Math.Pow(1.2f, chairLevel);
    }
}
