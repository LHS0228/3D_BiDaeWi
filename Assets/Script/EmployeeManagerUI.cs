using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class EmployeeManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject EmployeeInfoPrefab;
    [SerializeField] private Transform EmployeeContentList;
    private EmployeeManager employeemanager;


    private void Start()
    {
        // 씬에서 찾으면 해당 컴포넌트 반환 
        employeemanager = FindObjectOfType<EmployeeManager>();
        // 매니저에 있는 직원 생성 함수 괄호 안 숫자는 생성 수를 뜻함
        List<Employee> RandomEmployees = employeemanager.Get_Random_Employees(5);

        ShowDisplayInfo(RandomEmployees);
    }

    private void ShowDisplayInfo(List<Employee> employees)
    {

        int count = Mathf.Min(5, employees.Count);
        float PrefabHeight = 84f;

        for (int i = 0; i < count; i++)
        {
            Employee employee = employees[i];

            GameObject Employee_Info_Object = Instantiate(EmployeeInfoPrefab, EmployeeContentList);

            RectTransform rectTransform = Employee_Info_Object.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(-250f, PrefabHeight - (i * 100f));

            // 밑에는 직원 정보 알려주기 위한 코드임
            TextMeshProUGUI nameText = Employee_Info_Object.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI raceText = Employee_Info_Object.transform.Find("RaceText").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI traitText = Employee_Info_Object.transform.Find("TraitText").GetComponent<TextMeshProUGUI>();

            nameText.text = employee.Name;
            raceText.text = employee.Race;
            traitText.text = employee.Trait;

        }

    }

    // 새로 고침 버튼 
    public void ReButton()
    {
        // EmployeeListParent의 자식들을 확인한 후 해당 이름을 삭제 후 다시 리스트에 추가 해 표시
        foreach (Transform child in EmployeeContentList)
        {
            if (child.name == "Employee 1(Clone)")
            {
                Destroy(child.gameObject);
            }
        }

        List<Employee> RandomEmployees = employeemanager.Get_Random_Employees(5);
        ShowDisplayInfo(RandomEmployees);
    }

}
