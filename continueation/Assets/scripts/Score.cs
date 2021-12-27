using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI textUI;
    private float startingTime;
    private bool isAlive = true;

    private void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
        startingTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            textUI.text = ((int)((Time.time - startingTime)*2)).ToString();
        }
    }

    public void Reset()
    {
        startingTime = Time.time;
    }

    public void NotAlive()
    {
        isAlive = false;
        if (IsScoreBiggerThanHighscore())
        {
            SaveSystem.SaveAtLocation(new int[]{ int.Parse(textUI.text.ToString()) }, "HighScore");
        }
    }

    public void YesAlive()
    {
        isAlive = true;
    }

    private bool IsScoreBiggerThanHighscore()
    {
        int[] tmp = SaveSystem.LoadFromLocation("HighScore");
        if (tmp == null)
        {
            SaveSystem.SaveAtLocation(new int[] {0}, "HighScore");
            return false;
        }
        else
        {
            return (tmp[0] < int.Parse(textUI.text.ToString()));
        }
    }
}
