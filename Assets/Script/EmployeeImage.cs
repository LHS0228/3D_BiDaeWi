using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeImage : MonoBehaviour
{
    [SerializeField] private Sprite[] Hairsprites;
    [SerializeField] private Sprite[] Bodysprites;
    [SerializeField] private Sprite[] Clothessprites;
    [SerializeField] private Sprite[] Facesprites;

    private Image Hairimage;
    private Image Bodyimage;
    private Image Clothesimage;
    private Image Faceimage;

    public void SetRandomCharacter(Employee employee)
    {
        Hairimage = transform.Find("Hair").GetComponent<Image>();
        Bodyimage = transform.Find("Body").GetComponent<Image>();
        Clothesimage = transform.Find("Clothes").GetComponent<Image>();
        Faceimage = transform.Find("Face").GetComponent<Image>();

        if (Hairimage == null || Bodyimage == null || Clothesimage == null || Faceimage == null)
        {
            Debug.LogError("One or more Image components are missing!");
            return; // 컴포넌트가 없으면 함수 종료
        }
        int randomHairIndex = Random.Range(0, Hairsprites.Length);
        int randomBodyIndex = Random.Range(0, Bodysprites.Length);
        int randomClothesIndex = Random.Range(0, Clothessprites.Length);
        int randomFaceIndex = Random.Range(0, Facesprites.Length);

        Hairimage.sprite = Hairsprites[randomHairIndex];
        Bodyimage.sprite = Bodysprites[randomBodyIndex];
        Clothesimage.sprite = Clothessprites[randomClothesIndex];
        Faceimage.sprite = Facesprites[randomFaceIndex];

        Debug.Log($"Hair sprite: {Hairimage.sprite}");
        Debug.Log($"Body sprite: {Bodyimage.sprite}");
        Debug.Log($"Clothes sprite: {Clothesimage.sprite}");
        Debug.Log($"Face sprite: {Faceimage.sprite}");
    }
}
