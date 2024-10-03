using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buildings;
    private bool isEndding;
    private float setTime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            isEndding = true;
        }

        if(isEndding)
        {
            setTime += Time.deltaTime;
            EnddingStart();
        }
    }

    void EnddingStart()
    {
        switch(setTime)
        {
            case > 4f:
                buildings[6].GetComponent<Animator>().enabled = true;
                break;
            case > 3.5f:
                buildings[5].GetComponent<Animator>().enabled = true;
                break;
            case > 3f:
                buildings[4].GetComponent<Animator>().enabled = true;
                break;
            case > 2.5f:
                buildings[3].GetComponent<Animator>().enabled = true;
                break;
            case > 2.0f:
                buildings[2].GetComponent<Animator>().enabled = true;
                break;
            case > 1.5f:
                buildings[1].GetComponent<Animator>().enabled = true;
                break;
            case > 1:
                buildings[0].GetComponent<Animator>().enabled = true;
                break;
        }
    }
}
