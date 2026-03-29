using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private MayorAI mayor;

    [SerializeField]
    private PublicAI pub;

    public static TurnManager instance;

    public int turn = 1;
    public TileGrid map;

    public bool playerTurn = true;

    private int taxes = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EndOfTurn()
    {
        mayor.Play();
        pub.Play();

        List<int> revenue = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            revenue.Add(0);
        }

        foreach (Tile tile in map.tiles)
        {
            if (tile.owner != 0 && tile.owner != 3)
            {
                tile.EndOfTurn();
                revenue[tile.owner - 1] += tile.value;
            }
        }

        for (int i =  0; i < revenue.Count; i++)
        {
            float money = revenue[i] * ((100 - taxes) / 100);
            ResourceManager.Instance.AddMoney(Mathf.RoundToInt(money), i);
            ResourceManager.Instance.AddMoney(revenue[i] - Mathf.RoundToInt(money), 2);
        }

        EvaluateTaxes();

        ResourceManager.Instance.UpdatePop();

        if (ResourceManager.Instance.balances[1] > 75)
        {
            //Mayor Vicotry
        }

        if (ResourceManager.Instance.pop[0] > ResourceManager.Instance.totalPop / 2)
        {
            //Player Victory
        }

        turn++;
    }

    void EvaluateTaxes()
    {
        taxes = turn > 3 ? 5 : 0;
    }
}
