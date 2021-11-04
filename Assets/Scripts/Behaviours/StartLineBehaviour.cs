using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLineBehaviour : MonoBehaviour
{

    public PlayerBehaviour playerPrefab;

    public void Start()
    {
        App.levelManager.onStart.AddListener(SpawnPlayer);
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, transform.position, transform.rotation);
    }
}
