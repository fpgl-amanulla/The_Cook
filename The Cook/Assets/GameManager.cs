using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public List<GameObject> vegetableList = new List<GameObject>();

    public GameObject knife;
    public GameObject tray;
    public GameObject trayToPlate;
    public GameObject drawer;

    public PhysicMaterial p;
    public Transform plate;
    private void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    internal void VegetableFall()
    {
        for (int i = 0; i < vegetableList.Count; i++)
        {
            Transform[] childrens = vegetableList[i].GetComponentsInChildren<Transform>();
            foreach (var item in childrens)
            {
                Destroy(item.gameObject.GetComponent<Rigidbody>());
                //item.gameObject.AddComponent<Rigidbody>();
                item.GetComponent<BoxCollider>().material = p;
                item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z);
            }
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i < vegetableList.Count; i++)
        {
            Transform[] childrens = vegetableList[i].GetComponentsInChildren<Transform>();
            foreach (var item in childrens)
            {
                item.gameObject.AddComponent<Rigidbody>();
                item.gameObject.GetComponent<Rigidbody>().drag = 0;
                item.gameObject.GetComponent<Rigidbody>().mass = 1000;
                item.SetParent(plate.transform);
            }
        }
        yield return new WaitForSeconds(4f);
        Destroy(tray);
    }
}
