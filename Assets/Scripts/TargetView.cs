using UnityEngine;
using UnityEngine.UI;

public class TargetView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        gameManager.NewTarget += SetIcon;
    }

    private void SetIcon(Sprite newSprite)
    {
        icon.sprite = newSprite;
    }
}
