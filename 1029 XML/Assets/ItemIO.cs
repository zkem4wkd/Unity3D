using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
public class RecItem
{
    public string Name;
    public int Level;
    public float Critical;
}

public sealed class ItemIO
{
    public static void Write(List<RecItem> ItemList,string filePath)
    {
        XmlDocument Document = new XmlDocument();
        XmlElement ItemListElement = Document.CreateElement("ItemList");
        Document.AppendChild(ItemListElement);
        
        foreach (RecItem Item in ItemList)
        {
            XmlElement ItemElement = Document.CreateElement("Item");
            ItemElement.SetAttribute("Name", Item.Name);
            ItemElement.SetAttribute("Level", Item.Level.ToString());
            ItemElement.SetAttribute("Critical", Item.Critical.ToString());
            ItemListElement.AppendChild(ItemElement);
        }
        Document.Save(filePath);
    }
    public static List<RecItem> Read(string filePath)
    {
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement ItemListElement = Document["ItemList"];
        List<RecItem> ItemList = new List<RecItem>();
        foreach(XmlElement ItemElement in ItemListElement.ChildNodes)
        {
            RecItem It = new RecItem();
            It.Name = ItemElement.GetAttribute("Name");
            It.Level = System.Convert.ToInt32(ItemElement.GetAttribute("Level"));
            It.Critical = System.Convert.ToSingle(ItemElement.GetAttribute("Critical"));
            ItemList.Add(It);
        }

        return ItemList;
    }

}
