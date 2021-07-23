using CraftGame.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Manager : MonoBehaviour
{
    
    public List<InventoryOfNPC> inventoryOfNPCs = new List<InventoryOfNPC>();
    public List<ItemSlot> itemSlots = new List<ItemSlot>();
    public GameObject currentNPC;
    public GameObject NPCprefab;
    public Transform SpawnPosition;
    public InventoryOfNPC currentInventory;
    //public GameObject spritePrefab;
    //public GameObject spritePrefabHolder;
    public List<Button> buttons;
    public int maximumTime = 300;
    public List<InventoryOfNPC> q;
    public Transform NextPoint;
    public Transform shop;
    public Transform Player;
    public UI_Manager ui;
    public Sprite dead;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < inventoryOfNPCs.Count; i++)
        {

            //if (buttons.Count < inventoryOfNPCs.Count)
            //{
                //GameObject spriteInstance = Instantiate(spritePrefab, spritePrefabHolder.transform);
                //buttons.Add(spriteInstance.GetComponent<Button>());
            //}
            if (inventoryOfNPCs[i].inDungeon)
            {
                if (inventoryOfNPCs[i].currentTimeInTheDungeon < inventoryOfNPCs[i].strength * 60)
                {
                    inventoryOfNPCs[i].currentTimeInTheDungeon++;
                    //SetSpritePos(i,inventoryOfNPCs[i].currentTimeInTheDungeon);
                }
                else
                {
                    inventoryOfNPCs[i].inDungeon = false;
                    q.Add(inventoryOfNPCs[i]);
                    //SetSpriteDead(i);
                    //KillNPC(inventoryOfNPCs[i]);
                }
            }
            else
            {
                inventoryOfNPCs[i].currentTimeInTheDungeon = 0;
            }
            
        }
    }

    private void SetSpritePos(int i , int pos)
    {
        buttons[i].transform.position = new Vector3(0,Mathf.Lerp(0, 1, maximumTime / pos),0);
    }
    private void SetSpriteDead(int i)
    {
        buttons[i].image.sprite = dead;
        buttons.Remove(buttons[i]);
    }

    private void KillNPC(InventoryOfNPC inventoryOfNPC)
    {
        inventoryOfNPCs.Remove(inventoryOfNPC);
        Destroy(inventoryOfNPC.gameObject);
    }
    public void SendOff()
    {
        Animation anim = currentNPC.GetComponent<Animation>();
        anim._to = NextPoint;
        anim.ChangeAnimationState("Run");


    }
    public void DisableNPC()
    {
        //Debug.Log("ddd");
        currentInventory.inDungeon = true;
        currentInventory.currentTimeInTheDungeon = 0;
        currentNPC.SetActive(false);
        currentNPC.transform.position = SpawnPosition.position;
        //currentNPC.GetComponent<Animation>()._to = shop;
        GetResources(currentInventory.strength);
        SpawnNPC();
    }

    private void ClearSlots()
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            itemSlots[i].ClearSlot();
        }
    } 
    private void SetSlots(InventoryOfNPC inventoryOfNPC)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (i <= 3)
            {
                if (inventoryOfNPC.armours[i])
                {
                    itemSlots[i].UpdateItemSlot(inventoryOfNPC.armours[i], 1);
                }
                else
                {
                    itemSlots[i].ClearSlot();
                }
            }
            if (i > 3)
            {
                if (inventoryOfNPC.weapons[i-4])
                {
                    itemSlots[i].UpdateItemSlot(inventoryOfNPC.weapons[i-4], 1);
                }
                else 
                {
                    itemSlots[i].ClearSlot();
                }
            }

        }
    }

    public void SpawnNPC()
    {
        if (q.Count == 0)
        {
            currentNPC = Instantiate(NPCprefab, SpawnPosition);
            currentInventory = currentNPC.GetComponent<InventoryOfNPC>();
            inventoryOfNPCs.Add(currentInventory);
            ui.inventory.AddItem(ui.allItems[1], 5);
        }
        else
        {
            q[0].gameObject.SetActive(true);
            currentNPC = q[0].gameObject;
            currentInventory = q[0];
            q.RemoveAt(0);
        }
        SetSlots(currentInventory);
        Animation anim = currentNPC.GetComponent<Animation>();
        anim._to = shop;
        anim._Player = Player;

    }
    public void GetResources(int pos)
    {
        int rand = Random.Range(0,4);
        switch (rand)
        {
            case 0:
                ui.inventory.AddItem(ui.allItems[1], pos);
                break;
            case 1:
                ui.inventory.AddItem(ui.allItems[5], (int)((float)pos / 2));
                break;
            case 2:
                ui.inventory.AddItem(ui.allItems[7], (int)((float)pos / 5));
                break;
            case 3:
                ui.inventory.AddItem(ui.allItems[9], (int)((float) pos / 20));
                break;
            default:
                break;
        }
    }
    public void ReturnNPC()
    {

    }

}
