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

    public int mainBuildingLevel;
    public int subBuildingLevel;
    public int subBuildingLevel1;
    public int subBuildingLevel2;
    public int subBuildingLevel3;
    public int subBuildingLevel4;
    public int subBuildingLevel5;

    [Header("업그레이드 관련 텍스트")]
    [SerializeField] private TextMeshProUGUI upgardeLevel_Computer_Text;
    [SerializeField] private TextMeshProUGUI upgardeLevel_Aircon_Text;
    [SerializeField] private TextMeshProUGUI upgradeCost_Computer_Text;
    [SerializeField] private TextMeshProUGUI upgradeCost_Aircon_Text;

    [Header("에어컨 레벨별 이미지")]
    [SerializeField] private Sprite[] aircon_Image;
    [Header("컴퓨터 레벨별 이미지")]
    [SerializeField] private Sprite[] computer_Image;

    [Header("오브젝트s")]
    [SerializeField] private GameObject aircon_Sprite;
    [SerializeField] private GameObject[] computer_Sprite;

    private EmployeeManager employeeManager;
    private SoundManager soundManager;

    // Start is called before the first frame update
    void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();

        if (instance == null)
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
        employeeManager = FindObjectOfType<EmployeeManager>();
        UpgardeText();
    }

    private void FixedUpdate()
    {
        switch(airconLevel)
        {
            case >= 90:
                aircon_Sprite.GetComponent<SpriteRenderer>().sprite = aircon_Image[6];
                break;

            case >= 75:
                aircon_Sprite.GetComponent<SpriteRenderer>().sprite = aircon_Image[5];
                break;

            case >= 60:
                aircon_Sprite.GetComponent<SpriteRenderer>().sprite = aircon_Image[4];
                break;

            case >= 45:
                aircon_Sprite.GetComponent<SpriteRenderer>().sprite = aircon_Image[3];
                break;

            case >= 30:
                aircon_Sprite.GetComponent<SpriteRenderer>().sprite = aircon_Image[2];
                break;

            case >= 15:
                aircon_Sprite.GetComponent<SpriteRenderer>().sprite = aircon_Image[1];
                break;

            case > 0:
                aircon_Sprite.GetComponent<SpriteRenderer>().sprite = aircon_Image[0];
                aircon_Sprite.SetActive(true);
                break;

            case 0:
                aircon_Sprite.SetActive(false);
                break;
        }

        switch(computerLevel)
        {
            case >= 90:
                for (int i = 0; i < computer_Sprite.Length; i++)
                {
                    computer_Sprite[i].GetComponent<SpriteRenderer>().sprite = computer_Image[9];
                }
                break;

            case >= 80:
                for (int i = 0; i < computer_Sprite.Length; i++)
                {
                    computer_Sprite[i].GetComponent<SpriteRenderer>().sprite = computer_Image[8];
                }
                break;

            case >= 70:
                for (int i = 0; i < computer_Sprite.Length; i++)
                {
                    computer_Sprite[i].GetComponent<SpriteRenderer>().sprite = computer_Image[7];
                }
                break;

            case >= 60:
                for (int i = 0; i < computer_Sprite.Length; i++)
                {
                    computer_Sprite[i].GetComponent<SpriteRenderer>().sprite = computer_Image[6];
                }
                break;

            case >= 50:
                for (int i = 0; i < computer_Sprite.Length; i++)
                {
                    computer_Sprite[i].GetComponent<SpriteRenderer>().sprite = computer_Image[5];
                }
                break;

            case >= 40:
                for (int i = 0; i < computer_Sprite.Length; i++)
                {
                    computer_Sprite[i].GetComponent<SpriteRenderer>().sprite = computer_Image[4];
                }
                break;

            case >= 30:
                for (int i = 0; i < computer_Sprite.Length; i++)
                {
                    computer_Sprite[i].GetComponent<SpriteRenderer>().sprite = computer_Image[3];
                }
                break;

            case >= 20:
                for (int i = 0; i < computer_Sprite.Length; i++)
                {
                    computer_Sprite[i].GetComponent<SpriteRenderer>().sprite = computer_Image[2];
                }
                break;

            case >= 10:
                for (int i = 0; i < computer_Sprite.Length; i++)
                {
                    computer_Sprite[i].GetComponent<SpriteRenderer>().sprite = computer_Image[1];
                }
                break;

            case >= 0:
                for (int i = 0; i < computer_Sprite.Length; i++)
                {
                    computer_Sprite[i].GetComponent<SpriteRenderer>().sprite = computer_Image[0];
                }
                break;
        }
    }

    //돈 획득 배율 관련
    public float GetAirconMoney()
    {
        // 기본 자동 획득 재화
        float BaseMoney = airconLevel * (0.5f * airconFisrtConst);

        // 고용한 직원 리스트를 가져옴
        List<Employee> HiredEmployee = employeeManager.GetHiredEmployee();

        // 직원의 특성 보너스 초기화
        float Total_Auto_Bonus = 0f;

        // 고용한 직원의 수가 0보다 컸을 때
        if (HiredEmployee.Count > 0)
        {
            foreach (Employee employee in HiredEmployee)
            {
                // 파라미터 때문에 2개를 불러옴
                (float touch_bonus, float auto_bonus) = employee.ActiveTrait();
                //에어컨이기 때문에 오토 보너스만 가져옴
                Total_Auto_Bonus += auto_bonus;

            }// 터치 당 재화에 직원 특성을 곱한 값을 초당 자동 재화로 반환
            return BaseMoney * (1 + Total_Auto_Bonus);
        }
        // 그게 아니라면 직원 특성을 곱한 값이 아닌 기본 값을 초당 자동 재화로 반환
        return airconLevel * (0.5f * airconFisrtConst);
    }
    // 클릭 당 재화 함수
    public float GetComputerMoney()
    {
        // 기본 클릭 당 재화
        float BaseMoney = computerFisrtConst + (computerLevel * computerFisrtConst);

        // 고용한 직원 리스트를 가져옴
        List<Employee> HiredEmployee = employeeManager.GetHiredEmployee();

        // 직원의 특성 보너스 초기화
        float Total_Touch_Bonus = 0f;

        // 고용한 직원의 수가 0보다 컸을 때
        if (HiredEmployee.Count > 0)
        {
            // 고용한 직원 리스트에 직원을 다 봄
            foreach (Employee employee in HiredEmployee)
            {
                // 파라미터 때문에 2개를 불러옴
                (float touch_bonus, float auto_bonus) = employee.ActiveTrait();
                //컴퓨터기 때문에 터치 보너스만 가져옴
                Total_Touch_Bonus += touch_bonus;

            }
            // 터치 당 재화에 직원 특성을 곱한 값을 터치 당 재화로 반환
            return BaseMoney * (1 + Total_Touch_Bonus);
        } // 그게 아니라면 직원 특성을 곱한 값이 아닌 기본 값을 터치 당 재화로 반환
        return computerFisrtConst + (computerLevel * computerFisrtConst);

    }

    public (float totaltouchbonus, float totalautobonus) GetEmployeeBonus(Employee employee)
    {
        float Total_Touch_Bonus = 0f;
        float Total_Auto_Bonus = 0f;

        List<Employee> Hireemployees = employeeManager.GetHiredEmployee();

        foreach (Employee employee1 in Hireemployees)
        {
            (float touchbonus, float autobonus) = employee1.ActiveTrait();
            Total_Touch_Bonus += touchbonus;
            Total_Auto_Bonus += autobonus;
        }
        return (Total_Touch_Bonus, Total_Auto_Bonus);
    }

    //코스트 소비 배율 관련
    public int GetAirconConst()
    {
        return Mathf.RoundToInt(airconFisrtConst * (float)(Mathf.Pow(1.2f, airconLevel)));
    }

    public int GetComputerConst()
    {
        return Mathf.RoundToInt(computerFisrtConst * (float)(Mathf.Pow(1.2f, computerLevel)));
    }

    public void UpgradeFacilities(string type)
    {
        if (!GameManager.instance.isGameStop)
        {
            switch (type)
            {
                case "Aircon":
                    if (MoneyManager.instance.money >= GetAirconConst())
                    {
                        MoneyManager.instance.money -= GetAirconConst();
                        airconLevel++;
                        Debug.Log("에어컨 업그레이드 : " + airconLevel);
                        soundManager.PlaySFX(5);
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
                        soundManager.PlaySFX(5);
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
    }

    public void UpgardeText()
    {
        upgardeLevel_Computer_Text.text = "컴퓨터 Lv " + computerLevel;
        upgardeLevel_Aircon_Text.text = "에어컨 Lv " + airconLevel; ;
        upgradeCost_Computer_Text.text = GetComputerConst() + " 원";
        upgradeCost_Aircon_Text.text = GetAirconConst() + " 원";
    }
}
