using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public enum BuildingType
{
    Main,
    Bank,
    Energy,
    Lawfirm,
    Healthcare,
    Carance,
    Cement
}

public class BuildingUpgrade : MonoBehaviour
{
    public static BuildingUpgrade instance;

    [SerializeField] private GameObject[] building_piece_Main;
    [SerializeField] private GameObject[] building_piece_Bank;
    [SerializeField] private GameObject[] building_piece_Energy;
    [SerializeField] private GameObject[] building_piece_Lawfire;
    [SerializeField] private GameObject[] building_piece_Healthcare;
    [SerializeField] private GameObject[] building_piece_Crane;
    [SerializeField] private GameObject[] building_piece_Cement;

    [SerializeField] private GameObject building_Main; //메인
    [SerializeField] private GameObject building_Bank; //서브
    [SerializeField] private GameObject building_Energy; //보라
    [SerializeField] private GameObject building_Lawfire; //파랑
    [SerializeField] private GameObject building_Healthcare; //초록
    [SerializeField] private GameObject building_Crane; // 빨강
    [SerializeField] private GameObject building_Cement; //갈색

    [SerializeField] private GameObject main_Logo;

    //ALL 업그레이드
    [SerializeField] private Vector3[] allTrans;

    private GameObject[] setBuilding_piece = null;
    private GameObject setBuilding = null;
    private Vector3 oriangeTrans;
    private float setHeight;

    private void Awake()
    {
        allTrans = new Vector3[7];

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AllBuildingUpgrade(int step)
    {
        allTrans[0] = building_Main.transform.position;
        allTrans[1] = building_Bank.transform.position;
        allTrans[2] = building_Energy.transform.position;
        allTrans[3] = building_Lawfire.transform.position;
        allTrans[4] = building_Healthcare.transform.position;
        allTrans[5] = building_Crane.transform.position;
        allTrans[6] = building_Cement.transform.position;

        CameraConversion.instance.CameraChange(CameraType.Camera3D);

        DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() => AllBuildingUpgrade_Down(step));

        StartCoroutine(AllBuildingUpgrade_Up(step));
    }

    public void AllBuildingUpgrade_Down(int step)
    {
        building_Main.transform.DOMoveY(-(6 * (step + 1)), 4 + (0.5f * step));
        building_Bank.transform.DOMoveY(-(5 * (step + 1)), 4 + (0.5f * step));
        building_Energy.transform.DOMoveY(-(4 * (step + 1)), 4 + (0.5f * step));
        building_Lawfire.transform.DOMoveY(-(4 * (step + 1)), 4 + (0.5f * step));
        building_Healthcare.transform.DOMoveY(-(4 * (step + 1)), 4 + (0.5f * step));
        building_Crane.transform.DOMoveY(-(4 * (step + 1)), 4 + (0.5f * step));
        building_Cement.transform.DOMoveY(-(4 * (step + 1)), 4 + (0.5f * step));
    }

