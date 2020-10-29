using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
public class RecItem
{
    public int DrillGauge;
}

public sealed class DrillIO
{
    public static void Write(List<RecItem> ItemList, string filePath)
    {
        XmlDocument Document = new XmlDocument();
        XmlElement ItemListElement = Document.CreateElement("ItemList");
        Document.AppendChild(ItemListElement);

        foreach (RecItem Item in ItemList)
        {
            XmlElement ItemElement = Document.CreateElement("Item");
            ItemElement.SetAttribute("DrillGauge", Item.DrillGauge.ToString());
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
        foreach (XmlElement ItemElement in ItemListElement.ChildNodes)
        {
            RecItem It = new RecItem();
            It.DrillGauge = System.Convert.ToInt32(ItemElement.GetAttribute("DrillGauge"));
            ItemList.Add(It);
        }

        return ItemList;
    }

}
