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
    public int ChairMoneyGet()
    {
        //이거는 초 당
        return (int)(chairFisrtConst + (chairFisrtConst * (chairFisrtConst * 0.5f)));
    }

    public int AirconMoneyGet()
    {
        return (int)(airconFisrtConst);
    }

    public int ComputerMoneyGet()
    {
        return 0;
    }

    //코스트 소비 배율 관련
    public int AirconConstGet()
    {
        return 0;
    }

    public int ComputerConstGet()
    {
        return 0;
    }

    public int ChairConstGet()
    {
        return 0;
    }
}
