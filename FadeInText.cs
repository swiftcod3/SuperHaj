using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInText : FadeInRaw
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TMP_Text>().color = new Color(
            GetComponent<TMP_Text>().color.r,
            GetComponent<TMP_Text>().color.g,
            GetComponent<TMP_Text>().color.b, 0);
    }

    public override IEnumerator Action(float duration)
    {
        float counter = 0;

        TMP_Text image = GetComponent<TMP_Text>();
        Color startColor = image.color;
        while (counter < duration)
        {
            counter += 0.016f;
            float alpha = Mathf.Lerp(0, 1, counter / duration);

            image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);

            yield return null;
        }
        image.color = new Color(startColor.r, startColor.g, startColor.b, 1);
    }
}
