using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI playerText;

    [SerializeField]
    private TextMeshProUGUI mayorText;

    [SerializeField]
    private TextMeshProUGUI publicText;

    [SerializeField]
    private TextMeshProUGUI turnText;

    [SerializeField]
    private Button TurnButton;

    void Start()
    {
       TurnButton.onClick.AddListener(EOT);
    }

    void Update()
    {
        playerText.text = "Player Gold : " + ResourceManager.Instance.balances[0] + "\nPlayer Pop : " + ResourceManager.Instance.pop[0];
        mayorText.text = "Mayor Gold : " + ResourceManager.Instance.balances[1] + "\nMayor Pop : " + ResourceManager.Instance.pop[1];
        publicText.text = "Public Gold : " + ResourceManager.Instance.balances[2] + "\nPublic Pop : " + ResourceManager.Instance.pop[2];
        turnText.text = "Turn : " + TurnManager.instance.turn + "\nTotal Pop : " + ResourceManager.Instance.pop[3];
    }

    void EOT()
    {
        TurnManager.instance.EndOfTurn();
    }
}