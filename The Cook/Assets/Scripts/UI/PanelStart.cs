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

    string itemName = "";

    AppDelegate appDelegate = null;
    private void Start()
    {
        appDelegate = AppDelegate.SharedManager();

        if (appDelegate.levelCounter > 2)
        {
            appDelegate.levelCounter = Random.Range(1, 3);
        }

        switch (appDelegate.levelCounter)
        {
            case (int)OrderType.Salad:
                appDelegate.orderType = OrderType.Salad;
                kitchen.transform.position = kitchenForSalad.position;
                fryPart.SetActive(false);
                break;
            case (int)OrderType.Stew:
                appDelegate.orderType = OrderType.Stew;
                kitchen.transform.position = kitchenForStew.position;
                fryPart.SetActive(true);
                break;
            default:
                break;
        }


        itemName = appDelegate.orderType.ToString();

        txtFoodItem.text = itemName;
        btnStart.onClick.AddListener(() => StartCallBack());
    }
    private void StartCallBack()
    {
        panelStart.SetActive(false);
        GameObject fadeImage = Instantiate(imgFade, canvas.transform);
        TweenManager.DoFade(fadeImage.GetComponent<Image>(), 1.5f);
        CameraController.Instance.GoToKitchen();
    }

}
