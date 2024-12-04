using Unity.VisualScripting;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private ICommand currentCommand;
    [SerializeField] private GameObject[] tiles;
    public GameObject currentTile;

    public void SpawnTile()
    {
        currentTile = Pool.GetTile(GetRndTile(), transform.position, Quaternion.identity);
    }

    private string GetRndTile()
    {
        int rndValue = Random.Range(0, 5);
        return tiles[rndValue].name;
    }

    

    void Update()
    {
        Transform move = currentTile.transform;
        if (Input.GetKeyDown(KeyCode.A) && move.position.x > -6.5)
        {
            move.position = new Vector3(move.position.x - 1, move.position.y, move.position.z);
            currentTile.transform.position = move.position;
        }
        
        if (Input.GetKeyDown(KeyCode.D) && move.position.x < 6.5)
        {
            move.position = new Vector3(move.position.x + 1, move.position.y, move.position.z);
            currentTile.transform.position = move.position;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            CommandTile(new LeftCommand(), currentTile.GetComponent<TileBehaviour>());
        }
        
        if (Input.GetButtonDown("Fire2"))
        {
            CommandTile(new RightCommand(), currentTile.GetComponent<TileBehaviour>());
        }
    }
    public void CommandTile(ICommand command, TileBehaviour tile)
    {
        currentCommand = command;
        currentCommand.Execute(tile);
    }
}
