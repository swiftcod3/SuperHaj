using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenManager : MonoBehaviour
{

    DeathScreenManager Instance;

    private void Start()
    {
        Instance = this;
    }

    public void Replay()
    {
        SceneManager.LoadScene("game");
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
