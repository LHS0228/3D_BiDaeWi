using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CompanyManager : MonoBehaviour
{
    public int CompanyLevel { get; set; } = 1; // 회사 1레벨부터 시작

    [SerializeField]
    private TextMeshProUGUI CurrentLevel; // 현재 회사 레벨 보여주기
    [SerializeField]
    private TextMeshProUGUI ShowLvCondition; // 레벨을 올리기위한 조건 보여주기
    [SerializeField]
    private Button LevelUpButton; // 레벨 업 버튼
    [SerializeField]
    private TextMeshProUGUI requireMoney; // 레벨업 비용

    private int RequireAirconLevel = 10; // 필요한 에어컨 최소 레벨
    private int requirelevel = 10;
    private int RequireComputerLevel = 10; // 필요한 컴퓨터 최소 레벨
    private int RequireHireEmployee = 1; // 고용한 최소 직원 수
    private int RequireMoney = 10000;

    private MoneyManager moneyManager;
    private UpgradeManager upgradeManager;
    private EmployeeManager employeeManager;

    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        upgradeManager = FindObjectOfType<UpgradeManager>();
        employeeManager = FindObjectOfType<EmployeeManager>();
        CompanyLevel = SaveLoadManager.instance.LoadData("CompanyLevel", 0);
        BuildingUpgrade.instance.LoadBuildings(SaveLoadManager.instance.LoadData("CompanyLevel", 0));
    }

    private void Update()
    {
        ShowCompanyInfo();
    }
    private void ShowCompanyInfo()
    {
        CurrentLevel.text = "회사 레벨: " + CompanyLevel;
        ShowLvCondition.text = $"필요 에어컨 레벨\n{upgradeManager.airconLevel} / {RequireAirconLevel}\n\n"
            + $"필요 컴퓨터 레벨\n{upgradeManager.computerLevel} / {RequireComputerLevel}\n\n"
            + $"고용 직원 수\n{employeeManager.IsHireEmployees.Count} / {RequireHireEmployee}";
        requireMoney.text = $"비용: {RequireMoney}";
    }

    
    private bool CheckCondition()
    {
        if (upgradeManager.airconLevel >= RequireAirconLevel && 
            upgradeManager.computerLevel >= RequireComputerLevel && 
            employeeManager.IsHireEmployees.Count >= RequireHireEmployee &&
            MoneyManager.instance.money >= RequireMoney)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void LevelUp()
    {
        if (CheckCondition())
        {
            CompanyLevel++;
            MoneyManager.instance.money -= RequireMoney;
            SaveLoadManager.instance.SaveData("CompanyLevel", CompanyLevel);
            UpdateRequires();
        }
        else
        {
            Debug.Log("조건에 부합하지 않습니다.");
        }
    }
    private void UpdateRequires()
    {
        if (CompanyLevel != 10)
        {
            BuildingUpgrade.instance.AllBuildingUpgrade(CompanyLevel - 1, false);
        }

        switch (CompanyLevel)
        {
            case 2:
                RequireMoney = 10000 + (50000 * (CompanyLevel - 1));
                RequireAirconLevel =  requirelevel + (10 * (CompanyLevel - 1));
                RequireComputerLevel = requirelevel + (10 * (CompanyLevel - 1));
                break;

            case 3:
                RequireMoney = 10000 + (50000 * (CompanyLevel - 1));
                RequireAirconLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireComputerLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireHireEmployee = 2;
                break;

            case 4:
                RequireMoney = 10000 + (50000 * (CompanyLevel - 1));
                RequireAirconLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireComputerLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireHireEmployee = 3;
                break;

            case 5:
                RequireMoney = 10000 + (50000 * (CompanyLevel - 1));
                RequireAirconLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireComputerLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireHireEmployee = 4;
                break;

            case 6:
                RequireMoney = 10000 + (50000 * (CompanyLevel - 1));
                RequireAirconLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireComputerLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireHireEmployee = 5;
                break;

            case 7:
                RequireMoney = 10000 + (50000 * (CompanyLevel - 1));
                RequireAirconLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireComputerLevel = requirelevel + (10 * (CompanyLevel - 1));
                break;

            case 8:
                RequireMoney = 10000 + (50000 * (CompanyLevel - 1));
                RequireAirconLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireComputerLevel = requirelevel + (10 * (CompanyLevel - 1));
                break;

            case 9:
                RequireMoney = 10000 + (50000 * (CompanyLevel - 1));
                RequireAirconLevel = requirelevel + (10 * (CompanyLevel - 1));
                RequireComputerLevel = requirelevel + (10 * (CompanyLevel - 1));
                break;
            case 10:
                EndingManager.instance.isEndding = true;
                break;
        }
    }
}
