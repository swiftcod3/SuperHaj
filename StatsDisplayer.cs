using TMPro;
using UnityEngine;

public class StatsDisplayer : MonoBehaviour
{
    StatTracker stats;
    TMP_Text textBox;
    public TMP_Text score;
    void Start()
    {
        stats = StatTracker.instance;
        textBox = GetComponent<TMP_Text>();
    }

    void Update()
    {
        textBox.text = 
            "Enemies Killed: " + (stats.HarpoonerKills + stats.NetterKills + stats.SubmarineKills + stats.SeaMineSpawnerKills) + 
            "\r\nHarpooners Killed: " + (stats.HarpoonerKills) + 
            "\r\nNet Throwers Killed: " + (stats.NetterKills) + 
            "\r\nTorpedo Submarines Killed: " + (stats.SubmarineKills) +
            "\r\nMine Layer Submarines Killed: " + (stats.SeaMineSpawnerKills) +
            "\r\nMines Killed: " + (stats.SeaMineKills) +
            "\r\nRound: " + stats.Round +
            "\r\nFINAL SCORE: " + (stats.Score);
        score.text = "SCORE: " + stats.Score;
    }
}
