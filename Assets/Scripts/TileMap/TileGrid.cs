using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class TileGrid : MonoBehaviour
{
    [SerializeField]
    private float tilesize = 0;

    [SerializeField]
    private Vector2 size;
    
    [SerializeField]
    private Tile tilePrefab;

    public List<Tile> tiles = new List<Tile>();

    [SerializeField]
    private InputActionAsset actionAsset;
    private InputAction showValAction;

    private void Awake()
    {
        Generate();
        EvaluateNeighbor();

        showValAction = actionAsset.FindAction("Controls/ToggleShowVal");
        showValAction.performed += ToggleShowVal;

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
            for (int j = 0; j < size.x; j++)
            {
                Tile tile = Instantiate(tilePrefab);
                tile.transform.position = new Vector3(i * tilesize, 0, j * tilesize);
                tile.SetCood(new Vector2(i,j));
                tiles.Add(tile);
            }
        }
    }

    void EvaluateNeighbor()
    {
        foreach (Tile tile in tiles)
        {
            List<Tile> neighbors = new List<Tile>();
            neighbors.AddRange(tiles.Where(t => Mathf.Abs(t.coordinates.x - tile.coordinates.x) <= 1 && Mathf.Abs(t.coordinates.y - tile.coordinates.y) <= 1 && t != tile).ToArray());
            tile.SetNeighbor(neighbors);
        }
    }

    void ToggleShowVal(InputAction.CallbackContext ctx)
    {
        foreach (Tile tile in tiles)
        {
            tile.showVal = !tile.showVal;
        }
    }
}