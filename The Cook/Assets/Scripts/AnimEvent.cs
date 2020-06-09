using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{

    public GameObject allVegetable;
    public Transform plate;
    public ParticleSystem smoke;
    public void FryingEnd()
    {
        allVegetable.transform.SetParent(plate.transform);
        smoke.transform.gameObject.SetActive(true);
        smoke.Play();
    }
}
