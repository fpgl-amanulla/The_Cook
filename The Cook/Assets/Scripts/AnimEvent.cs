using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{

    public GameObject allVegetable;
    public GameObject obiSolver;
    public Transform plate;
    public ParticleSystem smoke;
    public ObiSolver solver;
    public void FryingEnd()
    {
        allVegetable.transform.SetParent(plate.transform);
        smoke.transform.gameObject.SetActive(true);
        smoke.Play();
    }
    public void SolverParent()
    {
        if (AppDelegate.SharedManager().orderType == OrderType.Soup)
        {
            obiSolver.transform.SetParent(plate);
        }
    }
}
