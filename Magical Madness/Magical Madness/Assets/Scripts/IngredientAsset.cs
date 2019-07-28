using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient")]
public class IngredientAsset : ScriptableObject {

    public Sprite icon;
    public GameObject prefab;

}
