using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [Header("���� ��, Ŭ�� ��, �� ��")]
    public int money;
    public int clickMoney = 1;
    public int secondMoney = 0;

    [SerializeField, Header("�ؽ�Ʈ")]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI clickMoneyText;
    [SerializeField]
    private TextMeshProUGUI secondMoneyText;

    //�ʴ� �� ���� ���� DON'T TOUCH
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
        UITextUpdate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.instance.isGameStop)
        {
            SecondOfMoneyPlus();
        }
    }

    private void SecondOfMoneyPlus()
    {
        secondCountingTime += Time.deltaTime;

        if(secondCountingTime >= 1)
        {
            money += secondMoney;
            UITextUpdate();
            secondCountingTime = 0;
        }
    }

    public void UITextUpdate()
    {
        moneyText.text = money + " won";
        clickMoneyText.text = clickMoney + " / click";
        secondMoneyText.text = secondMoney + " / second";
    }

}
