using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour
{
    private readonly static int TILES_TO_CREATE = 50;
    private readonly static int TILES_TO_SPAWN = 30;

    public GameObject tilePrefab;

    public GameObject currentTile;

    private static TileManager instance;

    public static TileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }
    }

    private Stack<GameObject> tiles;

    // Use this for initialization
    void Start()
    {
        tiles = new Stack<GameObject>();
        CreateTiles(TILES_TO_CREATE);
        for (int i = 0; i < TILES_TO_SPAWN; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateTiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newTile = Instantiate(tilePrefab);
            newTile.SetActive(false);
            tiles.Push(newTile);
        }
    }

    public void AddTile(GameObject tile)
    {
        tiles.Push(tile);
    }

    public void SpawnTile()
    {        
        if (tiles.Count == 0)
        {
            CreateTiles(5);
        }

        int direction = Random.Range(0, 2);

        GameObject newTile = tiles.Pop();        
        newTile.transform.position = currentTile.transform.GetChild(0).transform.GetChild(direction).position;
        newTile.SetActive(true);
        currentTile = newTile;

        bool spawnPickup = Random.Range(0, 20) == 0 ? true : false;
        if (spawnPickup)
        {
            newTile.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}
