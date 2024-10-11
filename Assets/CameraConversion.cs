using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraType
{
    Camera2D,
    Camera3D,
    CameraEnding
}

public class CameraConversion : MonoBehaviour
{
    public static CameraConversion instance;

    [SerializeField] public GameObject camera2D;
    [SerializeField] public GameObject camera3D;
    [SerializeField] public GameObject cameraEnding;

    private SoundManager soundManager;
    public void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CameraChange(CameraType type)
    {
        cameraEnding.SetActive(false);
        camera2D.SetActive(false);
        camera3D.SetActive(false);

        switch (type)
        {
            case CameraType.Camera2D:
                camera2D.SetActive(true);
                break;
            case CameraType.Camera3D:
                camera3D.SetActive(true);
                break;
            case CameraType.CameraEnding:
                cameraEnding.SetActive(true);
                break;
        }
    }

    public void CameraChangeButton()
    {
        if(camera2D.activeSelf)
        {
            camera2D.SetActive(false);
            camera3D.SetActive(true);
        }
        else
        {
            camera2D.SetActive(true);
            camera3D.SetActive(false);
        }
        soundManager.PlaySFX(0);
    }
}
