using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WetherMark : MonoBehaviour
{
    public Sprite[] sprite = new Sprite[2];
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprite(bool is_use)
    {
        if (is_use)
        {

        }
        else
        {
            image.sprite = sprite[1];
        }
    }
}
