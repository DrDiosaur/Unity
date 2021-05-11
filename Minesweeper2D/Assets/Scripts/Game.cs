using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public Tile[,] grid = new Tile[9, 9];

    public List<Tile> tilesToCheck = new List<Tile>();

    public GameObject loseMenu;
    public GameObject winMenu;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            PlaceMines();
        }

        PlaceClues();

        PlaceBlanks();

        StartCoroutine(PostRequest("www.www.www", "application"));
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        GameWin();
        StartCoroutine(PostRequest("www.www.www", "select"));
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            int x = Mathf.RoundToInt(mousePosition.x);
            int y = Mathf.RoundToInt(mousePosition.y);

            Tile tile = grid[x, y];

            if (tile.tileState == Tile.TileState.Normal)
            {
                if (tile.isCovered)
                {
                    if (tile.tileKind == Tile.TileKind.Mine)
                    {
                        GameOver(tile);
                        loseMenu.SetActive(true);
                    }
                    else
                    {
                        tile.SetIsCovered(false);
                    }

                    if (tile.tileKind == Tile.TileKind.Blank)
                    {
                        AdjacentTiles(x, y);
                    }
                }
            }



        }
    }


    private void GameWin()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Mine");
        int minesFlagged = 0;

        foreach (GameObject go in gameObjects)
        {
            Tile t = go.GetComponent<Tile>();

            if (t.tileState == Tile.TileState.Flagged)
            {
                minesFlagged += 1;
                if (minesFlagged == 10)
                {
                    winMenu.SetActive(true);
                }
            }
        }
    }

    private void GameOver(Tile tile)
    {
        tile.SetClickedMine();

        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Mine");

        foreach (GameObject go in gameObjects)
        {
            Tile t = go.GetComponent<Tile>();

            if (t != tile)
            {
                if (t.tileState == Tile.TileState.Normal)
                {
                    t.SetIsCovered(false);
                }
            }
        }

        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                Tile t = grid[x, y];

                if (t.tileState == Tile.TileState.Flagged)
                {
                    if (t.tileKind != Tile.TileKind.Mine)
                    {
                        t.SetNotAMine();
                    }
                }
            }
        }

    }

    void PlaceMines()
    {
        int x = Random.Range(0, 9);
        int y = Random.Range(0, 9);

        if (grid[x, y] == null)
        {
            Tile mineTile = Instantiate(Resources.Load("Prefabs/Mine", typeof(Tile)), new Vector3(x, y, 0),
                Quaternion.identity) as Tile;

            grid[x, y] = mineTile;
        }
        else
        {
            PlaceMines();
        }

    }

    void PlaceClues()
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (grid[x, y] == null)
                {
                    int numMines = 0;

                    if (y + 1 < 9)
                    {
                        if (grid[x, y + 1] != null && grid[x, y + 1].tileKind == Tile.TileKind.Mine) numMines++;
                    }

                    if (x + 1 < 9)
                    {
                        if (grid[x + 1, y] != null && grid[x + 1, y].tileKind == Tile.TileKind.Mine) numMines++;
                    }

                    if (y - 1 >= 0)
                    {
                        if (grid[x, y - 1] != null && grid[x, y - 1].tileKind == Tile.TileKind.Mine) numMines++;
                    }

                    if (x - 1 >= 0)
                    {
                        if (grid[x - 1, y] != null && grid[x - 1, y].tileKind == Tile.TileKind.Mine) numMines++;
                    }

                    if (x + 1 < 9 && y + 1 < 9)
                    {
                        if (grid[x + 1, y + 1] != null && grid[x + 1, y + 1].tileKind == Tile.TileKind.Mine) numMines++;
                    }

                    if (x - 1 >= 0 && y + 1 < 9)
                    {
                        if (grid[x - 1, y + 1] != null && grid[x - 1, y + 1].tileKind == Tile.TileKind.Mine) numMines++;
                    }

                    if (x + 1 < 9 && y - 1 >= 0)
                    {
                        if (grid[x + 1, y - 1] != null && grid[x + 1, y - 1].tileKind == Tile.TileKind.Mine) numMines++;
                    }

                    if (y - 1 >= 0 && x - 1 >= 0)
                    {
                        if (grid[x - 1, y - 1] != null && grid[x - 1, y - 1].tileKind == Tile.TileKind.Mine) numMines++;
                    }




                    if (numMines > 0)
                    {
                        Tile clueTile = Instantiate(Resources.Load("Prefabs/" + numMines, typeof(Tile)),
                            new Vector3(x, y, 0), Quaternion.identity) as Tile;

                        grid[x, y] = clueTile;
                    }
                }
            }
        }
    }

    void PlaceBlanks()
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (grid[x, y] == null)
                {
                    Tile blankTile = Instantiate(Resources.Load("Prefabs/Blank", typeof(Tile)), new Vector3(x, y, 0),
                        Quaternion.identity) as Tile;

                    grid[x, y] = blankTile;
                }
            }
        }
    }

    void AdjacentTiles(int x, int y)
    {

        if (y + 1 < 9)
        {
            CheckTileAt(x, y + 1);
        }

        if (x + 1 < 9)
        {
            CheckTileAt(x + 1, y);
        }

        if (y - 1 >= 0)
        {
            CheckTileAt(x, y - 1);
        }

        if (x - 1 >= 0)
        {
            CheckTileAt(x - 1, y);
        }

        if (y + 1 < 9 && x + 1 < 9)
        {
            CheckTileAt(x + 1, y + 1);
        }

        if (y + 1 < 9 && x - 1 >= 0)
        {
            CheckTileAt(x - 1, y + 1);
        }

        if (y - 1 >= 0 && x + 1 < 9)
        {
            CheckTileAt(x + 1, y - 1);
        }

        if (y - 1 >= 0 && x - 1 >= 0)
        {
            CheckTileAt(x - 1, y - 1);
        }

        for (int i = tilesToCheck.Count - 1; i >= 0; i--)
        {
            if (tilesToCheck[i].didCheck)
            {
                tilesToCheck.RemoveAt(i);
            }
        }

        if (tilesToCheck.Count > 0)
        {
            RevealAdjacentTiles();
        }
    }

    private void RevealAdjacentTiles()
    {
        for (int i = 0; i < tilesToCheck.Count; i++)
        {
            Tile tile = tilesToCheck[i];

            int x = (int) tile.gameObject.transform.localPosition.x;
            int y = (int) tile.gameObject.transform.localPosition.y;

            tile.didCheck = true;

            if (tile.tileState != Tile.TileState.Flagged)
            {
                tile.SetIsCovered(false);
            }

            AdjacentTiles(x, y);
        }
    }

    private void CheckTileAt(int x, int y)
    {
        Tile tile = grid[x, y];

        if (tile.tileKind == Tile.TileKind.Blank)
        {
            tilesToCheck.Add(tile);
        }
        else if (tile.tileKind == Tile.TileKind.Clue)
        {
            tile.SetIsCovered(false);
        }
        else if (tile.tileKind == Tile.TileKind.Mine)
        {

        }
    }


    IEnumerator PostRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "Post");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler) new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        yield return uwr.SendWebRequest();
        
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }

    }


}
