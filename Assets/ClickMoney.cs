using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMoney : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("돈범");
        MoneyManager.instance.money += MoneyManager.instance.clickMoney;
        MoneyManager.instance.UITextUpdate();
    }
}
