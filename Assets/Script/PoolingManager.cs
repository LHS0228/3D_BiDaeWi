using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager instance;

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinParent;
    [SerializeField] private GameObject[] coinList;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        coinList = new GameObject[30];

        for (int i = 0; i < coinList.Length; i++)
        {
            coinList[i] = Instantiate(coinPrefab, coinParent);
            coinList[i].SetActive(false);
        }
    }

    public void SpawnObject(string name, Vector3 _position)
    {
        switch(name)
        {
            case "Coin":
                for(int i =0; i < coinList.Length; i++)
                {
                    if (coinList[i].activeSelf == false)
                    {
                        coinList[i].SetActive(true);
                        coinList[i].transform.position = _position;
                        break;
                    }
                    else if (i == coinList.Length - 1)
                    {
                        Debug.Log("50개 생성되어 있음 제한");
                        break;
                    }
                }
                break;
        }
    }
}
