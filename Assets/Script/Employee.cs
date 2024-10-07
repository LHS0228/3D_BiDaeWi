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

    private List<string> Traits = new List<string>() { "성급한", "느긋한", "아침형 인간", "부엉이", "신속한", "신중한", "협동심" };
    private List<string> Races = new List<string>() { "인간", "엘프", "오크" };

    // 생성자: 이름을 받아서 랜덤 특성을 부여
    public Employee(string name, bool ishire)
    {
        this.Name = name;
        RandomRace();
        RandomTrait();
        this.IsHire = ishire;
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
    // 각 특성에 해당하는 직원 고용시 활성화 됨
    private void ActiveTrait()
    {
        switch (Trait)
        {
            case "성급한":

                break;

            case "느긋한":

                break;
            case "아침형 인간":

                break;
            case "부엉이":

                break;
            case "신속한":

                break;
            case "신중한":

                break;
            case "협동심":

                break;

        }
    }

    private void DeActiveTrait()
    {
        switch (Trait)
        {
            case "성급한":

                break;

            case "느긋한":

                break;
            case "아침형 인간":

                break;
            case "부엉이":

                break;
            case "신속한":

                break;
            case "신중한":

                break;
            case "협동심":

                break;

        }
    }
}
