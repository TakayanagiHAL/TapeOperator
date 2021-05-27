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
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSprite(bool is_use)
    {
        if (is_use)
        {
            image.sprite = sprite[0];
        }
        else
        {
            image.sprite = sprite[1];
        }
    }

    public void InitMark()
    {
        image = this.GetComponent<Image>();
    }
}
