using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CroniesDisplayer : MonoBehaviour
{
    public Islands islands;
    public List<Cronie> allCronies = new List<Cronie>();
    public int nextCronieToShow = 0;
    public TMP_Text nameField;
    public TMP_Text countField;
    public TMP_Text quoteField;
    public Image imageField;

    public int currIslandMark = 0;

    public AllBuildings allBuildings;
    public Upgrade upgradeToApply;
    public GameObject endScreen;

    private void Start()
    {
        ShowNextCronie();
        islands.myDataHasUpdated += CheckIfCronieIsBeaten;
        endScreen.SetActive(false);
    }

    [Button]
    public void ShowNextCronie()
    {
        if (nextCronieToShow >= allCronies.Count)
        {
            // End the game
            endScreen.SetActive(true);
            Time.timeScale = 0;
            return;
        }
        Cronie nextCronie = allCronies[nextCronieToShow];
        nameField.text = nextCronie.cronieName + "'s Islands:";
        countField.text = nextCronie.count.ToString();
        quoteField.text = nextCronie.quote + " -";
        imageField.sprite = nextCronie.image;

        currIslandMark = nextCronie.count;

        nextCronieToShow += 1;
    }

    public void CheckIfCronieIsBeaten()
    {
        if (islands.count > currIslandMark)
        {
            string logText = "";

            logText += "Beat " + allCronies[nextCronieToShow - 1].cronieName + "!\n1.5x boost!";
            allBuildings.ApplyUprade(upgradeToApply, logText);
            // Cronie is beaten
            // TODO: Play some sort of animation
            // TODO: Give some global buff
            ShowNextCronie();
        }
    }

    private void OnDestroy()
    {
        islands.myDataHasUpdated -= CheckIfCronieIsBeaten;
    }
}
