using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private Button TurnButton;

    void Start()
    {
       TurnButton.onClick.AddListener(EOT);
    }

    void Update()
    {
        text.text = "Gold : " + ResourceManager.Instance.PlayerMoney;
    }

    void EOT()
    {
        TurnManager.instance.EndOfTurn();
    }
}
