using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMoney : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Camera mainCamera;
    Vector3 mouseWorldPosition;

    // Update is called once per frame
    void Update()
    {
        // 마우스의 화면 좌표를 가져옴
        Vector3 mouseScreenPosition = Input.mousePosition;
        // 화면 좌표를 월드 좌표로 변환 (z축은 0으로 고정)
        if (mainCamera.gameObject.activeSelf)
        {
            mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCamera.nearClipPlane));
            mouseWorldPosition.z = 0;
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (mainCamera.gameObject.activeSelf)
        {
            Debug.Log("돈범");
            SoundManager.instance.PlaySFX(2);
            MoneyManager.instance.money += MoneyManager.instance.clickMoney;
            MoneyManager.instance.UITextUpdate();
            PoolingManager.instance.SpawnObject("Coin", mouseWorldPosition);
        }
    }
}
