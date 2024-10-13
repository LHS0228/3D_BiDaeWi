using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager instance;
    /*
    건물(물체) LoadBuildings
    건물 레벨 CompanyLevel
    컴퓨터 레벨 ComputerLevel
    에어컨 레벨 AirconLevel
    직원 정보
    소리 볼륨 SFXVolume, BGMVolume
    튜토리얼 봤는지 확인 Y/N OkTutorial
    오프닝 봤는지 확인 Y/N OkOpening
     */

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveData(string saveName, int num)
    {
        PlayerPrefs.SetInt(saveName, num);
    }

    public void SaveData(string saveName, float num)
    {
        PlayerPrefs.SetFloat(saveName, num);
    }

    public int LoadData(string loadName, int num)
    {
        return PlayerPrefs.GetInt(loadName, num);
    }

    public float LoadData(string loadName, float num)
    {
        return PlayerPrefs.GetFloat(loadName, num);
    }

    public void AllDateDestory()
    {
        PlayerPrefs.DeleteAll();
    }

    // 직원 리스트를 저장하는 함수
    public void SaveEmployeeData(List<Employee> allEmployees, List<Employee> getEmployees, List<Employee> isHireEmployees)
    {
        // JSON 직렬화
        string allEmployeesJson = JsonConvert.SerializeObject(allEmployees);
        string getEmployeesJson = JsonConvert.SerializeObject(getEmployees);
        string isHireEmployeesJson = JsonConvert.SerializeObject(isHireEmployees);

        // 직렬화된 데이터를 PlayerPrefs에 저장
        PlayerPrefs.SetString("AllEmployees", allEmployeesJson);
        PlayerPrefs.SetString("GetEmployees", getEmployeesJson);
        PlayerPrefs.SetString("IsHireEmployees", isHireEmployeesJson);
        PlayerPrefs.Save(); // PlayerPrefs 저장
    }

    // 직원 리스트를 불러오는 함수
    public void LoadEmployeeData(out List<Employee> allEmployees, out List<Employee> getEmployees, out List<Employee> isHireEmployees)
    {
        // JSON 데이터를 PlayerPrefs에서 불러오기
        string allEmployeesJson = PlayerPrefs.GetString("AllEmployees", "");
        string getEmployeesJson = PlayerPrefs.GetString("GetEmployees", "");
        string isHireEmployeesJson = PlayerPrefs.GetString("IsHireEmployees", "");

        // 데이터가 비어 있지 않으면 역직렬화하여 리스트로 변환
        allEmployees = !string.IsNullOrEmpty(allEmployeesJson) ? JsonConvert.DeserializeObject<List<Employee>>(allEmployeesJson) : new List<Employee>();
        getEmployees = !string.IsNullOrEmpty(getEmployeesJson) ? JsonConvert.DeserializeObject<List<Employee>>(getEmployeesJson) : new List<Employee>();
        isHireEmployees = !string.IsNullOrEmpty(isHireEmployeesJson) ? JsonConvert.DeserializeObject<List<Employee>>(isHireEmployeesJson) : new List<Employee>();
    }
}
