using UnityEngine;
using UnityEngine.UI;

public class UIBuyMenu : MonoBehaviour
{
    [SerializeField]
    private Button buyButton;

    public UITileMenu tileMenu;

    void Start()
    {
        buyButton.onClick.AddListener(Buy);
    }

    void Buy()
    {
        if (ResourceManager.Instance.CheckMoney(tileMenu.linkedTile.value, 0))
        {
            ResourceManager.Instance.AddMoney(-tileMenu.linkedTile.value, 0);
            tileMenu.linkedTile.SetOwner(1);
            tileMenu.SetMode();

            tileMenu.linkedTile.EvaluateCost();
        }
        else
        {
            Debug.Log("Too Poor");
        }
    }
}
