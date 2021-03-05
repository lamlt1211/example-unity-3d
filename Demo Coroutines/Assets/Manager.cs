using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private float number;

    public Text numberText;
    public Button PlayButton;
    public Button ResetButton;

    public void StartNumber()
    {
        number = 10;
        PlayButton.gameObject.SetActive(true);
        StartCoroutine(RunNumber());
    }

    public void StopNumber()
    {
        PlayButton.gameObject.SetActive(true);
        StopAllCoroutines();
    }

    private IEnumerator RunNumber()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            number--;
            numberText.text = number.ToString();
            if (number == 0)
            {
                StopAllCoroutines();
            }
        }
    }
}
