using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PublicAI : MonoBehaviour
{
    [SerializeField]
    TileGrid grid;

    public GameObject house;
    public GameObject service;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Play()
    {
        Debug.Log("Public Turn");

        bool canBuy = grid.tiles.Where(t => t.owner == 3).ToList().Count < (grid.tiles.Count / 3);

        while (canBuy)
        {
            List<Tile> aviableTile = grid.tiles.Where(t => t.CanBuy(3) && t.value < ResourceManager.Instance.balances[2] && t.type != TileType.RIVER).OrderBy(t => t.value).ToList();

            if (aviableTile.Count == 0) return;

            Tile bestTile = aviableTile[0];

            if (ResourceManager.Instance.balances[2] > aviableTile[0].value)
            {
                bestTile.SetOwner(3);
                ResourceManager.Instance.AddMoney(-bestTile.value, 2);

                if (TurnManager.instance.turn != 1)
                {
                    if (ResourceManager.Instance.pop[2] < ResourceManager.Instance.totalPop / 5)
                    {
                        bestTile.BuildHouse(house);
                    }
                    else
                    {
                        if (Random.Range(0, 1) == 1)
                        {
                            bestTile.BuildService(service);
                        }
                    }
                }

                return;
            }
        }
    }
}
