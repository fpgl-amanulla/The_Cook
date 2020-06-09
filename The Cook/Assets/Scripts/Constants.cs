using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrderType
{
    Salad = 1,
    Stew = 2,
    Icecream = 3,
}

public class Constants
{
    public static Dictionary<int, string> itemList = new Dictionary<int, string>()
    {
        {1,"Salad"},
        {2,"Strew"},
    };

}
