using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class EmployeeManager : MonoBehaviour
{
    public List<Employee> AllEmployees = new List<Employee>();
    public List<Employee> GetEmployees = new List<Employee>();
    public List<Employee> IsHireEmployees = new List<Employee>();

    private int HireCost = 5000;
    private TextMeshProUGUI Employee1;
    private int MaxHireEmployee = 5;

    private void Awake()
    {
        Generation_Employee(25);
    }

    private void Start()
    {
        //SaveLoadManager.instance.LoadEmployeeData(out AllEmployees, out GetEmployees, out IsHireEmployees);
    }

    private void Generation_Employee(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Employee newEmployee = new Employee($"{i + 1}", false);
            AllEmployees.Add(newEmployee);
        }

        // 확인 함수
        foreach (Employee employee in AllEmployees)
        {
            Debug.Log($"Name: {employee.Name}, Race: {employee.Race}, Trait: {employee.Trait}");
        }
    }

    public List<Employee> Get_Random_Employees(int count)
    {
        List<Employee> getEmployees = new List<Employee>();

        // 랜덤 직원 중복 선택 방지하기위해 만듬
        HashSet<int> selectIndex = new HashSet<int>();

        // 랜덤 직원 선택 수가 count보다 적을 때 그리고 선택가능한 직원이 생성된 전체 직원수보다 적을 때
        while (getEmployees.Count < count && selectIndex.Count < AllEmployees.Count)
        {
            int RandomIndex = Random.Range(0, AllEmployees.Count);
            // 만약 선택된 인덱스가 HashSet에 없으면 직원 리스트에 추가 
            if (!selectIndex.Contains(RandomIndex))
            {
                selectIndex.Add(RandomIndex);
                getEmployees.Add(AllEmployees[RandomIndex]);
            }
        }
        return getEmployees;
    }

    public bool HireEmployee(Employee employee)
    {
        if (IsHireEmployees.Count < MaxHireEmployee && !employee.IsHire)
        {
            if (MoneyManager.instance.money >= HireCost)
            {
                MoneyManager.instance.money -= HireCost;
                employee.Hire();
                IsHireEmployees.Add(employee);
                Debug.Log($"{employee.Name} 고용");

                // 직원 고용 후 저장
                //SaveLoadManager.instance.SaveEmployeeData(AllEmployees, GetEmployees, IsHireEmployees);
                return true;
            }
            else
            {
                Debug.Log("고용 할 비용이 부족합니다.");
            }
        }
        return false;
    }

    public List<Employee> GetHiredEmployee()
    {
        return IsHireEmployees;
    }
}
