using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [Header("가진 돈, 클릭 당, 초 당")]
    public long money;
    public long clickMoney = 1;
    public long secondMoney = 0;

    [SerializeField, Header("텍스트")]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI clickMoneyText;
    [SerializeField]
    private TextMeshProUGUI secondMoneyText;

    //초당 돈 버는 변수 DON'T TOUCH
    private float secondCountingTime;

    // Start is called before the first frame update
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
    }

    private void Start()
    {
        money = SaveLoadManager.instance.LoadData("Money", 0);
        UITextUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.instance.isGameStop)
        {
            SecondOfMoneyPlus();
            GetMoneyUpdate();
        }
    }

    private void SecondOfMoneyPlus()
    {
        secondCountingTime += Time.deltaTime;

        if(secondCountingTime >= 1)
        {
            money += secondMoney;
            UITextUpdate();
            SaveLoadManager.instance.SaveData("Money", (int)money);
            secondCountingTime = 0;
        }
    }

    public void UITextUpdate()
    {
        moneyText.text = money + " 원";
        clickMoneyText.text = clickMoney + " / 클릭 당";
        secondMoneyText.text = secondMoney + " / 초 당";
        SaveLoadManager.instance.SaveData("Money", (int)money);
    }

    public void GetMoneyUpdate()
    {
        clickMoney = Mathf.RoundToInt(UpgradeManager.instance.GetComputerMoney());
        secondMoney = Mathf.RoundToInt(UpgradeManager.instance.GetAirconMoney());
    }
}
