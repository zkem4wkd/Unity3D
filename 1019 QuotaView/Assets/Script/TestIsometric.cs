using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class TestIsometric : MonoBehaviour
{
    public Button createTileBtn;
    public Button createMyTilebtn;
    public int colCount, rowCount;
    public int myColPosition, myRowPosition;

    private GameObject mapTile;
    private Coroutine routine;
    private int tileWidth = 64;
    private int tileHeight = 32;
    private int col = 0; //행
    private int row = 0; //열

    private GameObject my;
    private Vector2 vec2;
    private Vector2 tileVec2;
    private Dictionary<Vector2, GameObject> dicFIndTile =
        new Dictionary<Vector2, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        this.createTileBtn.onClick.AddListener(() =>
        {
            this.CreateMap();
        });

        createMyTilebtn.onClick.AddListener(() =>
        {
            CreateTile();
        });
        TileCheck();

    }

    private void CreateTile()
    {
        if(my == null)
        {
            my = Instantiate(Resources.Load<GameObject>("myisoTile"));

            CreateTileMap(my, myColPosition, myRowPosition);
        }
    }

    void TileCheck()
    {
        if(routine != null)
        {
            StopCoroutine(routine);
        }
        routine = StartCoroutine(TileCheckImpl());
    }
    IEnumerator TileCheckImpl()
    {
        while(true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector2 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldpos, Vector2.zero);
                if(hit.collider != null)
                {
                    var data = dicFIndTile.TryGetValue(vec2, out mapTile);

                    if(hit.collider == data)
                    {
                        var target = hit.collider.gameObject;
                        MoveTransform(target);
                        break;
                    }
                }
            }
            yield return null;
        }
    }
    private void MoveTransform(GameObject target)
    {
        if(routine != null)
        {
            StopCoroutine(routine);
        }
        routine = StartCoroutine(MoveTransformImpl(target));
    }

    IEnumerator MoveTransformImpl(GameObject target)
    {
        while (true)
        {
            var dir = (target.transform.position - my.transform.position).normalized;
            var distance = Vector3.Distance(target.transform.position, my.transform.position);

            my.transform.position += dir * 2f * Time.deltaTime;
            if (distance <= 0.02f)
            {
                Debug.Log("complete");
                my.transform.position = target.transform.position;
                TileCheck();
                break;
            }
            yield return null;
        }
    }
    private void CreateMap()
    {
        while(true)
        {
            //Resources폴더가 있어야된다. 
            //리소스폴더가 시작점 거기에 있는 isoTile이라는 이름의 게임오브젝트를 가져온다.
            mapTile = Instantiate(Resources.Load<GameObject>("isoTile"));
            mapTile.tag = "Tile";

            var isometric = GameObject.Find("TestIsometricBuilding");

            //TestIsometricBuilding->mapTile
            mapTile.transform.SetParent(isometric.transform);
            CreateTileMap(mapTile, col, row);
            col++;
            if(col >= colCount)
            {
                col = 0;
                row++;
            }
            if(row >=rowCount)
            {
                createTileBtn.gameObject.SetActive(false);
                row = 0;
                break;
            }
            dicFIndTile.Add(new Vector2(col, row), mapTile);
        }
    }
    private void CreateTileMap(GameObject tileMap, float x, float y)
    {
        vec2 = new Vector2(x, y);

        if(tileMap.GetComponentInChildren<TextMesh>())
        {
            tileMap.GetComponentInChildren<TextMesh>().text
                = string.Format("({0},{1})", x, y);
        }

        //screen  world
        //map->ui 
        var screen = MapToScreen(vec2);

        var screenPos = 
            Camera.main.ScreenToWorldPoint(new Vector2(
                screen.x + 512, screen.y + 384+100));

        tileMap.transform.position = new Vector3(screenPos.x, screenPos.y, 0);        
    }
    //맵좌표를 스크린좌표로
    public Vector2 MapToScreen(Vector2 mapPos)
    {
        var screenX = mapPos.x * this.tileWidth - (mapPos.y * this.tileWidth);
        var screenY = mapPos.y * -tileHeight - (mapPos.x * tileHeight);

        return new Vector2(screenX, screenY);
    }



    
}
