using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController _instance;

    public List<GameObject> listBricks = new List<GameObject>();
    private int row = 6;
    private int col = 7;
    public float startX = -7;
    public float startY = 7;
    public GameObject brickPrefab;

    public GameObject ball;
    public GameObject Square;
    public Text txtStart;

    public Color[] listcolors;
    private bool pause;

    private void Awake()
    {
        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public static GameController getInstance()
    {
        
        return _instance;
    }

    void Start()
    {
        StartGame();
        pause = false;
    }

    public void StartGame()
    {
        createBricks();
    }

    public void createBricks()
    {
        int count = 0;
        int countIdColor = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                count++;

                countIdColor = j;
                if (countIdColor > listcolors.Length-1)
                    countIdColor = 0;

                GameObject brick = Instantiate(brickPrefab, transform.position, Quaternion.identity) as GameObject;
                brick.GetComponent<SpriteRenderer>().color = listcolors[countIdColor];
                float posX = i * 1.5f;
                float posY = j * 0.3f;
                brick.name = "brick: " + count;
                brick.transform.position = new Vector2(startX + posX, startY + posY);
                listBricks.Add(brick);
            }
        }
    }

    public bool canPlay()
    {
        return pause;
    }

    public void showText()
    {
        txtStart.gameObject.SetActive(true);
    }

    public void hideText()
    {
        txtStart.gameObject.SetActive(false);
    }


    public void checkResetGame()
    {
        if(listBricks.Count == 0)
        {
            ball.GetComponent<Ball>().resetBall();
            Square.GetComponent<Square>().resetSquare();
            StartGame();
        }
    }

    public void setPlayGame(bool pause)
    {
        this.pause = pause;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
