using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OwnedItemsData
{
  //PlayerPrefs保存先キー
  private const string PlayerPrefsKey = "OWNED_ITEMS_DATA";

  //インスタンスを返す
  public static OwnedItemsData Instance
  {
    get
    {
      if (null == _instance)
      {
        _instance = PlayerPrefs.HasKey(PlayerPrefsKey) ? JsonUtility.FromJson<OwnedItemsData>(PlayerPrefs.GetString(PlayerPrefsKey)) : new OwnedItemsData();
      }
      return _instance;
    }
  }

  private static OwnedItemsData _instance;

  //所持アイテム一覧を取得
  public OwnedItem[] OwnedItems
  {
    get { return ownedItems.ToArray(); }
  }

  //どのアイテムを何個所持しているかのリスト
  [SerializeField] private List<OwnedItem> ownedItems = new List<OwnedItem>();

  //コンストラクタ
  //シングルトンで外部からnewできないようにコンストラクタをprivateにする
  private OwnedItemsData()
  {
  }

  //JSON化してPlayerPrefsに保存します
  public void Save()
  {
    var jsonString = JsonUtility.ToJson(this);
    PlayerPrefs.SetString(PlayerPrefsKey, jsonString);
    PlayerPrefs.Save();
  }

  //アイテムを追加
  public void Add(Item.ItemType type, int number = 1)
  {
    var item = GetItem(type);
    if (null == item)
    {
      item = new OwnedItem(type);
      ownedItems.Add(item);
    }
    item.Add(number);
  }

  //アイテムを消費
  public void Use(Item.ItemType type, int number = 1)
  {
    var item = GetItem(type);
    if (null == item || item.Number < number)
    {
      throw new Exception("アイテムが足りません");
    }
    item.Use(number);
  }

  //対象の種類のアイテムデータを取得
  public OwnedItem GetItem(Item.ItemType type)
  {
    return ownedItems.FirstOrDefault(x => x.Type == type);
  }

  //アイテムの所持数管理用モデル
  [Serializable]
  public class OwnedItem
  {
    //アイテムの種類を返す
    public Item.ItemType Type
    {
      get { return type; }
    }

    public int Number
    {
      get { return number; }
    }

    //アイテムの種類
    [SerializeField] private Item.ItemType type;

    //所持個数
    [SerializeField] private int number;

    //コンストラクタ
    public OwnedItem(Item.ItemType type)
    {
      this.type = type;
    }

    public void Add(int number = 1)
    {
      this.number += number;
    }

    public void Use(int number = 1)
    {
      this.number -= number;
    }
  }
}