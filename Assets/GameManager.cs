using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Members are assigned via Inspector
    [SerializeField]
    private PersistenceManager persistenceManager = null;

    [SerializeField]
    private GameObject player = null;

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
