using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditorInternal;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;


public class TestIsometric : MonoBehaviour
{
    public int colCount, rowCount;
    public Vector2 startPos;

    private GameObject mapTile;
    private Coroutine routine;
    private int tileWidth = 64;
    private int tileHeight = 32;
    private int col = 0; //행
    private int row = 0; //열

    private GameObject my;
    private GameObject motherNode;
    private GameObject targetNode;
    private GameObject selectedTile;

    private Dictionary<Vector2, GameObject> dicFIndTile = new Dictionary<Vector2, GameObject>();
    private List<GameObject> openList = new List<GameObject>();
    private List<GameObject> closeList = new List<GameObject>();

    void Start()
    {
        this.CreateMap();
        this.CreateTile();
        this.TileCheck();
    }

    void TileCheck()
    {
        if (this.routine != null)
        {
            StopCoroutine(this.routine);
        }
        this.routine = StartCoroutine(this.TileCheckImpl());
    }

    IEnumerator TileCheckImpl()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

                if (hit.collider != null)
                {
                    this.targetNode = hit.collider.gameObject;
                    this.FIndNextPos();
                }
            }
            yield return null;
        }
    }

    private void FIndNextPos()
    {
        if (this.routine != null)
        {
            StopCoroutine(this.routine);
        }
        this.routine = StartCoroutine(this.FindNextPosImpl());
    }

    private IEnumerator FindNextPosImpl()
    {
        while (true)
        {
            if (this.targetNode == this.motherNode)
            {
                Debug.Log("도착");
                this.TileCheck();
                break;
            }
            this.FindNode();
            this.SetFGH();
            this.SortingOpenList();

            yield return null;
        }
    }


    private void SortingOpenList()
    {
        IEnumerable<GameObject> sortNode = this.openList.OrderBy(x => x.GetComponent<TestTile>().f);

        this.selectedTile = sortNode.FirstOrDefault<GameObject>();

        this.NextNode();
    }

    private void SetActiveFGH(GameObject tile)
    {
        if (!this.openList.Contains(tile))
        {
            tile.GetComponent<TestTile>().G.gameObject.SetActive(false);
            tile.GetComponent<TestTile>().F.gameObject.SetActive(false);
            tile.GetComponent<TestTile>().H.gameObject.SetActive(false);
        }
        else
        {
            tile.GetComponent<TestTile>().G.gameObject.SetActive(true);
            tile.GetComponent<TestTile>().F.gameObject.SetActive(true);
            tile.GetComponent<TestTile>().H.gameObject.SetActive(true);
        }
    }

    private void NextNode()
    {
        this.motherNode = this.selectedTile;
        this.selectedTile.GetComponentInChildren<SpriteRenderer>().color = Color.magenta;
    }

    private void FindNode()
    {
        var mother = this.motherNode.GetComponent<TestTile>();

        var motherX = mother.vec2.x - 1;
        var motherY = mother.vec2.y - 1;
        var maxX = mother.vec2.x + 1;
        var maxY = mother.vec2.y + 1;

        if (motherX < 0)
        {
            motherX = 0;
        }
        if (motherY < 0)
        {
            motherY = 0;
        }

        for (int x = (int)motherX; x <= maxX; x++)
        {
            for (int y = (int)motherY; y <= maxY; y++)
            {
                var data = new Vector2(x, y);

                var tile = this.dicFIndTile[data];

                if (tile.GetComponent<TestTile>().isBlock != true && !this.closeList.Contains(tile))
                {
                    this.openList.Add(tile);
                    this.openList.Remove(motherNode);

                    this.closeList.Add(motherNode);
                    if (tile != this.motherNode)
                    {
                        tile.GetComponent<SpriteRenderer>().color = Color.yellow;
                    }
                }
            }
        }
    }

    private void SetFGH()
    {
        foreach (var tile in this.openList)
        {
            var tileScript = tile.GetComponent<TestTile>();
            this.SetActiveFGH(tile);
            var getG = tile.GetComponent<TestTile>().g;
            var getH = tile.GetComponent<TestTile>().h;
            getG = Mathf.Round(Vector2.Distance(tile.GetComponent<TestTile>().vec2, this.motherNode.GetComponent<TestTile>().vec2) * 10);
            var dx = Mathf.Abs(tile.GetComponent<TestTile>().vec2.x - this.targetNode.GetComponent<TestTile>().vec2.x);
            var dy = Mathf.Abs(tile.GetComponent<TestTile>().vec2.y - this.targetNode.GetComponent<TestTile>().vec2.y);

            getH = (dx + dy) * 10;

            tile.GetComponent<TestTile>().f = getG + getH;

            tileScript.G.text = getG.ToString();
            tileScript.H.text = getH.ToString();
            tileScript.F.text = tile.GetComponent<TestTile>().f.ToString();
        }
    }

    #region 맵, 타일 생성
    private void CreateTile()
    {
        if (this.my == null)
        {
            this.my = Instantiate(Resources.Load<GameObject>("myIsoTile"));

            this.CreatedTileMap(my, this.startPos.x, this.startPos.y);
            this.motherNode = my;
        }
    }

    private void CreateMap()
    {
        while (true)
        {
            this.mapTile = Instantiate(Resources.Load<GameObject>("isoTile"));

            this.mapTile.tag = "Tile";

            this.mapTile.transform.SetParent(this.transform);

            this.CreatedTileMap(this.mapTile, this.col, row);
            this.dicFIndTile.Add(new Vector2(col, row), mapTile);
            this.col++;

            if (this.col >= this.colCount)
            {
                this.col = 0;
                this.row++;
            }
            if (this.row >= this.rowCount)
            {
                row = 0;
                break;
            }


        }
    }

    private void CreatedTileMap(GameObject tileMap, float x, float y)
    {
        var vec2 = new Vector2(x, y);

        if (tileMap.GetComponentInChildren<TextMesh>())
        {
            tileMap.GetComponentInChildren<TextMesh>().text = string.Format("({0},{1})", x, y);
            this.SetActiveFGH(tileMap);
        }

        tileMap.AddComponent<TestTile>();
        tileMap.GetComponent<TestTile>().vec2 = vec2;

        var screen = this.MapToScreen(vec2);

        var screenPos = Camera.main.ScreenToWorldPoint(new Vector2(screen.x + 512, screen.y + 384 + 100));

        tileMap.transform.position = new Vector3(screenPos.x, screenPos.y, 0);
    }

    public Vector2 MapToScreen(Vector2 mapPos)
    {
        var screenX = mapPos.x * this.tileWidth - (mapPos.y * this.tileWidth);
        var screenY = mapPos.y * -tileHeight - (mapPos.x * tileHeight);

        return new Vector2(screenX, screenY);
    }
    #endregion
}
