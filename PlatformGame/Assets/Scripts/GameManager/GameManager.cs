using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;


    public int ToplananCoinAdet;







    private void Awake()
    {

        instance = this;
    }


    private void Start()
    {

        ToplananCoinAdet = 0;
    }




}
