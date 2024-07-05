using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharHolder
{
    public GameObject holderObj;
    public string objName;
    public string objNameEN;
    public GameObject holderImage;
    public string ImagePath;
}

public class HolderList : MonoBehaviour
{
    public Button exit;
    public List<CharHolder> holders = new();

    private void Update()
    {
        foreach (var holder in holders)
        {
            if(holder.objName == "")
            {
                exit.enabled = false;
                return;
            }
            exit.enabled = true;
        }
    }

    public void UpdateHolderList(string imagePath, string charName, GameObject image, bool isActive)
    {
        foreach (var holder in holders)
        {
            if (holder.objName == charName)
            {
                holder.ImagePath = imagePath;
                holder.holderImage = image;
                holder.holderImage.SetActive(isActive);
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
                holder.ImagePath = "";
                holder.objName = "";
                holder.holderImage.SetActive(false);
                holder.holderImage = null;
                break;
            }
        }
    }
}