using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Potion")]
public class PotionAsset : ScriptableObject {

    public Sprite icon;
    public List<IngredientAsset> ingredients = new List<IngredientAsset>();
}
