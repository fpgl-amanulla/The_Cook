using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public static Drawer Instance;

    public GameObject drawer;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void OpenDrawer()
    {
        Vector3 pos = new Vector3(0, 0, -.5f);
        drawer.transform.DOLocalMove(pos, 1.0f);
    }
    public void CloseDrawer()
    {
        Vector3 pos = Vector3.zero;
        drawer.transform.DOLocalMove(pos, 1.0f);
    }
}
