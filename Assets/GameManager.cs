using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private PersistenceManager persistenceManager;

    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        persistenceManager.LoadGameData();
    }

    void Start()
    {
        player.transform.position = persistenceManager.PlayerPosition;
    }

    void OnApplicationQuit()
    {
        persistenceManager.PlayerPosition = player.transform.position;
        persistenceManager.SaveGameData();
    }
}
