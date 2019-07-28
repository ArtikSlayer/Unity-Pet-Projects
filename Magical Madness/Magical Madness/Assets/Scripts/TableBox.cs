using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBox : MonoBehaviour
{

    public GameObject itemHolder;

    private void Start()
    {
        if (itemHolder != null)
        {
            itemHolder = Instantiate(itemHolder, transform.position + new Vector3(0f, 0.65f, 0f), Quaternion.Euler(-90f, 45f, 0f),transform);
            Debug.Log("Создалось " + itemHolder.name);
        }
    }

    public void Interact(GameObject i, PlayerInteraction player)
    {
        if ((i == null || itemHolder == null))
        {
            player.SetItem(this.itemHolder);
            Destroy(this.itemHolder);
            this.itemHolder = i;

            if (this.itemHolder != null)
            {
                this.itemHolder = Instantiate(this.itemHolder, transform.position + new Vector3(0f, 0.65f, 0f), Quaternion.Euler(-90f, 0f, -135f),transform);
                Debug.Log("Ингридиент из TableBox " + itemHolder.name + "создался!");
            }
        }
        else
        {
            return;
        }
    }
}
