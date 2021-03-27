using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    private readonly BinaryFormatter binaryFormatter = new BinaryFormatter();

    [Serializable]
    private class GameData
    {
        public SerializableVector3 PlayerPosition = SerializableVector3.FromVector3(Vector3.zero);
    }

    private GameData gameData;

    public Vector3 PlayerPosition
    {
        get => SerializableVector3.ToVector3(gameData.PlayerPosition);
        set => gameData.PlayerPosition = SerializableVector3.FromVector3(value);
    }

    private string gameDataPath;

    public void LoadGameData()
    {
        gameDataPath = Path.Combine(Application.persistentDataPath, "GameData.dat");

        if (File.Exists(gameDataPath))
        {
            FileStream gameDataFile = File.Open(gameDataPath, FileMode.Open);
            GameData gameData = (GameData)binaryFormatter.Deserialize(gameDataFile);
            gameDataFile.Close();

            this.gameData = gameData;
        }
        else
        {
            this.gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        FileStream gameDataFile = File.Create(gameDataPath);
        binaryFormatter.Serialize(gameDataFile, this.gameData);
        gameDataFile.Close();
    }
}