using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] Level;
    public int uncoloredTiles = 10; // colored tiles number
    private int i = 0; //level iterator
    private int TileCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void setLevel()
    {

        {
            Debug.Log("Level completed");
            Debug.Log(i);
            Level[i].SetActive(false);
            Level[i + 1].SetActive(true);
            TileCounter = 0;
            SetUnColoredTiles();
            if (i < 4)
                i++;
        }
    }

    public void SetUnColoredTiles()
    {
        var tiles = GameObject.FindGameObjectsWithTag("ground");

        for (var i = 0; i < tiles.Length; i++)
        {
            TileCounter++;
        }

        uncoloredTiles = TileCounter;

    }

}
