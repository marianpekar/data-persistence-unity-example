using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    private class GameData
    {
        public Vector3 PlayerPosition;
    }

    private GameData gameData;

    public Vector3 PlayerPosition
    {
        get => gameData.PlayerPosition;
        set => gameData.PlayerPosition = value;
    }

    private string gameDataFilename = "GameData.dat";

    public void LoadGameData()
    {
        Debug.Log("Application.persistentDataPath=" + Application.persistentDataPath);

        string gameDataPath = Path.Combine(Application.persistentDataPath, gameDataFilename);

        if (File.Exists(gameDataPath))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(gameDataPath, FileMode.Open))) { 
                GameData gameData = new GameData();
                gameData.PlayerPosition.x = reader.ReadSingle();
                gameData.PlayerPosition.y = reader.ReadSingle();
                gameData.PlayerPosition.z = reader.ReadSingle();
                this.gameData = gameData;
            }
        }
        else
        {
            gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        string gameDataPath = Path.Combine(Application.persistentDataPath, gameDataFilename);

        using (BinaryWriter writer = new BinaryWriter(File.Open(gameDataPath, FileMode.Create)))
        {
            writer.Write(gameData.PlayerPosition.x);
            writer.Write(gameData.PlayerPosition.y);
            writer.Write(gameData.PlayerPosition.z);
        };
    }
}