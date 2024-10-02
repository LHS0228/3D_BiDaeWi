using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    [SerializeField] private float minYPower = 0;
    [SerializeField] private float maxYPower = 0;
    [SerializeField] private float minXPower = 0;
    [SerializeField] private float maxXPower = 0;

    [Header("하애지는 시간")]
    [SerializeField] private float duration = 1;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    float setTime = 0;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        rigid.AddForce(new Vector2(Random.Range(minXPower, maxXPower), Random.Range(minYPower, maxYPower)));
    }

    private void FixedUpdate()
    {
        setTime += Time.deltaTime;

        float alpha = Mathf.Clamp01(1 - (setTime / duration));
        spriteRenderer.color = new Color(1, 1, 1, alpha);

        if(spriteRenderer.color.a == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        transform.position = new Vector3(0, 0, 0);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        setTime = 0;
    }
}
