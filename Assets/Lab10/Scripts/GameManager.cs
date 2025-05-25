using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region References
    public Transform PlayerSpawnPoint;
    public BasePlayer PlayerPrefab;

    public BasePlayer currentPlayer;

    public List<EnemySpawner> spawners = new List<EnemySpawner>();
    #endregion
    #region Getters
    public BasePlayer CurrentPlayer => currentPlayer;
    #endregion
    public static int Score = 0;

    void Start()
    {
        SetPlayer();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetPlayer()
    {
        currentPlayer = Instantiate(PlayerPrefab);

        currentPlayer.transform.position = PlayerSpawnPoint.position;


        SetSpawners();
    }
    private void SetSpawners()
    {
        foreach (EnemySpawner spawner in spawners)
        {
            spawner.SetSpawner(currentPlayer);
        }
    }
}

