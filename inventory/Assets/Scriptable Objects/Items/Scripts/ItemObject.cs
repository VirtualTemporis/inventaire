using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Food,
    Equipment,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public Sprite uiDisplay;
    public ItemType type;
    [TextArea(15,20)]
    public string description;
    public ItemBuff[] buffs;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

public enum Attributes
{
    Agility,
    Intellect,
    Stamina,
    Strength
}


[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public ItemBuff[] buffs;
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.Id;
        buffs = new ItemBuff[item.buffs.Length];
        for(int i=0;i<buffs.Length;i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max);

            buffs[i].attributes = item.buffs[i].attributes;
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attributes;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int _min,int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}