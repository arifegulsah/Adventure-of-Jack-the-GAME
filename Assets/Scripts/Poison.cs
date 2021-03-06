using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Poison : MonoBehaviour
{

    private Text interactUI;
    public Text interactEminMisin;

    private bool isInRange = false;

    public Animator animator;

    public int coinsToAdd;

    public AudioClip dieSound;


    void Awake()
    {
        interactEminMisin = GameObject.FindGameObjectWithTag("eminMisinText").GetComponent<Text>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();

    }


    //inputlar? keydown gibi buraya yaz?yoruz.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
           // interactUI.enabled = false;
            //interactEminMisin.enabled = true;
            DrinkPoison();
        }
    }

    void FixedUpate()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            DrinkPoison();
        }
    }

    void DrinkPoison()
    {
        //animator.SetTrigger("OpenChest");
        // Inventory.instance.AddCoins(coinsToAdd);
        //AudioManager.instance.PlayClipAt(dieSound, transform.position);
        //GetComponent<BoxCollider2D>().enabled = false;
        //interactUI.enabled = false;
        //PlayerHealth.instance.Die();
        DontDestroyOnLoadScene.instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("Outro");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactEminMisin.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactEminMisin.enabled = false;
            isInRange = false;
        }
    }


}
