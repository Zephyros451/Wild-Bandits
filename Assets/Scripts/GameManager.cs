using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public event Action LevelComplete;
    public event Action<Sprite> NewTarget;
    public event Action PlayerHit;
    public event Action PlayerMissed;    
    public event Action PlayerLose;
    public event Action Reset;

    [SerializeField] private Sprite[] targetIcons;
    [SerializeField] private Image[] grid = new Image[25];

    private int currentLevel = 1;
    private int iconsNumber = 0;
    private Sprite currentTarget;
    private List<Sprite> activeIcons = new List<Sprite>();
    private List<Sprite> notUsedIcons = new List<Sprite>();

    private int firstTargetIndex, secondTargetIndex, thirdTargetIndex;
    private int missesCount = 0;
    private int hitCount = 0;

    public void GenerateLevel()
    {
        ChooseNewTarget();
        GenerateGrid();
    }

    private void ChooseNewTarget()
    {
        int randomIndex = GetRandomIconIndex(targetIcons.Length);
        currentTarget = targetIcons[randomIndex];
        NewTarget?.Invoke(currentTarget);
    }    

    private void GenerateGrid()
    {
        FillGrid();
        SetTargetsOnTheGrid();
    }

    private void FillGrid()
    {
        activeIcons.Clear();
        notUsedIcons = new List<Sprite>(targetIcons);
        notUsedIcons.Remove(currentTarget);

        if (currentLevel % 2 > 0 && iconsNumber < targetIcons.Length - 1)
        {
            iconsNumber++;
        }
        Debug.Log(iconsNumber);
        while (activeIcons.Count < iconsNumber)
        {
            int randomIndex = GetRandomIconIndex(notUsedIcons.Count - 1);
            activeIcons.Add(notUsedIcons[randomIndex]);
            notUsedIcons.Remove(notUsedIcons[randomIndex]);
        }

        for (int i = 0; i < grid.Length; i++)
        {
            int randomIndex = GetRandomIconIndex(activeIcons.Count);
            grid[i].sprite = activeIcons[randomIndex];
        }
    }

    private void SetTargetsOnTheGrid()
    {
        firstTargetIndex = GetRandomIconIndex(grid.Length);
        secondTargetIndex = firstTargetIndex;
        thirdTargetIndex = firstTargetIndex;

        while (secondTargetIndex == firstTargetIndex)
        {
            secondTargetIndex = GetRandomIconIndex(grid.Length);
        }

        while (thirdTargetIndex == firstTargetIndex || thirdTargetIndex == secondTargetIndex)
        {
            thirdTargetIndex = GetRandomIconIndex(grid.Length);
        }

        grid[firstTargetIndex].sprite = currentTarget;
        grid[secondTargetIndex].sprite = currentTarget;
        grid[thirdTargetIndex].sprite = currentTarget;
    }

    public void CheckShot(int index)
    {
        grid[index].raycastTarget = false;

        if (index == firstTargetIndex || index == secondTargetIndex || index == thirdTargetIndex)
        {
            PlayerHit?.Invoke();
            hitCount++;

            if(hitCount == 3)
            {
                hitCount = 0;
                LevelComplete?.Invoke();
                currentLevel++;
                GenerateLevel();
                ResetGridInteractability();
            }
        }
        else
        {
            PlayerMissed?.Invoke();
            missesCount++;

            if(missesCount==3)
            {
                PlayerLose?.Invoke();                
                ResetGame();
            }
        }
    }

    private void ResetGame()
    {
        missesCount = 0;
        currentLevel = 1;
        iconsNumber = 0;
        GenerateLevel();
        Reset?.Invoke();
        ResetGridInteractability();
    }

    private void ResetGridInteractability()
    {
        for (int i = 0; i < grid.Length; i++)
        {
            grid[i].raycastTarget = true;
        }
    }

    private int GetRandomIconIndex(int iconCount)
    {
        return UnityEngine.Random.Range(0, iconCount);
    }
}
