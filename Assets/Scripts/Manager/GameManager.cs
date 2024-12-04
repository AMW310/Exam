using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TileManager tiles;

    void Start()
    {
        tiles.SpawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        TileBehaviour _tile = tiles.currentTile.GetComponent<TileBehaviour>();
        if (!_tile.canMove)
        {
            tiles.SpawnTile();
        }
    }

    
}
