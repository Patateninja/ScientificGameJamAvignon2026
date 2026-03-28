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
        selfvalue = 1;
        value = 1;
        hasBuilding = false;
        //satisfaction = 1;
    }

    void Update()
    {
        if (owner == 0)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        if (owner == 1)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        if (owner == 2)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        text.text = value.ToString();
        text.gameObject.SetActive(showVal);

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
        if (type == TileType.SERVICE)
        {
            return 0;
        }

        value = selfvalue;
        foreach (Tile tile in neighbors)
        {
            switch (tile.type)
            {
                case TileType.RIVER :
                    value++;
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
}