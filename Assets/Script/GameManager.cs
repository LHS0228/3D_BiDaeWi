using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<EmployeeManager> employees = new List<EmployeeManager>();
    private string[] names = { "가", "나", "다", "라", "마", "바", "사"};

    [SerializeField]
    public bool isGameStop;

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

        for (int i = 0; i < 7; i++)
        {
            string employeeName = names[Random.Range(0, names.Length)];
            EmployeeManager newEmployee = new EmployeeManager(employeeName);
            employees.Add(newEmployee);
        }

        foreach (EmployeeManager employee in employees) // 직원 생성 확인하려고 만든 함수
        {
            Debug.Log(employee.name + "의 특성 : " + employee.characteristic + " 종족 : " + employee.race);
        }
    }

    void Update()
    {
        
    }
}
