using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeInTime;
    private Image fadePanel;
    private Color currentColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        fadePanel = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alpha = Mathf.Lerp(1.0f, 0, Time.timeSinceLevelLoad / fadeInTime);
            currentColor.a = alpha;
            fadePanel.color = currentColor;
            Debug.Log($"  alpha = {alpha}");
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
