using UnityEngine;
using UnityEngine.UI;

public class UIOwnedMenu : MonoBehaviour
{
    [SerializeField]
    private Button buildHomeButton;
    [SerializeField]
    private Button buildServiceButton;
    [SerializeField]
    private Button buildEconomicButton;
    [SerializeField]
    private Button sellButton;

    public UITileMenu tileMenu;

    //Temp
    public GameObject house;
    public GameObject service;
    public GameObject store;

    void Start()
    {
        buildHomeButton.onClick.AddListener(BuildHome);
        buildServiceButton.onClick.AddListener(BuildService);
        buildEconomicButton.onClick.AddListener(BuildEconomic);
        sellButton.onClick.AddListener(Sell);
    }

    public void UpdateButton()
    {
        if (!tileMenu.linkedTile)
        {
            return;
        }

        buildHomeButton.gameObject.SetActive(!tileMenu.linkedTile.hasBuilding);
        buildServiceButton.gameObject.SetActive(!tileMenu.linkedTile.hasBuilding);
        buildEconomicButton.gameObject.SetActive(!tileMenu.linkedTile.hasBuilding);
    }

    void BuildHome()
    {
        if (tileMenu.linkedTile.hasBuilding) return;
        tileMenu.linkedTile.hasBuilding = true;

        //Temp
        GameObject build = Instantiate(house);
        build.transform.position = tileMenu.linkedTile.transform.position;
        //////

        tileMenu.linkedTile.selfvalue += 1;
        tileMenu.linkedTile.SetType(TileType.HOUSE);

        tileMenu.linkedTile.EvaluateCost();

        UpdateButton();
    }

    void BuildService()
    {
        if (tileMenu.linkedTile.hasBuilding)
        {
            return;
        }

        tileMenu.linkedTile.hasBuilding = true;

        //Temp
        GameObject build = Instantiate(service);
        build.transform.position = tileMenu.linkedTile.transform.position;
        //////
        ///
        tileMenu .linkedTile.GetComponent<MeshFilter>().sharedMesh = service.GetComponent<MeshFilter>().sharedMesh;
        tileMenu .linkedTile.GetComponent<MeshRenderer>().sharedMaterials = service.GetComponent<MeshRenderer>().sharedMaterials;

        tileMenu.linkedTile.SetType(TileType.SERVICE);
        tileMenu.linkedTile.value = 0;

        foreach (Tile tile in tileMenu.linkedTile.neighbors)
        {
            tile.EvaluateCost();
        }

        UpdateButton();
    }

    void BuildEconomic()
    {
        if (tileMenu.linkedTile.hasBuilding)
        {
            return;
        }

        tileMenu.linkedTile.hasBuilding = true;

        //Temp
        GameObject build = Instantiate(store);
        build.transform.position = tileMenu.linkedTile.transform.position;
        //////

        tileMenu.linkedTile.SetType(TileType.SHOP);

        foreach (Tile tile in tileMenu.linkedTile.neighbors)
        {
            tile.EvaluateCost();
        }

        UpdateButton();
    }

    void Sell()
    {
        ResourceManager.Instance.AddMoney(tileMenu.linkedTile.value);
        tileMenu.linkedTile.SetOwner(0);
        tileMenu.SetMode();
        UpdateButton();
    }
}
