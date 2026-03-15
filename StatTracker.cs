using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatTracker : MonoBehaviour
{
    public static StatTracker instance;

    public int NetterKills;
    public int HarpoonerKills;
    public int SubmarineKills;
    public int SeaMineKills;
    public int SeaMineSpawnerKills;
    public int Score;

    public int Round;
    public List<int> itemIDs;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        itemIDs = new List<int>();

        // Subscribe to scene load events
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        Score = (NetterKills * 25) + (HarpoonerKills * 15) + (SubmarineKills * 50) + (SeaMineSpawnerKills * 40) + (SeaMineKills * 5);
    }

    // This runs every time a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "game")
        {
            NetterKills = 0;
            HarpoonerKills = 0;
            SubmarineKills = 0;
            SeaMineKills = 0;
            SeaMineSpawnerKills = 0;
            Round = 0;
            itemIDs.Clear(); // reset list
        }
    }

    void OnDestroy()
    {
        // Unsubscribe to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
