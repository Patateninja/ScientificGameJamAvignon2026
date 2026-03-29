using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MayorAI : MonoBehaviour
{
    [SerializeField]
    TileGrid grid;

    public GameObject house;
    public GameObject service;
    public GameObject store;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Play()
    {
        Debug.Log("Mayor Turn");

        bool canBuy = true;

        while (canBuy)
        {
            List<Tile> aviableTile = grid.tiles.Where(t => t.CanBuy(2) && t.value < ResourceManager.Instance.balances[1] && t.type != TileType.RIVER).OrderByDescending(t => t.value).ToList();

            if (aviableTile.Count == 0) return;

            Tile bestTile = aviableTile[0];

            if (ResourceManager.Instance.balances[1] > aviableTile[0].value)
            {
                bestTile.SetOwner(2);
                ResourceManager.Instance.AddMoney(-bestTile.value, 1);

                if (TurnManager.instance.turn != 1)
                {
                    if (bestTile.neighbors.Where(t => t.owner != 1 && t.type == TileType.HOUSE).ToList().Count >= bestTile.value)
                    {
                        if (Random.Range(0,1) == 1)
                        {
                            bestTile.BuildService(service);
                        }
                        else
                        {
                            bestTile.BuildShop(store);
                        }
                    }
                    else
                    {
                        bestTile.BuildHouse(house);
                    }
                }
            }
            else
            {
                canBuy = false;
            }
        }
    }
}
