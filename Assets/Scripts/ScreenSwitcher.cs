using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject rulesScreen;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject loseScreen;
    [Space, SerializeField] private GameManager gameManager;

    private GameObject currentScreen;

    private void Start()
    {
        currentScreen = mainMenu;
        gameManager.PlayerLose += ShowLoseScreen;
    }

    private void ShowMainMenu()
    {
        currentScreen.SetActive(false);
        currentScreen = mainMenu;
        currentScreen.SetActive(true);
    }

    public void ShowRulesScreen()
    {
        currentScreen.SetActive(false);
        currentScreen = rulesScreen;
        currentScreen.SetActive(true);
    }

    public void ShowGameScreen()
    {
        currentScreen.SetActive(false);
        currentScreen = gameScreen;
        currentScreen.SetActive(true);
    }

    private void ShowLoseScreen()
    {
        currentScreen.SetActive(false);
        currentScreen = loseScreen;
        currentScreen.SetActive(true);
    }
}
