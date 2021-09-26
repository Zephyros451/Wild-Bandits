using UnityEngine;
using TMPro;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameManager gameManager;

    private int currentLevel = 1;

    private void Start()
    {
        gameManager.Reset += Reset;
        gameManager.LevelComplete += UpdateLevel;
        Reset();
    }

    private void UpdateLevel()
    {
        currentLevel++;
        text.text = currentLevel.ToString();
    }

    private void Reset()
    {        
        currentLevel = 1;
        text.text = currentLevel.ToString();
    }
}
