using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time = -1f;
    public float timeMax;

    private RectTransform rectTransform;
    public RectTransform timerBarTransform;
    public TMP_Text textSecondsRemaining;
    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        SetTimer(180f);
    }

    void SetTimer(float timeLimit)
    {
        timeMax = timeLimit;
        time = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;

            timerBarTransform.localScale = new Vector2(time / timeMax, 1f);
            textSecondsRemaining.text = Mathf.RoundToInt(time).ToString();
        }
        else if (time < 0)
        {
            time = 0;

            timerBarTransform.localScale = new Vector2(0f, 1f);
            textSecondsRemaining.text = "//";
        }
    }


}
