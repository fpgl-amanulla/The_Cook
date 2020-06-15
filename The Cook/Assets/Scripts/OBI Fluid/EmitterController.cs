using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterController : MonoBehaviour
{

    private Vector3 target = new Vector3(0, 0, 0);
    private Vector3 prevtarget = new Vector3(0, 0, 0);
    //private Touch touch;
    //Quaternion anglechange = Quaternion.Euler(0, 0, 0);
    //Quaternion transformrotation = Quaternion.Euler(0, 0, -90);
    //Quaternion rotationy = Quaternion.Euler(0, 30, 0);
    private Vector3 lastPosition;
    //public Transform sause;
    //public GameObject clonedObject;
    //public GameObject sausepoint;
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;
    public Obi.ObiEmitter emitter;
    public float emittimer = 0;
    public float emitdelay = 2;
    public bool emitLimit = false;
    public int activeparticlecount;
    public int activeparticlecountLimit = 500;
    public bool targetchanged = false;

    private int sauseCount = 0;

    public bool incollider = false;

    private bool traychooseractive = true;

    private float movespeed;
    private float resx;

    public GameObject cone_4;

    public FryingSlider fryingSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("resx"))
        {
            resx = PlayerPrefs.GetInt("resx");
            if (resx == 360)
            {
                movespeed = .004f;
            }
            else if (resx == 250)
            {
                movespeed = .005f;
            }
            else if (resx == 360 * 2)
            {
                movespeed = .0015f;
            }
            else if (resx == 360 * 3)
            {
                movespeed = .001f;
            }
        }
        else
        {
            movespeed = .002f;
        }

    }


    private void Update()
    {


        if (Input.GetMouseButton(0))
        {

            MovePlayer();

        }
        else
        {

            targetchanged = false;
            emittimer = 0;
            emitter.mousepressed = false;
        }



    }

    private void MovePlayer()
    {


        //if (incollider == true /*&& touch.phase == TouchPhase.Moved*/ && prevtarget != target/* && distancetravelledcream >= instantdelay*/  )
        //{

        //    sauseCount++;
        //    clonedObject = Instantiate(sause.gameObject, sausepoint.transform.position, sause.rotation);
        //    clonedObject.name = "clone";
        //    clonedObject.tag = "clone";



        //}

        //if (sauseCount > 300)
        //{
        //    um.doneactive();
        //}


        target = Input.mousePosition;
        if (!targetchanged)
        {
            prevtarget = target;
        }



        float y2 = target.y;
        float x2 = target.x;

        float y1 = prevtarget.y;
        float x1 = prevtarget.x;

        float xDiff = x2 - x1;
        float yDiff = y2 - y1;

        lastPosition.x = xDiff;
        lastPosition.z = yDiff;
        lastPosition.y = transform.position.y;


        targetchanged = true;


        if (prevtarget != target)
        {
            transform.position = Vector3.Lerp(transform.position, lastPosition, movespeed /** Time.deltaTime*/);

        }


        prevtarget = target;



        if (emittimer >= emitdelay && !emitLimit)
        {
            if (traychooseractive == true)
            {
                traychooseractive = false;
            }


            emitter.mousepressed = true;
//#if !UNITY_EDITOR && UNITY_ANDROID

//            Vibration.Vibrate(20);
//#endif
        }
        else
        {
            emitter.mousepressed = false;

        }
        emittimer += Time.deltaTime;

        activeparticlecount = emitter.activeParticleCount;
        if (emitter.activeParticleCount >= activeparticlecountLimit)
        {
            emitLimit = true;
            Destroy(cone_4);
            fryingSlider.isStartCooking = true;

        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (stay && other.tag == "pizzaCollider")
        {
            incollider = true;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (exit && other.tag == "pizzaCollider")
        {
            incollider = false;
        }
    }
}
