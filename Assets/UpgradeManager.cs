using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public int chairLevel;
    public int computerLevel;
    public int airconLevel;

    private int chairFisrtConst;
    private int computerFisrtConst;
    private int airconFisrtConst;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int ChairGetMoney()
    {
        return chairFisrtConst;
    }
}
