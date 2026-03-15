using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInButton: FadeInRaw
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Button>().enabled = false;
        GetComponent<Image>().color = new Color(
            GetComponent<Image>().color.r,
            GetComponent<Image>().color.g,
            GetComponent<Image>().color.b, 0);
    }

    public override IEnumerator Action(float duration)
    {
        float counter = 0;

        Image image = GetComponent<Image>();
        Color startColor = image.color;
        while (counter < duration)
        {
            counter += 0.016f;
            float alpha = Mathf.Lerp(0, 1, counter / duration);

            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            yield return null;
        }
        GetComponent<Button>().enabled = true;
        image.color = new Color(startColor.r, startColor.g, startColor.b, 1);
    }
}
