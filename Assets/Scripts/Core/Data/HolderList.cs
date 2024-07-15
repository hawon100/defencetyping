using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharHolder
{
    public GameObject holderObj;
    public string objName;
    public string objNameEN;
    public string ImagePath;
    public int price;
    public float time;
    public GameObject holderImage;
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

    public void UpdateHolderList(string imagePath, string charName, int price, float time, GameObject image, bool isActive)
    {
        foreach (var holder in holders)
        {
            if (holder.objName == charName)
            {
                holder.ImagePath = imagePath;
                holder.holderImage = image;
                holder.price = price;
                holder.time = time;
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
                holder.price = 0;
                holder.time = 0f;
                holder.holderImage.SetActive(false);
                holder.holderImage = null;
                break;
            }
        }
    }
}