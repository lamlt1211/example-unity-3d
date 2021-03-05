using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System.Threading;
using Unity.Collections;

public class Manager : MonoBehaviour
{

    private float number;

    public Text numberText;
    public Button PlayButton;

    public async void StartNumber()
    {
        number = 10;
        PlayButton.gameObject.SetActive(true);

    }

    public async void Run()
    {
        while (true)
        {
            number--; // giảm đi một đơn vị
            await Task.Delay(1000); // delay 1s sau một giây sẽ giảm đi một
            numberText.text = number.ToString(); // sau khi trừ đi một sẽ hiển thị ra
            if (number==0)
            {
                break;
            }

        }
    }
}
