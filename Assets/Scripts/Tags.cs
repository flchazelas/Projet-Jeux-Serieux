using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags
{
    public static bool CompareTags(string tag, GameObject obj)
    {
        string[] tabTags = obj.tag.Split(',');

        foreach(string str in tabTags)
        {
            if(str.Equals(tag))
            {
                return true;
            }
        }
        return false;
    }
}
