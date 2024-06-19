using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefabs;
    public List<Loot> lootList = new List<Loot>();

    Loot GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loot> possibleItem = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItem.Add(item);
                
            }
        }
        if (possibleItem.Count > 0)
        {
            Loot droppedItem = possibleItem[Random.Range(0, possibleItem.Count)];
            return droppedItem;
        }
        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            GameObject lootGameObject = Instantiate(droppedItemPrefabs, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            float dropForce = 300f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
    }


}
