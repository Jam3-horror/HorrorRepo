using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSequence : MonoBehaviour
{
    bool is_black = true;
    public Image black_screen;

    Color black;
    Color clear;
    Color current_color;

    // Start is called before the first frame update
    void Start()
    {
        black = new Color(0, 0, 0, 1);
        clear = new Color(0, 0, 0, 1);
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3);

        StartCoroutine(FadeImage(true));
        
        yield return new WaitForSeconds(3);

        StartCoroutine(FadeImage(false));

        yield return new WaitForSeconds(3);

        StartCoroutine(FadeImage(true));
    }


    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                black_screen.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                black_screen.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }
}
