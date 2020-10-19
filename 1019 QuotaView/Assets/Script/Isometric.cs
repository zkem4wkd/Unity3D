using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Isometric : MonoBehaviour
{
    public Button createTileBtn;
    public Button createMyTileBtn;
    public int colCount, rowCount;
    public int myColPosition, myRowpoisition;

    private GameObject mapTile;
    private Coroutine routine;
    private int tileWidth = 64;
    private int tileHeight = 32;
    private int col = 0;
    private int row = 0;

    private GameObject my;
    private Vector2 vec2;
    private Vector2 tileVec2;
    private Dictionary<Vector2, GameObject> dicFindTile = new Dictionary<Vector2, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        this.createTileBtn.onClick.AddListener(() => { this.CreateMap(); });
        //createMyTileBtn.onClick.AddListener(() => { createTileBtn(); });
    }
    private void CreateMap()
    {
        while(true)
        {
            //Resources 폴더에 있는 파일 불러오기
            mapTile = Instantiate(Resources.Load<GameObject>("isoTile"));
            mapTile.tag = "Tile";

            var isometric = GameObject.Find("Testisometricbuilding");

            mapTile.transform.SetParent(isometric.transform);
            CreateTileMap(mapTile,col,row);
            col++;
            if(col >= colCount)
            {
                col = 0;
                row++;
            }
            if(row >= rowCount)
            {
                createTileBtn.gameObject.SetActive(false);
                row = 0;
                break;
            }
            dicFindTile.Add(new Vector2(col, row), mapTile);
        }
    }
    private void CreateTileMap(GameObject tileMap, float x , float y)
    {
        vec2 = new Vector2(x, y);

        if (tileMap.GetComponentInChildren<TextMesh>())
        {
            tileMap.GetComponentInChildren<TextMesh>().text = string.Format("({0},{1})", x, y);
        }

        var screen = MapToScreen(vec2);

        var screenPos = Camera.main.ScreenToWorldPoint(new Vector2(screen.x + 512, screen.y + 384 + 100));

        tileMap.transform.position = new Vector3(screenPos.x, screenPos.y,0);
    }

    public Vector2 MapToScreen(Vector2 mapPos)
    {
        var screenX = mapPos.x * this.tileWidth - (mapPos.y * this.tileWidth);
        var screenY = mapPos.y * this.tileHeight - (mapPos.y * this.tileHeight);

        return new Vector2(screenX, screenY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
