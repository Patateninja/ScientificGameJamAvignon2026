using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button QuitButton;
    [SerializeField]
    private Button StartButton;
    [SerializeField]
    private Button CreditButton;
    [SerializeField]
    private Image CreditPanel;
    [SerializeField]
    private GameObject MapObject;
    [SerializeField]
    private Image TextPanel;
    [SerializeField]
    private Button BackButton;
    [SerializeField]
    private Button BackButton2;
    [SerializeField]
    private Button PlayButton;
    [SerializeField]
    private Image MenuPanel;
    private bool Credit = false;
    private bool StartPanel = false;
    private bool Menu = true;
    void Start()
    {
        QuitButton.onClick.AddListener(ExitGame);
        PlayButton.onClick.AddListener(StartGame);
        CreditButton.onClick.AddListener(ShowCredit);
        BackButton.onClick.AddListener(ReturnMenu);
        BackButton2.onClick.AddListener(ReturnMenu2);
        StartButton.onClick.AddListener(TextMenu);
        MenuPanel.transform.position = new Vector2(960, 540);
        CreditPanel.transform.position = new Vector2(2880, 0);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    void TextMenu()
    {
        StartPanel = true;
        Menu = false;
    }

    void ShowCredit()
    {
        Credit = true;
        Menu = false;
    }
    void ReturnMenu()
    {
        Credit = false;
        Menu = true;
    }
    void ReturnMenu2()
    {
        Debug.Log("Return");
        StartPanel = false;
        Menu = true;
    }

    private void Update()
    {
        if (Credit)
        {
            float posCreditX = Mathf.Lerp(CreditPanel.transform.position.x, -650, Time.deltaTime * 3);
            CreditPanel.transform.position = new Vector3(posCreditX, CreditPanel.transform.position.y, CreditPanel.transform.position.z);
            float posMenuX = Mathf.Lerp(MenuPanel.transform.position.x, -500, Time.deltaTime * 3);
            MenuPanel.transform.position = new Vector3(posMenuX, MenuPanel.transform.position.y, MenuPanel.transform.position.z);
        }

        if (Menu)
        {
            float posMenuX = Mathf.Lerp(MenuPanel.transform.position.x, 960, Time.deltaTime * 3);
            MenuPanel.transform.position = new Vector3(posMenuX, MenuPanel.transform.position.y, MenuPanel.transform.position.z);
            float posCreditX = Mathf.Lerp(CreditPanel.transform.position.x, 2880, Time.deltaTime * 3);
            CreditPanel.transform.position = new Vector3(posCreditX, CreditPanel.transform.position.y, CreditPanel.transform.position.z);
            float posTextY = Mathf.Lerp(TextPanel.transform.position.y, -1080, Time.deltaTime * 2);
            TextPanel.transform.position = new Vector3(TextPanel.transform.position.x, posTextY, TextPanel.transform.position.z);
            float posMapX = Mathf.Lerp(MapObject.transform.position.x, 0, Time.deltaTime * 2);
            float posMapZ = Mathf.Lerp(MapObject.transform.position.x, 0, Time.deltaTime * 2);
            MapObject.transform.position = new Vector3(posMapX, MapObject.transform.position.y, posMapX);
        }

        if (StartPanel)
        {
            float posTextY = Mathf.Lerp(TextPanel.transform.position.y, 0, Time.deltaTime * 2);
            TextPanel.transform.position = new Vector3(TextPanel.transform.position.x, posTextY, TextPanel.transform.position.z);
            float posMenuX = Mathf.Lerp(MenuPanel.transform.position.x, -500, Time.deltaTime * 3);
            MenuPanel.transform.position = new Vector3(posMenuX, MenuPanel.transform.position.y, MenuPanel.transform.position.z);
            float posMapX = Mathf.Lerp(MapObject.transform.position.x, 12, Time.deltaTime * 2);
            float posMapZ = Mathf.Lerp(MapObject.transform.position.x, 12, Time.deltaTime * 2);
            MapObject.transform.position = new Vector3(posMapX, MapObject.transform.position.y, posMapX);
        }
    }
}
