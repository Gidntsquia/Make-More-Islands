using System.Collections.Generic;
using System.Linq;
using TMPro;
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


    private void Start()
    {
        ShowNextCronie();
        islands.myDataHasUpdated += CheckIfCronieIsBeaten;
    }

    public void ShowNextCronie()
    {
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
