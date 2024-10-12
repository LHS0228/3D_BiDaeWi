using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class EndingManager : MonoBehaviour
{
    //메인[0], 서브(오른날개)[1], 그린(왼팔)[2], 블루(왼다리)[3], 퍼플(오른다리)[4], 레드(왼날개)[5], 브라운(오른팔)[6]
    [SerializeField] private GameObject[] buildings;
    [SerializeField] private GameObject[] robot_parts;
    [SerializeField] private GameObject robot;
    [SerializeField] private GameObject[] other_Camera;
    [SerializeField] private GameObject robot_Camera;

    [SerializeField] private GameObject endding_Picture;
    [SerializeField] private GameObject[] canvers;

    private bool isEndding;
    private float setTime;

    private int counting;

    // Update is called once per frame
    void Update()
    {
        if(isEndding)
        {
            setTime += Time.deltaTime;
            switch(counting)
            {
                case 0:
                    for (int i = 0; i < canvers.Length; i++)
                    {
                        canvers[i].SetActive(false);
                    }

                    CameraConversion.instance.CameraChange(CameraType.Camera3D);
                    EnddingStart();
                    break;
                case 1:
                    Robot_Transformation();
                    break;
            }
        }
    }

    void EnddingStart()
    {
        switch(setTime)
        {
            case > 4f:
                buildings[5].GetComponent<Animator>().enabled = true;
                if (setTime > 5f)
                {
                    counting = 1;
                    setTime = 0;
                }
                break;
            case > 3.5f:
                buildings[1].GetComponent<Animator>().enabled = true;
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
                buildings[6].GetComponent<Animator>().enabled = true;
                break;
            case > 1:
                buildings[0].GetComponent<Animator>().enabled = true;
                break;
        }
    }

    void Robot_Transformation()
    {
        switch(setTime)
        {
            case > 43:
                endding_Picture.SetActive(true);
                endding_Picture.GetComponent<Image>().DOColor(new Color(1, 1, 1, 1), 7);
                break;
            case > 40:
                robot_Camera.transform.DOMove(new Vector3(-231.6f, 313.2f, -180.6f), 8);
                break;

            case > 39:
                robot.transform.DOMoveY(300f, 15);
                break;

            case > 37:
                robot_parts[1].GetComponent<Animator>().Play("Bird");
                robot_parts[5].GetComponent<Animator>().Play("Bird");
                break;

            case > 32:
                robot_parts[6].GetComponent<Animator>().Play("GoRobot");
                robot_parts[2].GetComponent<Animator>().Play("GoRobot");
                break;

            case > 29:
                robot_Camera.transform.DOMove(new Vector3(-196.4f, 192.7f, -53.5f), 4);
                robot_Camera.transform.DORotate(new Vector3(9.2f, 11.28f, 0), 4);
                break;

            case >27:
                robot_Camera.transform.DOMove(new Vector3(-193.75f, 208f, -14.7f), 1);
                robot_Camera.transform.DORotate(new Vector3(9.2f, 16.73f, 0), 1);
                break;

            case >24:
                robot_parts[0].GetComponent<Animator>().Play("HeadOn");
                robot_Camera.transform.DOMove(new Vector3(-193.75f, 208f, -14.7f), 1);
                robot_Camera.transform.DORotate(new Vector3(9.2f, 16.73f, 0), 1);
                break;

            case > 21:
                robot_Camera.transform.DOMove(new Vector3(-173.4f, 195.8f, 45.2f), 1);
                robot_Camera.transform.DORotate(new Vector3(9.2f, 203.9f, 0), 1);
                break;

            case > 20:
                robot_parts[1].SetActive(true);
                robot_parts[5].SetActive(true);
                break;

            case > 18:
                robot_Camera.transform.DOMove(new Vector3(-198.4f, 184.7f, -44.1f), 1);
                robot_Camera.transform.DORotate(new Vector3(9.2f, 13.6f, 0), 1);
                break;

            case > 15:
                if(setTime > 16.5f)
                {
                    robot_Camera.transform.DOMove(new Vector3(-189f, 156, 1), 0.5f);
                    robot_Camera.transform.DORotate(new Vector3(-38, 13.6f, 0), 0.5f);
                }
                else
                {
                    robot_parts[3].SetActive(true);
                    robot_parts[4].SetActive(true);
                    robot_Camera.transform.DOMove(new Vector3(-188.3f, 132, -5), 0.5f);
                    robot_Camera.transform.DORotate(new Vector3(0, 13.6f, 0), 0.5f);
                }
                break;

            case > 9:
                if(setTime > 11.5f)
                {
                    robot_Camera.transform.DOMove(new Vector3(-151.8f, 196.4f, -5.3f), 1);
                    robot_Camera.transform.DORotate(new Vector3(0, -66.1f, 0), 1);
                }
                else
                {
                    robot_parts[2].SetActive(true);
                    robot_Camera.transform.DOMove(new Vector3(-117.7f, 205.5f, -17), 1);
                    robot_Camera.transform.DORotate(new Vector3(0, 13.6f, 0),1);
                }
                break;

            case > 2:
                robot_parts[6].SetActive(true);
                robot_Camera.transform.position = new Vector3(-248, 192.1f, 5.5f);
                robot_Camera.transform.rotation = Quaternion.Euler(0, 27.5f, 0);

                if (setTime > 6)
                {
                    robot_Camera.transform.DOMove(new Vector3(-210.3f, 192.1f, 5.5f), 1);
                    robot_Camera.transform.DORotate(new Vector3(0, 58.7f, 0), 1);
                }
                break;

            case > 0:
                CameraConversion.instance.camera3D.GetComponent<Camera>().fieldOfView = 84.9f;
                robot_parts[0].SetActive(true);
                robot_Camera.SetActive(true);
                other_Camera[0].SetActive(false);
                other_Camera[1].SetActive(false);
                robot_Camera.transform.position = new Vector3(-189.4f, 157.4f, -11.4f);
                robot_Camera.transform.rotation = Quaternion.Euler(-40, 14.5f, 0);
                break;
        }
    }
}
