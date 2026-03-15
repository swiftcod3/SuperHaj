using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInRaw : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<RawImage>().color = new Color(
            GetComponent<RawImage>().color.r,
            GetComponent<RawImage>().color.g,
            GetComponent<RawImage>().color.b, 0);
    }

    virtual public IEnumerator Action(float duration)
    {
        float counter = 0;

        RawImage image = GetComponent<RawImage>();
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
