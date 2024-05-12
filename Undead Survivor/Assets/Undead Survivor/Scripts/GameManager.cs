using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameTime;
    public float maxGameTime = 2 * 10f;

    public PoolManager pool;
    public Player player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime){
            gameTime = maxGameTime;
        }
    }
}
