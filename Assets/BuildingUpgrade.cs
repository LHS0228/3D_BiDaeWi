using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject[] Building_Main;
    [SerializeField] private GameObject[] Building_2;
    [SerializeField] private GameObject[] Building_3;
    [SerializeField] private GameObject[] Building_4;
    [SerializeField] private GameObject[] Building_5;
    [SerializeField] private GameObject[] Building_6;
    [SerializeField] private GameObject[] Building_7;

    private float setTime;

    // Update is called once per frame
    void Update()
    {

    }

    void BuildingUpgradeAnim(string buildingName, int step)
    {
        GameObject[] setBuilding = null;

        switch (buildingName)
        {
            case "건물메인":
                setBuilding = Building_Main;
                break;
            case "건물서브1":
                setBuilding = Building_2;
                break;
            case "건물서브2":
                setBuilding = Building_3;
                break;
            case "건물서브3":
                setBuilding = Building_4;
                break;
            case "건물서브4":
                setBuilding = Building_5;
                break;
            case "건물서브5":
                setBuilding = Building_6;
                break;
            case "건물서브6":
                setBuilding = Building_7;
                break;
        }

        if(step == 0)
        {
            for(int i=0; i < setBuilding.Length + 1; i++)
            {
                setBuilding[i].SetActive(false);
            }
        }

        else
        {
            for(int i = 0; i< step + 1; i++)
            {
                setBuilding[i].SetActive(true);
            }
        }
    }
}
