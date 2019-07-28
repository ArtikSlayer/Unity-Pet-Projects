using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBox : MonoBehaviour
{

    public GameObject ingredient;
    private Animator anim;

    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("openFoodBox",false);
    }
    public void Interact(PlayerInteraction player)
    {
        anim.SetBool("openFoodBox", true);
        
        if (anim.GetBool("openFoodBox")) {
            anim.Play("Opening");
            player.SetItem(ingredient);
            Debug.Log("Мы ингридиенты из ФудБокса!");
        }

        anim.SetBool("openFoodBox",false);
    }
}
