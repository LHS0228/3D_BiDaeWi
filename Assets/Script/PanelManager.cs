using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] PanelList;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        foreach (GameObject panel in PanelList) 
        {
            panel.SetActive(false);
        }
        PanelList[0].SetActive(true);
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
            soundManager.PlaySFX(3);
        }
    }
}
