using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    [Space, SerializeField] private GameManager gameManager;

    private int hp = 3;

    private void Start()
    {
        gameManager.PlayerMissed += TakeDamage;
        gameManager.Reset += Reset;
    }

    private void TakeDamage()
    {
        if(hp==3)
        {
            heart3.gameObject.SetActive(false);
        }
        else if(hp==2)
        {
            heart2.gameObject.SetActive(false);
        }

        hp--;
    }

    private void Reset()
    {
        hp = 3;
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }
}
