using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCanvas : MonoBehaviour
{
    private TextMeshProUGUI[] texts;
    private Image[] imgs;

    private ShopItem[] items;

    private ShopItem[] highlightedItems;

    private void Start()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();
        imgs = GetComponentsInChildren<Image>();
        items = GetComponentsInChildren<ShopItem>();

        SetData();
    }

    private void SetData()
    {
        Data.Instance.playerExplosion = false;//will only change if its tag is highlighted

        foreach (ShopItem item in items)
        {
            if (item.GetHighlighted())
            {

                if (item.GetTag() == TagEnum.PlayerColor)
                {
                    Data.Instance.playerMaterial = item.GetMaterialReward();
                    //Debug.Log("setData-PlayerMat");
                }
                
                if (item.GetTag() == TagEnum.PlayerExplosion)
                {
                    Data.Instance.playerExplosion = true;

                }
            }
        }
    }

    public void HighlightItem(ShopItem item, TagEnum tagEnum)
    {
        //Debug.Log("called highlghtitem");
        foreach (ShopItem tmp in items)
        {
            if (tmp.GetTag() == tagEnum)
            {
                tmp.NoHighlight();
            }
        }
        item.Highlight();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

}
