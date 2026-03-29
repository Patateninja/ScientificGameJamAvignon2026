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

    [SerializeField]
    private Camera cam;


    public Tile linkedTile { get; private set; }

    void Start()
    {
        ownedMenu.tileMenu = this;
        buyMenu.tileMenu = this;
    }

    void Update()
    {
        valueText.text = $" Value : {linkedTile.value}";
        gameObject.transform.localScale = Vector3.one * (cam.orthographicSize / 5f);
    }

    public void SetMode()
    {
        if (linkedTile.owner == 0 && linkedTile.type != TileType.RIVER)
        {
            Debug.Log("No Owner");
            buyMenu.gameObject.SetActive(true);
            ownedMenu.gameObject.SetActive(false);
        }
        else if (linkedTile.owner == 1)
        {
            Debug.Log("Player Owner");
            buyMenu.gameObject.SetActive(false);
            ownedMenu.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("AI Owner");
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
