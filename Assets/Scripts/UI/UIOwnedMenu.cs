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

        buildHomeButton.gameObject.SetActive(!tileMenu.linkedTile.hasBuilding && tileMenu.linkedTile.type != TileType.RIVER);
        buildServiceButton.gameObject.SetActive(!tileMenu.linkedTile.hasBuilding && tileMenu.linkedTile.type != TileType.RIVER);
        buildEconomicButton.gameObject.SetActive(!tileMenu.linkedTile.hasBuilding && tileMenu.linkedTile.type != TileType.RIVER);
    }

    void BuildHome()
    {
        if (tileMenu.linkedTile.hasBuilding) return;
        //tileMenu.linkedTile.hasBuilding = true;

        //tileMenu.linkedTile.transform.RotateAround(tileMenu.linkedTile.transform.position, tileMenu.linkedTile.transform.up, Random.Range(0, 3) * 90f);

        //tileMenu.linkedTile.GetComponent<MeshFilter>().sharedMesh = house.GetComponent<MeshFilter>().sharedMesh;
        //tileMenu.linkedTile.GetComponent<MeshRenderer>().sharedMaterials = house.GetComponent<MeshRenderer>().sharedMaterials;

        //tileMenu.linkedTile.selfvalue += 1;
        //tileMenu.linkedTile.SetType(TileType.HOUSE);

        //tileMenu.linkedTile.EvaluateCost();

        tileMenu.linkedTile.BuildHouse(house);

        UpdateButton();
    }

    void BuildService()
    {
        if (tileMenu.linkedTile.hasBuilding)
        {
            return;
        }

        //tileMenu.linkedTile.hasBuilding = true;

        //tileMenu.linkedTile.transform.RotateAround(tileMenu.linkedTile.transform.position, tileMenu.linkedTile.transform.up, Random.Range(0, 3) * 90f);

        //tileMenu.linkedTile.GetComponent<MeshFilter>().sharedMesh = service.GetComponent<MeshFilter>().sharedMesh;
        //tileMenu.linkedTile.GetComponent<MeshRenderer>().sharedMaterials = service.GetComponent<MeshRenderer>().sharedMaterials;

        //tileMenu.linkedTile.SetType(TileType.SERVICE);
        //tileMenu.linkedTile.value = 0;

        //foreach (Tile tile in tileMenu.linkedTile.neighbors)
        //{
        //    tile.EvaluateCost();
        //}

        tileMenu.linkedTile.BuildService(service);

        UpdateButton();
    }

    void BuildEconomic()
    {
        if (tileMenu.linkedTile.hasBuilding)
        {
            return;
        }

        //tileMenu.linkedTile.hasBuilding = true;

        //tileMenu.linkedTile.transform.RotateAround(tileMenu.linkedTile.transform.position, tileMenu.linkedTile.transform.up, Random.Range(0, 3) * 90f);

        //tileMenu.linkedTile.GetComponent<MeshFilter>().sharedMesh = store.GetComponent<MeshFilter>().sharedMesh;
        //tileMenu.linkedTile.GetComponent<MeshRenderer>().sharedMaterials = store.GetComponent<MeshRenderer>().sharedMaterials;

        //tileMenu.linkedTile.SetType(TileType.SHOP);

        //foreach (Tile tile in tileMenu.linkedTile.neighbors)
        //{
        //    tile.EvaluateCost();
        //}

        tileMenu.linkedTile.BuildShop(store);

        UpdateButton();
    }

    void Sell()
    {
        if (tileMenu.linkedTile.value < 1)
        {
            tileMenu.linkedTile.value = 1;
        }
        ResourceManager.Instance.AddMoney(tileMenu.linkedTile.value, 0);
        tileMenu.linkedTile.SetOwner(0);
        tileMenu.SetMode();
        UpdateButton();
    }
}
