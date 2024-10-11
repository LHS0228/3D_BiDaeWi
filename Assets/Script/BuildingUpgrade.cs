using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

enum BuildingType
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
    [SerializeField] private GameObject[] building_piece_Main;
    [SerializeField] private GameObject[] building_piece_Bank;
    [SerializeField] private GameObject[] building_piece_Energy;
    [SerializeField] private GameObject[] building_piece_Lawfirm;
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

    private GameObject[] setBuilding_piece = null;
    private GameObject setBuilding = null;
    private Vector3 oriangeTrans;
    private float setHeight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            BuildingUpgradeAnim(BuildingType.Energy, 3);
        }
    }

    void BuildingUpgradeAnim(BuildingType buildingType, int step)
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
                setBuilding_piece = building_piece_Lawfirm;
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
        yield return new WaitForSeconds(4 + (0.5f * step));

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
