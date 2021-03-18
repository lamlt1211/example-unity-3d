using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public Button PlayButton;
    public SpriteRenderer spriteRenderer;

   
    public void Start()
    {
        PlayButton.gameObject.SetActive(true);
    }

    public void StartDino()
    {
        spriteRenderer.sprite = Resources.Load<Sprite>("test/Dino");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
