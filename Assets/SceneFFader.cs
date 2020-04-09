using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFFader : MonoBehaviour
{
    public Image img;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime * 1f;
            img.color = new Color(0f, 0f, 0f, t);
            yield return 0;
        }
    }
}