    private IEnumerator AllBuildingUpgrade_Up(int step)
    {
        yield return new WaitForSeconds(4 + (0.5f * step));

        if (step == 0)
        {
            for (int i = 0; i < building_piece_Main.Length + 1; i++)
            {
                building_piece_Main[i].SetActive(false);
                building_piece_Bank[i].SetActive(false);
                building_piece_Energy[i].SetActive(false);
                building_piece_Lawfire[i].SetActive(false);
                building_piece_Healthcare[i].SetActive(false);
                building_piece_Crane[i].SetActive(false);
                building_piece_Cement[i].SetActive(false);
            }
        }

        else
        {
            for (int i = 0; i < step + 1; i++)
            {
                building_piece_Main[i].SetActive(true);
                building_piece_Bank[i].SetActive(true);
                building_piece_Energy[i].SetActive(true);
                building_piece_Lawfire[i].SetActive(true);
                building_piece_Healthcare[i].SetActive(true);
                building_piece_Crane[i].SetActive(true);
                building_piece_Cement[i].SetActive(true);

                if (step == 1)
                {
                    building_Bank.transform.position -= new Vector3(0, 5f, 0);
                    building_Energy.transform.position -= new Vector3(0, 4f, 0);
                    building_Lawfire.transform.position -= new Vector3(0, 4f, 0);
                    building_Healthcare.transform.position -= new Vector3(0, 4f, 0);
                    building_Crane.transform.position -= new Vector3(0, 4f, 0);
                    building_Cement.transform.position -= new Vector3(0, 4f, 0);
                }
            }
        }

        building_Main.transform.DOMoveY(allTrans[0].y, 3 + (0.5f * step));
        building_Bank.transform.DOMoveY(allTrans[1].y, 3 + (0.5f * step));
        building_Energy.transform.DOMoveY(allTrans[2].y, 3 + (0.5f * step));
        building_Lawfire.transform.DOMoveY(allTrans[3].y, 3 + (0.5f * step));
        building_Healthcare.transform.DOMoveY(allTrans[4].y, 3 + (0.5f * step));
        building_Crane.transform.DOMoveY(allTrans[5].y, 3 + (0.5f * step));
        building_Cement.transform.DOMoveY(allTrans[6].y, 3 + (0.5f * step));
        main_Logo.transform.DOMoveY(4.62f + (3.2f * (step+2)), 3 + (0.5f * step));
    }


    public void BuildingUpgradeAnim(BuildingType buildingType, int step)
    {
        setBuilding_piece = null;
        setBuilding = null;

        switch (buildingType)
        {
            case BuildingType.Main:
                setBuilding = building_Main;
                setBuilding_piece = building_piece_Main;
                oriangeTrans = building_Main.transform.position;
                setHeight = 6;
                break;
            case BuildingType.Bank:
                setBuilding = building_Bank;
                setBuilding_piece = building_piece_Bank;
                oriangeTrans = building_Bank.transform.position;
                setHeight = 5;
                break;
            case BuildingType.Energy:
                setBuilding = building_Energy;
                setBuilding_piece = building_piece_Energy;
                oriangeTrans = building_Energy.transform.position;
                setHeight = 4;
                break;
            case BuildingType.Lawfirm:
                setBuilding = building_Lawfire;
                setBuilding_piece = building_piece_Lawfire;
                oriangeTrans = building_Lawfire.transform.position;
                setHeight = 4;
                break;
            case BuildingType.Healthcare:
                setBuilding = building_Healthcare;
                setBuilding_piece = building_piece_Healthcare;
                oriangeTrans = building_Healthcare.transform.position;
                setHeight = 4;
                break;
            case BuildingType.Carance:
                setBuilding = building_Crane;
                setBuilding_piece = building_piece_Crane;
                oriangeTrans = building_Crane.transform.position;
                setHeight = 4;
                break;
            case BuildingType.Cement:
                setBuilding = building_Cement;
                setBuilding_piece = building_piece_Cement;
                oriangeTrans = building_Cement.transform.position;
                setHeight = 4;
                break;
        }

        CameraConversion.instance.CameraChange(CameraType.Camera3D);
        DOTween.Sequence().AppendInterval(1.5f).AppendCallback(() => setBuilding.transform.DOMoveY(-(setHeight * (step +1)), 4 + (0.5f* step)));

        StartCoroutine(BuildingUpAnim(step));
    }

    IEnumerator BuildingUpAnim(int step)
    {
        yield return new WaitForSeconds(3 + (0.5f * step));

        if (step == 0)
        {
            for(int i=0; i < setBuilding_piece.Length + 1; i++)
            {
                setBuilding_piece[i].SetActive(false);
            }
        }

        else
        {
            for(int i = 0; i< step + 1; i++)
            {
                setBuilding_piece[i].SetActive(true);
            }
        }

        setBuilding.transform.DOMoveY(oriangeTrans.y, 4 + (0.5f * step));
    }
    
}
