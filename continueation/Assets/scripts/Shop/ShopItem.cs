using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TagEnum { PlayerColor, PlayerExplosion, ObstecleGlow, enum4 }

public class ShopItem : MonoBehaviour
{
    [SerializeField] Material materialReward;
    [SerializeField] int cost;
    [SerializeField] int index;
    [SerializeField] string descriptionText = "";
    [SerializeField] TagEnum itemTag;


    [Header("Components")]
    [SerializeField] Button btn;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI costText;

    [Header("Null, Only if its in a group")]
    [SerializeField] ShopCanvas shopCanvas;

    private bool isUnlocked = false;
    private bool isHighlighted = false;



    private void Awake()
    {
        isUnlocked = SaveSystem.LoadBoolFromLocation("Button" + index);
        isHighlighted = SaveSystem.LoadBoolFromLocation("Highlight" + index);
        StartHighlight();
        SetCostText();
        description.SetText(descriptionText);
    }

    public Material GetMaterialReward()
    {
        return materialReward;
    }

    public int GetIndex()
    {
        return index;
    }

    public bool GetIsUnlocked()
    {
        return isUnlocked;
    }

    public void ButtonClicked()
    {
        if (isUnlocked)
        {
            //be pressed
            if (shopCanvas != null)
            {
                shopCanvas.HighlightItem(this, itemTag);
            }
            else
            {
                FlipHighlight();
            }
        }
        else
        {
            //MAYBE OPEN A DIALOG BEFORE HERE
            TryBuy();
        }
    }



    public void Highlight()
    {
        btn.image.color = new Color(255, 255, 0);
        isHighlighted = true;
        SaveSystem.SaveBoolAtLocation(isHighlighted, "Highlight" + index);
        //Debug.Log(isHighlighted + " " + name + " " + btn.image.color);
    }

    public void NoHighlight()
    {
        btn.image.color = new Color(255, 255, 255);
        isHighlighted = false;
        SaveSystem.SaveBoolAtLocation(isHighlighted, "Highlight" + index);
        //Debug.Log(isHighlighted + " " + name + " " + btn.image.color);
        //Debug.Log("11");

    }


    private void SetCostText()
    {
        if (!isUnlocked)
        {
            costText.SetText(cost.ToString());
        }
        else
        {
            costText.SetText("");
        }
        
    }      

    private bool TryBuy()
    {
        if (GameManager.Instance.GetCash() >= cost)
        {
            Unlock();
            return true;
        } else
        {
            return false;
        }
    }

    private void Unlock()
    {
        isUnlocked = true;
        SetCostText();
        SaveSystem.SaveBoolAtLocation(isUnlocked, "Button"+index);
        GameManager.Instance.TakeCash(cost);
    }

    private void FlipHighlight()
    {
        if (isHighlighted)
        {
            NoHighlight();
        }
        else
        {
            Highlight();
        }
        
    }

    private void StartHighlight()
    {
        //Debug.Log(isHighlighted + " " + name);
        if (isHighlighted)
        {
            Highlight();
        } else
        {
            NoHighlight();
        }
    }

    public TagEnum GetTag()
    {
        return itemTag;
    }

    public bool GetHighlighted()
    {
        return isHighlighted;
    }

}
