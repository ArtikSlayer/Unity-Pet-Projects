using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PotionManager : MonoBehaviour {

    [SerializeField]
    private Color sliderColor;
    [SerializeField]
    private Color panelColor;
    [SerializeField]
    private Color shadingColor;

    Image sourceImage;
    private float timer=25;
    static int COUNT_OF_ORDERS = 0;
    public Transform parent;
    public List<PotionAsset> potionList = new List<PotionAsset>();
    private float posX,posY,posZ;

    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 30)
        {
            int number = Random.Range(0, 2);
            PotionAsset selection = potionList[number];
            Debug.Log(selection.name);

            GameObject temp = CreateOrderHolder(selection);

            StartCoroutine(TimerOn(temp));

        }
    }

    GameObject CreateOrderHolder(PotionAsset selection)
    {
        posX = 160 * COUNT_OF_ORDERS + 80;
        posY = -70;
        posZ = 0;

        COUNT_OF_ORDERS++;

        GameObject temp = new GameObject("Potion Order " + COUNT_OF_ORDERS, typeof(RectTransform));
        temp.transform.SetParent(parent);
        temp.transform.localPosition = new Vector3(posX, posY, posZ);
        temp.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        temp.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        temp.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        temp.tag = selection.name;

        CreateOrderTimer(temp.transform);
        CreateIngredientsHolder(temp.transform, selection);
        CreatePotionHolder(temp.transform, selection);

        timer = 0;

        return temp;
    }

    void CreateOrderTimer(Transform parent)
    {
        //////OrderTimer
        posX = 0;
        posY = 41;
        posZ = 0;

        GameObject temp = new GameObject("OrderTimer", typeof(RectTransform), typeof(Slider));

        temp.transform.SetParent(parent);
        temp.transform.localPosition = new Vector3(posX, posY, posZ);
        temp.transform.localScale = new Vector3(1, 1, 1);
        temp.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 20);

        //////Background
        posX = 0;
        posY = 0;
        posZ = 0;

        GameObject back = new GameObject("Background", typeof(RectTransform), typeof(Image));

        back.transform.SetParent(temp.transform);
        back.transform.localPosition = new Vector3(posX, posY, posZ);
        back.transform.localScale = new Vector3(1, 1, 1);
        back.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        back.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.75f);
        back.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.25f);

        sourceImage = back.GetComponent<Image>();
        sourceImage.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
        sourceImage.type = Image.Type.Sliced;

        ////Fill Area
        posX = 5;
        posY = 0;
        posZ = 0;

        GameObject fillArea = new GameObject("Fill Area", typeof(RectTransform));

        fillArea.transform.SetParent(temp.transform);
        fillArea.transform.localPosition = new Vector3(posX, posY, posZ);
        fillArea.transform.localScale = new Vector3(1, 1, 1);
        fillArea.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 0);
        fillArea.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.75f);
        fillArea.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.25f);

        ////Fill
        posX = -5;
        posY = 0;
        posZ = 0;

        GameObject fill = new GameObject("Fill", typeof(RectTransform), typeof(Image));

        fill.transform.SetParent(fillArea.transform);
        fill.transform.localPosition = new Vector3(posX, posY, posZ);
        fill.transform.localScale = new Vector3(1, 1, 1);
        fill.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        fill.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        fill.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);

        sourceImage = fill.GetComponent<Image>();
        sourceImage.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        sourceImage.color = sliderColor;
        sourceImage.type = Image.Type.Sliced;

        ////ExtraSlider
        temp.GetComponent<Slider>().fillRect = fill.GetComponent<RectTransform>();
        temp.GetComponent<Slider>().direction = Slider.Direction.LeftToRight;
        temp.GetComponent<Slider>().minValue = 0;
        temp.GetComponent<Slider>().maxValue = 30;
        temp.GetComponent<Slider>().value = 30;

    }

    IEnumerator TimerOn(GameObject slider)
    {
        Slider temp = slider.GetComponentInChildren<Slider>();

        //Debug.Log(temp.value);
        while (temp.value > 3)
        {
            Debug.Log(temp.value);
            temp.value -= 0.3f;
            yield return new WaitForSeconds(0.7f);
        }
        Debug.Log(slider + " закончил отсчёт!");
    }

    void CreatePotionHolder(Transform parent, PotionAsset selection)
    {
        ////PotionHolder
        posX = 0;
        posY = 13.5f;
        posZ = 0;

        GameObject temp = new GameObject("PotionHolder", typeof(RectTransform), typeof(Image));

        temp.transform.SetParent(parent);
        temp.transform.localPosition = new Vector3(posX, posY, posZ);
        temp.transform.localScale = new Vector3(1, 1, 1);
        temp.GetComponent<RectTransform>().sizeDelta = new Vector2(100,50);

        sourceImage = temp.GetComponent<Image>();
        sourceImage.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        sourceImage.type = Image.Type.Sliced;

        ////PotionIcon
        posX = 0;
        posY = 0;
        posZ = 0;

        GameObject potionIcon = new GameObject("PotionIcon", typeof(RectTransform), typeof(Image));

        potionIcon.transform.SetParent(temp.transform);
        potionIcon.transform.localPosition = new Vector3(posX, posY, posZ);
        potionIcon.transform.localScale = new Vector3(1, 1, 1);
        potionIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);

        sourceImage = potionIcon.GetComponent<Image>();
        sourceImage.sprite = selection.icon;
        sourceImage.type = Image.Type.Sliced;
    }

    void CreateIngredientsHolder(Transform parent, PotionAsset selection)
    {
        ////IngredientsHolder
        posX = 0;
        posY = 2;
        posZ = 0;

        GameObject temp = new GameObject("IngredientsHolder", typeof(RectTransform));

        temp.transform.SetParent(parent);
        temp.transform.localPosition = new Vector3(posX, posY, posZ);
        temp.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        for (int i = 0; i < selection.ingredients.Count; i++)
        {
            ////Panel
            float pos = (100 / (selection.ingredients.Count + 1));
            posX = -50 + pos + i * pos;
            posY = -18.3f;
            posZ = 0;

            GameObject panel = new GameObject("Panel" + (i+1), typeof(RectTransform), typeof(Image));

            panel.transform.SetParent(temp.transform);
            panel.transform.localPosition = new Vector3(posX, posY, posZ);
            panel.transform.localScale = new Vector3(1, 1, 1);
            panel.GetComponent<RectTransform>().sizeDelta = new Vector2(25, 25);

            sourceImage = panel.GetComponent<Image>();
            sourceImage.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            sourceImage.color = panelColor;
            sourceImage.type = Image.Type.Sliced;

            ////Shading
            posX = 0;
            posY = -1;
            posZ = 0;

            GameObject shading = new GameObject("Shading", typeof(RectTransform), typeof(Image));

            shading.transform.SetParent(panel.transform);
            shading.transform.localPosition = new Vector3(posX, posY, posZ);
            shading.transform.localScale = new Vector3(1, 1, 1);
            shading.GetComponent<RectTransform>().sizeDelta = new Vector2(17.5f, 17.5f);

            sourceImage = shading.GetComponent<Image>();
            sourceImage.sprite = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
            sourceImage.color = shadingColor;
            sourceImage.type = Image.Type.Sliced;

            ////IngredientIcon
            posX = 0;
            posY = 0;
            posZ = 0;

            GameObject ingredientIcon = new GameObject("IngredientIcon", typeof(RectTransform), typeof(Image));

            ingredientIcon.transform.SetParent(shading.transform);
            ingredientIcon.transform.localPosition = new Vector3(posX, posY, posZ);
            ingredientIcon.transform.localScale = new Vector3(1, 1, 1);
            ingredientIcon.GetComponent<RectTransform>().sizeDelta = new Vector2(12.5f, 12.5f);

            sourceImage = ingredientIcon.GetComponent<Image>();
            sourceImage.sprite = selection.ingredients[i].icon;
            sourceImage.type = Image.Type.Sliced;
        }
    }
}
