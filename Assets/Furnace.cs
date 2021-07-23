using CraftGame.SO;
using CraftGame.UI;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    public GameObject flame;
    public float burn = 0;
    public float currentTime = 0;
    public ItemSlot top, bot, result;


    void Update()
    {
        burn -= Time.deltaTime;
        if (burn < 0)
        {
            burn = 0;
        }
        if (burn > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                currentTime = 0;
            }
            if (currentTime == 0) 
            {
                if (top.item != null && top.number > 0)
                {
                    OreSO ore = (OreSO)top.item;
                    burn = ore.needTimeToMelt;
                    top.UpdateItemSlot(top.item, top.number - 1);
                    result.UpdateItemSlot(ore.meltsInTo, result.number + 1);
                    currentTime = ore.needTimeToMelt - 0.1F;
                }
            }
                
        }
        if (bot.item != null && bot.number > 0 && burn == 0 && top.item != null)
        {
            OreSO ore = (OreSO)top.item;
            if (result.item != null && result.item != ore.meltsInTo)
            {

            }
            else
            {
                FuelSO f = (FuelSO)bot.item;
                burn = f.burnTime;
                bot.UpdateItemSlot(bot.item, bot.number - 1);
            }
            
        }
    }
}
