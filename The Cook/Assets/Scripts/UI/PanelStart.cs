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

    private void Start()
    {
        txtFoodItem.text = "Salad";
        btnStart.onClick.AddListener(() => StartCallBack());
    }
    private void StartCallBack()
    {
        panelStart.SetActive(false);
        GameObject fadeImage = Instantiate(imgFade, canvas.transform);
        TweenManager.DoFade(fadeImage.GetComponent<Image>(), 1.5f);
        CameraController.Instance.GoToKitchenTransform();
    }

}
