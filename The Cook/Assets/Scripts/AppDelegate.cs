using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppDelegate
{
    public int levelCounter = 1;
    public int templevelCounter = 1;

    public int totalIceCount = 0;

    public OrderType orderType;

    public static AppDelegate sharedInstance = null;
    public static AppDelegate SharedManager()
    {
        if (sharedInstance == null)
        {
            sharedInstance = AppDelegate.Create();
        }
        return sharedInstance;
    }

    public static AppDelegate Create()
    {
        AppDelegate ret = new AppDelegate();
        if (ret != null && ret.Init())
        {
            return ret;
        }
        else
        {
            return null;
        }
    }

    public bool Init()
    {
        return true;
    }
}
