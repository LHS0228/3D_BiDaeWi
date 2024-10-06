using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class EmployeeManager : MonoBehaviour
{
    public List<Employee> employees = new List<Employee>();
    private string[] race = { "인간", "엘프", "오크" };
    private string[] characteristic = {
            "성급한", "느긋한", "아침형 인간", "부엉이", "신속한", "신중한", "협동심"
        };
    private bool ishire = false;

    private TextMeshProUGUI Employee1;

    private void Awake()
    {
        Generation_Employee(10);
        foreach (Employee employee in employees) // 직원 생성 확인하려고 만든 출력용 함수
        {
            Debug.Log(employee.name + "의 특성 : " + employee.characteristic + " 종족 : " + employee.race);
        }
    }

    private void Generation_Employee(int count)
    {
        for (int i = 0; i < count; i++)
        {
            string RandomRace = race[Random.Range(0, race.Length)];
            string RandomCharacteristic = characteristic[Random.Range(0, characteristic.Length)];
            Employee newEmployee = new Employee($"Employee {i + 1}", RandomRace, RandomCharacteristic, ishire);
            employees.Add(newEmployee);
        }
    }
    public List<Employee> GetRandomEmployees(int count)
    {
        // 랜덤 직원 선택할라고 만듬
        List<Employee> RandomEmployees = new List<Employee>();
        // 랜덤 직원 중복 선택 방지하기위해 만듬
        HashSet<int> SelectIndex = new HashSet<int>();


        // 랜덤 직원 선택 수가 count보다 적을 때 그리고 선택가능한 직원이 생성된 전체 직원수보다 적을 때
        while (RandomEmployees.Count < count && SelectIndex.Count < employees.Count)
        {
            int RandomIndex = Random.Range(0, employees.Count);
            // 만약 선택된 인덱스가 HashSet에 없으면 직원 리스트에 추가 
            if (!SelectIndex.Contains(RandomIndex))
            {
                SelectIndex.Add(RandomIndex);
                RandomEmployees.Add(employees[RandomIndex]);
            }
        }
        return RandomEmployees;
    }

}
