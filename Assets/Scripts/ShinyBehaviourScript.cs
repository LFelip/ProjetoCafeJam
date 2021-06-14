using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShinyBehaviourScript : MonoBehaviour
{
    private SpriteRenderer image;

    private Color color;
    private Color transparentColor;
    private Color opaqueColor;

    public float blinkRate;
    public float blinkDuration;

    private bool isBlinking;
    private float blinkTimer;
    private float blinkRateTimer;

    // Start is called before the first frame update
    void Start()
    {
        isBlinking = false;

        image = gameObject.GetComponent<SpriteRenderer>();
        color = image.color;
        transparentColor = image.color;
        opaqueColor = image.color;

        transparentColor.a = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (isBlinking)
        {
            if (blinkTimer > blinkDuration)
            {
                isBlinking = false;
                image.color = opaqueColor;
            }
            else
            {
                if (blinkRateTimer >= blinkRate)
                {
                    Blink();
                }
            }

            blinkRateTimer += Time.deltaTime;
        }

    }

    private void Blink()
    {

        if (image.color.a == 0)
        {
            image.color = opaqueColor;
        }
        else
        {
            image.color = transparentColor;
        }

        blinkTimer += Time.deltaTime;
        blinkRateTimer = 0;
    } 

    public void StartBlinking()
    {
       
        isBlinking = true;
        blinkRateTimer = blinkRate; //starts changing
        blinkTimer = 0;
    }
       
       

}
