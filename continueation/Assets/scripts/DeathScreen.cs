using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    private Image[] imgs;
    private TextMeshProUGUI[] texts;
    [SerializeField] TextMeshProUGUI highScoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        imgs = GetComponentsInChildren<Image>();
        texts = GetComponentsInChildren<TextMeshProUGUI>();
    }


    public void FadeIn()
    {
        GetComponent<Canvas>().enabled = true;
        StartCoroutine("fadeIn");
        highScoreText.SetText("HighScore: " + GetHighScore());
    }

    public void FadeOut()
    {
        StartCoroutine("fadeOut");
    }

    IEnumerator fadeIn()
    {
        SetVisibility(imgs[0].color.a + 0.025f);
        yield return new WaitForSeconds(0.025f);

        if (imgs[0].color.a < 0.5f)
        {
            StartCoroutine("fadeIn");
        }

    }

    IEnumerator fadeOut()
    {
        SetVisibility(imgs[0].color.a - 0.025f);
        yield return new WaitForSeconds(0.0125f);

        if (imgs[0].color.a > 0)
        {
            StartCoroutine("fadeOut");
        }
        else
        {
            GetComponent<Canvas>().enabled = false;
        }
    }

    public void SetVisibility(float num)
    {
        foreach (Image img in imgs)
        {
            img.color = new Color(img.color.r, img.color.g, img.color.b, num);
        }

        foreach (TextMeshProUGUI text in texts)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, num);
        }
    }

    private string GetHighScore()
    {
        int[] tmp = SaveSystem.LoadFromLocation("HighScore");
        if (tmp == null)
        {
            return "0";
        }

        return ( tmp[0].ToString());
    }

}
