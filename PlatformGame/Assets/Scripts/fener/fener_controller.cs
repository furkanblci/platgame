using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fener_controller : MonoBehaviour
{


    [SerializeField]
    SpriteRenderer fenerSprRenderer;

    [SerializeField]
    Sprite fenerOnSprite, fenerOffSprite;

    private void Awake()
    {
        fenerSprRenderer.sprite = fenerOffSprite;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            fenerSprRenderer.sprite = fenerOnSprite;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            fenerSprRenderer.sprite = fenerOffSprite;
            Invoke("FeneriKapat", 0.5f);
        }

    }

    void FeneriKapat()
    {
        fenerSprRenderer.sprite = fenerOffSprite;


    }


}
