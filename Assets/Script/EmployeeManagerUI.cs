using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class EmployeeManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject EmployeeInfoPrefab; // 직원 텍스트 정보
    [SerializeField] private GameObject EmployeeImagePrefab; // 직원 이미지 프리팹
    [SerializeField] private Transform EmployeeContentList;
    [SerializeField] private GameObject HirePanel;
    [SerializeField] private Transform RandomEmployee;

    private EmployeeManager employeemanager;
    private SoundManager soundmanager;

    private void Awake()
    {
        soundmanager = FindObjectOfType<SoundManager>();
        HirePanel.SetActive(false);
    }
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
        float PrefabHeight = 260f;

        for (int i = 0; i < count; i++)
        {
            Employee employee = employees[i];

            GameObject Employee_Info_Object = Instantiate(EmployeeInfoPrefab, RandomEmployee);

            Button Hire_Button = Employee_Info_Object.transform.Find("HireButton").GetComponent<Button>();

            Employee LocalEmployee = employee;
            Hire_Button.onClick.AddListener(() => HireEmployee(LocalEmployee, Hire_Button));

            RectTransform rectTransform = Employee_Info_Object.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(-250f, PrefabHeight - (i * 130f));

            // 밑에는 직원 정보 알려주기 위한 코드임
            TextMeshProUGUI nameText = Employee_Info_Object.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI raceText = Employee_Info_Object.transform.Find("RaceText").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI traitText = Employee_Info_Object.transform.Find("TraitText").GetComponent<TextMeshProUGUI>();

            nameText.text = employee.Name;
            raceText.text = employee.Race;
            traitText.text = employee.Trait;

        }

    }

    private IEnumerator ShowHireEmployees(Employee employee, Button hirebutton)
    {
        GameObject Hire_Info = Instantiate(EmployeeInfoPrefab, EmployeeContentList);

        GameObject Hire_Image = Instantiate(EmployeeImagePrefab, Hire_Info.transform);
        EmployeeImage randomchar = Hire_Image.GetComponent<EmployeeImage>();
        if (randomchar != null)
        {
            randomchar.SetRandomCharacter(employee);
        }

        RectTransform rectTransform = Hire_Info.GetComponent<RectTransform>();

        TextMeshProUGUI nameText = Hire_Info.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI raceText = Hire_Info.transform.Find("RaceText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI traitText = Hire_Info.transform.Find("TraitText").GetComponent<TextMeshProUGUI>();

        nameText.text = employee.Name;
        raceText.text = employee.Race;
        traitText.text = employee.Trait;

        yield return null;

        Button HireEmployeeButton = Hire_Info.transform.Find("HireButton").GetComponent<Button>();
        HireEmployeeButton.gameObject.SetActive(false);
        Debug.Log(HireEmployeeButton.gameObject.activeSelf);
    }

    public void HireButton()
    {
        if (HirePanel.activeSelf)
        {
            HirePanel.SetActive(false);
        }
        else
        {
            HirePanel.SetActive(true);
        }
        soundmanager.PlaySFX(3);

    }
    public void HireEmployee(Employee employee, Button hirebutton)
    {
        if (employeemanager.HireEmployee(employee))
        {
            StartCoroutine(ShowHireEmployees(employee, hirebutton));
            hirebutton.gameObject.SetActive(false);
            Debug.Log($"{employee.Name} , {employee.Race} , {employee.Trait} 추가");
            soundmanager.PlaySFX(1);
        }
        else
        {
            Debug.Log("고용 x");
        }

        Debug.Log($"버튼 상태" + hirebutton.gameObject.activeSelf);
    }
    public void FireButton()
    {

    }

    // 새로 고침 버튼 
    public void ReButton()
    {
        // EmployeeListParent의 자식들을 확인한 후 해당 이름을 삭제 후 다시 리스트에 추가 해 표시
        foreach (Transform child in RandomEmployee)
        {
            Destroy(child.gameObject);
        }

        List<Employee> RandomEmployees = employeemanager.Get_Random_Employees(5);
        ShowDisplayInfo(RandomEmployees);
        soundmanager.PlaySFX(3);
    }

}
