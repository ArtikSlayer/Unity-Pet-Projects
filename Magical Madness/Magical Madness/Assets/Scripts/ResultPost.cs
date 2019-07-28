using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPost : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact(GameObject item ,PlayerInteraction player)
    {
        if (item!=null)
        {
            //player.SetItem(this.itemHolder);
            //Destroy(this.itemHolder);
            //this.itemHolder = i;

            //if (this.itemHolder != null)
            //{
            //    this.itemHolder = Instantiate(this.itemHolder, transform.position + new Vector3(0f, 0.65f, 0f), Quaternion.Euler(-90f, 0f, -135f), transform);
            //    Debug.Log("Ингридиент из TableBox " + itemHolder.name + "создался!");
            //}
        }
        else
        {
            return;
        }
    }
}
