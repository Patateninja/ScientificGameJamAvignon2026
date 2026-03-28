using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITileMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI valueText;

    [SerializeField]
    private UIBuyMenu buyMenu;
    [SerializeField]
    private UIOwnedMenu ownedMenu;

    public Tile linkedTile { get; private set; }

    void Start()
    {
        ownedMenu.tileMenu = this;
        buyMenu.tileMenu = this;
    }

    void Update()
    {
        valueText.text = $"Value : {linkedTile.value}";
    }

    public void SetMode()
    {
        if (linkedTile.owner == 0)
        {
            buyMenu.gameObject.SetActive(true);
            ownedMenu.gameObject.SetActive(false);
        }
        else if (linkedTile.owner == 1)
        {
            buyMenu.gameObject.SetActive(false);
            ownedMenu.gameObject.SetActive(true);
        }
        else
        {
            buyMenu.gameObject.SetActive(false);
            ownedMenu.gameObject.SetActive(false);
        }
    }

    public void SetTile(Tile tile)
    {
        linkedTile = tile;
        ownedMenu.UpdateButton();
    }
}
