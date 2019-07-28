using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ingredient : MonoBehaviour
{

    public IngredientAsset asset;

    public Ingredient(IngredientAsset a)
    {
        asset = a;
    }

    public bool HasIngrediend()
    {
        if (asset == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
