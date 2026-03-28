using UnityEngine;
using UnityEngine.Events;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    public int turn = 1;
    public TileGrid map;

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
        foreach (Tile tile in map.tiles)
        {
            if (tile.owner == 1)
            {
                tile.EndOfTurn();
                ResourceManager.Instance.AddMoney(tile.value);
            }
        }
    }
}
