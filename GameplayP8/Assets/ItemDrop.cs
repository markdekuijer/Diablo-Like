using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private float dropChance;
    [SerializeField] private List<Drops> drops = new List<Drops>();
    [SerializeField] private GameObject itemDropPrefab;
    public Drops d;

    [SerializeField] private int exp;

    public void DropItemChange()
    {
        ExpHandler.Instance.GiveExp(exp);

        if (Random.Range(0, 100) <= dropChance)
        {
            int i = Random.Range(0, 5);
            if (i >= 4)
                GetDropItem(Random.Range(1, 3));
            else
                GetDropItem();

        }

        //DropMoney();
    }

    public void GetDropItem(int iterations = 1)
    {
        for (int i = 0; i < iterations; i++)
        {
            d = drops[Random.Range(0, drops.Count)];
            DroppedItem item = ObjectPooler.SharedInstance.GetPooledObject(3).GetComponent<DroppedItem>();
            item.gameObject.SetActive(true);
            item.transform.position = transform.position;
            item.transform.rotation = Quaternion.Euler(0, 0, 0);
            item.Init(d);
        }
    }

    public void DropMoney()
    {
        for (int i = 0; i < Random.Range(0,5); i++)
        {

        }
    }
}

public class Drops : ScriptableObject
{

}
