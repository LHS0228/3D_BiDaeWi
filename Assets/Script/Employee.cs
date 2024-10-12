using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Employee 클래스는 직원 개인의 정보를 위한 스크립트
public class Employee
{
    public string Name { get; set; }
    public string Trait { get; set; }
    public string Race { get; set; }
    public bool IsHire { get; set; }

    public float Touch_Bonus { get; set; }
    public float Auto_Bonus { get; set; }

    private List<string> Traits = new List<string>() { "성급한", "느긋한", "신중한", "재빠른" };
    private List<string> Races = new List<string>() { "인간", "엘프", "오크" };

    // 생성자: 이름을 받아서 랜덤 특성을 부여
    public Employee(string name, bool ishire)
    {
        this.Name = name;
        RandomRace();
        RandomTrait();
        this.IsHire = ishire;
        Touch_Bonus = 0;
        Auto_Bonus = 0;
    }

    private void RandomRace()
    {
        int RandomIndex = Random.Range(0, Races.Count);
        Race = Races[RandomIndex];
    }
    private void RandomTrait()
    {
        int RandomIndex = Random.Range(0, Traits.Count);
        Trait = Traits[RandomIndex];
    }
    public void Hire()
    {
        IsHire = true;
        ActiveTrait();
    }

    private void Fire()
    {
        IsHire = false;
        DeActiveTrait();
    }
    // 각 특성에 해당하는 직원 고용시 활성화 됨 튜플 사용 터치 당, 자동 재화 관련
    public (float, float) ActiveTrait()
    {
        if (Touch_Bonus == 0 && Auto_Bonus == 0) // 계속 랜덤 값 바뀌는 거 방지
        {
            switch (Trait)
            {
                case "성급한":
                    Touch_Bonus = Random.Range(0.01f, 0.1f);
                    Auto_Bonus = Random.Range(0.01f, 0.05f);
                    break;
                case "느긋한":
                    Touch_Bonus = Random.Range(0.01f, 0.05f);
                    Auto_Bonus = Random.Range(0.01f, 0.1f);
                    break;
                case "재빠른":
                    Touch_Bonus = Random.Range(0.1f, 0.2f);
                    Auto_Bonus = 0f;
                    break;
                case "신중한":
                    Touch_Bonus = 0f;
                    Auto_Bonus = Random.Range(0.1f, 0.2f);
                    break;
            }
        }

        return (Touch_Bonus, Auto_Bonus);
    }

    public void DeActiveTrait()
    {
        Touch_Bonus = 0f;
        Auto_Bonus = 0f;
    }
}
