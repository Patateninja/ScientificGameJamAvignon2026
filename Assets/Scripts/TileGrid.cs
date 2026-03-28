using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGrid : MonoBehaviour
{
    [SerializeField]
    private int tilesize = 0;

    [SerializeField]
    private Vector2 size = new();
    
    [SerializeField]
    private Tile tilePrefab;

    List<Tile> tiles = new List<Tile>();

    private void Awake()
    {
        Generate();
    }

    void Start()
    {
        if (tilePrefab == null)
        {
            Debug.LogWarning("NO TILE PREFAB");
        }
    }

    void Update()
    {
        
    }

    void Generate()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; i < size.y; j++)
            {
                Tile tile = Instantiate(tilePrefab);
                tiles.Add(tile);
                tile.transform.position = new Vector3(i, 0, j);
            }
        }
    }
}
