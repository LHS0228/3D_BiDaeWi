using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] PanelList;

    private void Awake()
    {
        foreach (GameObject panel in PanelList) 
        {
            panel.SetActive(false);
        }
    }

    public void ShowPanel(int index)
    {
        foreach (GameObject panel in PanelList)
        {
            panel.SetActive(false);
        }

        if ( index >= 0 && index < PanelList.Length)
        {
            PanelList[index].SetActive(true);
        }
    }
}
