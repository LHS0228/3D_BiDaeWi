using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
