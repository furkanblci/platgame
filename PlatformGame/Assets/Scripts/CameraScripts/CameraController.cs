using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    






    PlayerHareketController Player;

    [SerializeField]
    Collider2D boundsBox;

    float halfYukseklik, halfGenislik;

    Vector2 sonPos;

    [SerializeField]
     Transform backgrounds;

    


    private void Awake()
    {

        Player = Object.FindObjectOfType<PlayerHareketController>();
    }


    private void Update()
    {
        if (Player != null)
        {

            transform.position = new Vector3(Mathf.Clamp(Player.transform.position.x, boundsBox.bounds.min.x + halfGenislik, boundsBox.bounds.max.x - halfGenislik),
                                                        Mathf.Clamp(Player.transform.position.y, boundsBox.bounds.min.y + halfYukseklik, boundsBox.bounds.max.y - halfYukseklik),
                                                        transform.position.z);


        }

        BackgroundHareketFNC();
    }

    private void Start()
    {

        halfYukseklik = Camera.main.orthographicSize;

        halfGenislik = halfYukseklik * Camera.main.aspect;

        sonPos = transform.position;

    }







     void BackgroundHareketFNC()
    {
       Vector2 aradakiFark = new Vector2((transform.position.x - sonPos.x),(transform.position.y-sonPos.y));

       backgrounds.position+= new Vector3(aradakiFark.x, aradakiFark.y, 0f);

        sonPos = transform.position;

    }


}
