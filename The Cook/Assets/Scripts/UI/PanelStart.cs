using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelStart : MonoBehaviour
{
    public GameObject canvas;

    [Header("Buttons")]
    public Button btnStart;
    public Button btnDone;

    [Header("Gameobjects")]
    public GameObject panelStart;
    public GameObject imgFade;

    [Header("Text")]
    public TextMeshProUGUI txtFoodItem;


    [Header("Gameobjects")]
    public GameObject kitchen;
    public GameObject fryPart;

    [Header("Transforms")]
    public Transform kitchenForSalad;
    public Transform kitchenForStew;

    public GameObject decor;
    public GameObject decorSelector;
    public GameObject foodTray;
    public GameObject iceCreamTray;
    public GameObject iceBall;

    string itemName = "";

    AppDelegate appDelegate = null;
    private void Start()
    {
        appDelegate = AppDelegate.SharedManager();

        if (appDelegate.levelCounter > 3)
        {
            appDelegate.levelCounter = Random.Range(1, 4);
        }

        switch (appDelegate.levelCounter)
        {
            case (int)OrderType.Salad:
                appDelegate.orderType = OrderType.Salad;
                kitchen.transform.position = kitchenForSalad.position;
                fryPart.SetActive(false);
                itemName = "Salad";
                break;
            case (int)OrderType.Stew:
                appDelegate.orderType = OrderType.Stew;
                kitchen.transform.position = kitchenForStew.position;
                fryPart.SetActive(true);
                itemName = "Stew";
                break;
            case (int)OrderType.Icecream:
                appDelegate.orderType = OrderType.Icecream;
                iceCreamTray.SetActive(true);
                foodTray.SetActive(false);
                kitchen.SetActive(false);
                fryPart.SetActive(false);
                itemName = "Ice Cream";
                break;
            default:
                break;
        }

        txtFoodItem.text = itemName;
        btnStart.onClick.AddListener(() => StartCallBack());
    }
    private void StartCallBack()
    {
        if (appDelegate.orderType == OrderType.Icecream)
        {
            iceBall.SetActive(true);
            CameraController.Instance.GoToDecorTransform(0);
            decorSelector.SetActive(true);
            decor.SetActive(true);
        }
        else
        {
            GameObject fadeImage = Instantiate(imgFade, canvas.transform);
            TweenManager.DoFade(fadeImage.GetComponent<Image>(), 1.5f);
            CameraController.Instance.GoToKitchen();
        }
        panelStart.SetActive(false);
    }

}
