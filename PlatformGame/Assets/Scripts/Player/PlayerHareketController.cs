using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHareketController : MonoBehaviour
{
    
    public static PlayerHareketController instance;
   
    Rigidbody2D rb;

    [SerializeField]
    GameObject normalPlayer,kilicPlayer;



    [SerializeField]
    Transform ZeminKontrolNoktasi;

    [SerializeField]
    Animator normalAnim,kilicAnim;

    [SerializeField]
    SpriteRenderer normalSprite,kilicSprite;





    public LayerMask ZeminMaske;

    public float HareketHizi;
    public float ZiplamaGucu;

    bool zemindemi;
    bool İkinciKezZiplasinmi;

    [SerializeField]
    float GeriTepkiSuresi, GeriTepkiGucu;
    float GeriTepkiSayaci;

    bool yonSagdami;

    bool playerCanverdimi;




    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        playerCanverdimi = false;
    }
    private void Update()
    {
        if (playerCanverdimi)
        {
            return;
        }




        if (GeriTepkiSayaci<=0)
        {
            

        HareketEt();
        ZıplaFNC();
        YonuDegistirFNC();

            if (normalPlayer.activeSelf)
            {

                normalSprite.color = new Color(normalSprite.color.r, normalSprite.color.g, normalSprite.color.b, 1f);


            }


            if (kilicPlayer.activeSelf)
            {

                kilicSprite.color = new Color(kilicSprite.color.r, kilicSprite.color.g, kilicSprite.color.b, 1f);


            }





        }
        else
        {
            GeriTepkiSayaci -= Time.deltaTime;


            if (yonSagdami)
            {
                rb.velocity = new Vector2(-GeriTepkiGucu, rb.velocity.y);
            }

            else
            {

                rb.velocity = new Vector2(GeriTepkiGucu, rb.velocity.y);
            }



        }


        if (normalPlayer.activeSelf)
        {



            normalAnim.SetBool("zemindemi", zemindemi);
            normalAnim.SetFloat("HareketHizi", Math.Abs(rb.velocity.x));


        }


        if (kilicPlayer.activeSelf)
        {



            kilicAnim.SetBool("zemindemi", zemindemi);
            kilicAnim.SetFloat("HareketHizi", Math.Abs(rb.velocity.x));


        }










    }
     
    void HareketEt()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * HareketHizi,rb.velocity.y);

        
    }

    void YonuDegistirFNC()
    {
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            yonSagdami = false;
        }
        else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            yonSagdami = true;
        }

    }






    void ZıplaFNC()
    {
        zemindemi=Physics2D.OverlapCircle(ZeminKontrolNoktasi.position,0.2f,ZeminMaske);
        if (Input.GetButtonDown("Jump")&&(zemindemi||İkinciKezZiplasinmi))
        {
            if (zemindemi)
            {
                İkinciKezZiplasinmi = true;

            }
            else
            {
                İkinciKezZiplasinmi = false;
            }



            rb.velocity = new Vector2(rb.velocity.x, ZiplamaGucu);
        }


        

    }

    public void GeriTepkiFNC()
    {
        GeriTepkiSayaci = GeriTepkiSuresi;
        rb.velocity = new Vector2(0, rb.velocity.y);





        if (normalPlayer.activeSelf)
        {

            normalSprite.color = new Color(normalSprite.color.r, normalSprite.color.g, normalSprite.color.b, 0.36f);


        }


        if (kilicPlayer.activeSelf)
        {

            kilicSprite.color = new Color(kilicSprite.color.r, kilicSprite.color.g, kilicSprite.color.b, 0.36f);


        }






    }

    public void PlayerCanverdiFNC()
    {

        rb.velocity = Vector2.zero;
        playerCanverdimi = true;

        if (normalPlayer.activeSelf)
        {



            normalAnim.SetTrigger("CanVerdi");


        }


        if (kilicPlayer.activeSelf)
        {


            kilicAnim.SetTrigger("CanVerdi");

        }





        

        StartCoroutine(PlayerYokEtSahneYenile());












    }

    IEnumerator PlayerYokEtSahneYenile()
    {
        yield return new WaitForSeconds(2f);

        GetComponentInChildren<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void normalKapaKilicAc()
    {

        normalPlayer.SetActive(false);
        kilicPlayer.SetActive(true);
    }










}

