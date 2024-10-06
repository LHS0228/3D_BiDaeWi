using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 직원 종족, 공용 한 개씩 랜덤 부여 - 직원 관리 메뉴에서 관리가능
// 고용버튼을 눌렀을 때 종족, 공용이 부여된 직원 5명을 제시 - 한 명 고용시 나머지 삭제 후 5명 다시 제시
// 만약 돌리고 싶으면 1000원 주고 5명 제시
// 직원 재교육: 직원의 스킬 및 수치 랜덤 변경, 종족 특성은 수치만 공용은 수치 + 스킬 종류까지
// 직원 역량강화: 강화 3회까지
// 직원 해고: 삭제 시 해당 직원에 투자한 자원 25퍼 회수
public class Employee
{
    public string name; // 이름
    public string characteristic; // 특성
    public string race; // 종족
    public bool ishire;

    // 생성자: 이름을 받아서 랜덤 특성을 부여
    public Employee(string name, string race, string characteristic, bool ishire)
    {
        this.name = name;
        this.race = race;
        this.characteristic = characteristic;
        this.ishire = ishire;
    }
    
}
