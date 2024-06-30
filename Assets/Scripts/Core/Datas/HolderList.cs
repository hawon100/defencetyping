using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharHolder
{
    public GameObject holderObj;
    public string objName;
    public Image holderImage;
}

public class HolderList : MonoBehaviour
{
    public List<CharHolder> holders = new();
    public Button exit;

    private void Update()
    {
        foreach (var holder in holders)
        {
            if(holder.objName == "")
            {
                exit.enabled = false;
                continue;
            }
            else
            {
                exit.enabled = true;
            }
        }
    }

    public void UpdateHolderList(string charName, Image image, bool isActive)
    {
        foreach (var holder in holders)
        {
            if (holder.objName == charName)
            {
                holder.holderImage = image;
                holder.holderImage.enabled = isActive;
                break;
            }
        }
    }

    public void ResetHolderList(string charName)
    {
        foreach (var holder in holders)
        {
            if (holder.objName == charName)
            {
                holder.objName = "";
                holder.holderImage.enabled = false;
                holder.holderImage = null;
                break;
            }
        }
    }
}