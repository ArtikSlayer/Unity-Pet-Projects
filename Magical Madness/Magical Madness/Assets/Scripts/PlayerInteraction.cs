using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public GameObject target = null;
    public KeyCode interactKey;
    public GameObject itemHolder;

    private void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            if (target == null)
            {
                return;
            }

            FoodBox food = target.GetComponent<FoodBox>();
            if (food != null && itemHolder == null)
            {
                food.Interact(this);
            }

            TableBox table = target.GetComponent<TableBox>();
            if (table != null)
            {
                table.Interact(itemHolder, this);
            }

            ResultPost resultPost = target.GetComponent<ResultPost>();
            if (resultPost != null)
            {
                resultPost.Interact(itemHolder,this);
            }

            //TrashCan trashCan = target.GetComponent<TrashCan>();
            //if (trashCan != null)
            //{
            //    trashCan.Interact(crop, this);
            //}

        }
    }

    public void SetItem(GameObject c)
    {
        if (c != null)
        {
            itemHolder = Instantiate(c, transform.position + new Vector3(0f, 0.7f, -0.7f), Quaternion.Euler(-90f, 0f, 180f), transform);
            Debug.Log("Взяли предмет " + itemHolder.name);
        }
        else
        {
            Destroy(itemHolder);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (target != col.gameObject && target != null)
        {
            return;
        }
        else {
            target = col.gameObject;
            Debug.Log("Мы дошли сюда до " + target.name);
        }
        
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject == target)
        {
            target = null;
        }
    }
}

