using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public enum TileType
{
    FIELD,
    RIVER,
    HOUSE,
    SERVICE,
    SHOP,
}

public class Tile : MonoBehaviour
{
    public Vector2 coordinates;

    public int owner = 0; //0 = None 1 = Player 2 = AI

    public int value;
    public int selfvalue;
    public TileType type;
    //private int satisfaction;
    //private int level;

    public bool hasBuilding;

    public List<Tile> neighbors = new List<Tile>();

    [SerializeField]
    private TextMeshPro text;
    public bool showVal;
    
    void Start()
    {
        selfvalue = type == TileType.HOUSE ? 2 : 1;
        value = 1;
        hasBuilding = !(type != TileType.HOUSE && type != TileType.SERVICE && type != TileType.SHOP);
        //satisfaction = 1;

        EvaluateCost();
    }

    void Update()
    {
        GetComponent<MeshRenderer>().materials[1].SetFloat("_Player", owner);

        text.gameObject.SetActive(showVal);
        if (text && showVal)
        {
            text.transform.rotation = Quaternion.Euler(-270, 0, -45);
            text.text = value.ToString();
        }
    }

    public void SetNeighbor(List<Tile> _neighbors)
    {
        neighbors = _neighbors;
    }
    
    public void SetCood(Vector2 _cood)
    {
        coordinates = _cood;
    }

    public void SetOwner(int o)
    {
        owner = o;
    }

    public void EndOfTurn()
    {
        EvaluateCost();
    }

    public int EvaluateCost()
    {
        if (type == TileType.SERVICE || type == TileType.RIVER)
        {
            value = 0;
            return 0;
        }
        
        value = selfvalue;
        foreach (Tile tile in neighbors)
        {
            switch (tile.type)
            {
                case TileType.RIVER :
                    if (Mathf.Abs(tile.coordinates.x - coordinates.x) == 0 ^ Mathf.Abs(tile.coordinates.y - coordinates.y) == 0)
                    {
                        value++;
                    }
                    break;
                case TileType.SERVICE :
                    value++;
                    break;
                case TileType.SHOP :
                    if (Mathf.Abs(tile.coordinates.x - coordinates.x) == 0 ^ Mathf.Abs(tile.coordinates.y - coordinates.y) == 0)
                    {
                        value += 2;
                    }
                    break;
            }
        }
        return value;
    }

    public void SetType(TileType _type)
    {
        type = _type;
    }

    public bool CanBuy(int buyerID)
    {
        if (type == TileType.RIVER)
        {
            return false;
        }

        if (buyerID == 1) //Player
        {
            return owner == 0;
        }
        if (buyerID == 2) //Owner
        {
            return owner == 0 || owner == 3;
        }
        if (buyerID == 3) //Public
        {
            return owner == 0;
        }

        return false;
    }


    public void BuildService(GameObject serv)
    {
        hasBuilding = true;

        transform.RotateAround(transform.position, transform.up, Random.Range(0, 3) * 90f);

        GetComponent<MeshFilter>().sharedMesh = serv.GetComponent<MeshFilter>().sharedMesh;
        GetComponent<MeshRenderer>().sharedMaterials = serv.GetComponent<MeshRenderer>().sharedMaterials;

        SetType(TileType.SERVICE);
        value = 0;

        foreach (Tile tile in neighbors)
        {
            tile.EvaluateCost();
        }
    }

    public void BuildHouse(GameObject house)
    {
        hasBuilding = true;

        transform.RotateAround(transform.position, transform.up, Random.Range(0, 3) * 90f);

        GetComponent<MeshFilter>().sharedMesh = house.GetComponent<MeshFilter>().sharedMesh;
        GetComponent<MeshRenderer>().sharedMaterials = house.GetComponent<MeshRenderer>().sharedMaterials;

        ResourceManager.Instance.pop[owner - 1]++;

        selfvalue += 1;
        SetType(TileType.HOUSE);

        EvaluateCost();
    }

    public void BuildShop(GameObject store)
    {
        hasBuilding = true;

        transform.RotateAround(transform.position, transform.up, Random.Range(0, 3) * 90f);

        GetComponent<MeshFilter>().sharedMesh = store.GetComponent<MeshFilter>().sharedMesh;
        GetComponent<MeshRenderer>().sharedMaterials = store.GetComponent<MeshRenderer>().sharedMaterials;

        SetType(TileType.SHOP);

        foreach (Tile tile in neighbors)
        {
            tile.EvaluateCost();
        }
    }
}