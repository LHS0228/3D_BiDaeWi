using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckCameraMode : MonoBehaviour
{
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private Camera Camera2D; // 2D용 카메라
    [SerializeField] private Camera Camera3D; // 3D용 카메라


    public void Update()
    {
        CheckMode();
    }

    public void CheckMode()
    {
        if (Camera2D.gameObject.activeInHierarchy)
        {
            UIPanel.SetActive(true);
        }
        else if (Camera3D.gameObject.activeInHierarchy)
        {
            UIPanel.SetActive(false);
        }
        else
        {
            Debug.Log("카메라 못 찾음");
        }

    }
}
