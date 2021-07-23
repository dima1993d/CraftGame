using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC_Manager : MonoBehaviour
{
    public List<InventoryOfNPC> inventoryOfNPCs = new List<InventoryOfNPC>();
    public GameObject currentNPC;
    public GameObject NPCprefab;
    public Transform SpawnPosition;
    public InventoryOfNPC currentInventory;
    public GameObject spritePrefab;
    public GameObject spritePrefabHolder;
    public List<Button> buttons;
    public int maximumTime = 300;


    public Sprite dead;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < inventoryOfNPCs.Count; i++)
        {
            if (buttons.Count < inventoryOfNPCs.Count)
            {
                GameObject spriteInstance = Instantiate(spritePrefab, spritePrefabHolder.transform);
                buttons.Add(spriteInstance.GetComponent<Button>());
            }
            if (inventoryOfNPCs[i].inDungeon)
            {
                if (inventoryOfNPCs[i].currentTimeInTheDungeon < inventoryOfNPCs[i].strength * 60)
                {
                    inventoryOfNPCs[i].currentTimeInTheDungeon++;
                    SetSpritePos(i,inventoryOfNPCs[i].currentTimeInTheDungeon);
                }
                else
                {
                    SetSpriteDead(i);
                    KillNPC(inventoryOfNPCs[i]);
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

    void SpawnNPC()
    {

        currentNPC = Instantiate(NPCprefab, SpawnPosition);
        currentInventory = currentNPC.GetComponent<InventoryOfNPC>();
        currentInventory = inventoryOfNPCs[0];

    }
    public void GetResources(int pos)
    {
        //int diamond = 
    }
    public void ReturnNPC()
    {

    }

}
