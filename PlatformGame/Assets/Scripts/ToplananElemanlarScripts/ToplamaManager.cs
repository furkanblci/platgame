 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaManager : MonoBehaviour
{
    [SerializeField]
    bool coinmi;

    [SerializeField]
    GameObject CoinEfekt;

    bool toplandimi;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")&& !toplandimi)
        {
            toplandimi = true;

            GameManager.instance.ToplananCoinAdet++;
            UIManager.instance.CoinAdetGuncelle();


            Destroy(gameObject);
            Instantiate(CoinEfekt,transform.position,Quaternion.identity);
        }

    }
}
