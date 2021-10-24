using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour
{
    private float coolDown;
    [SerializeField] private Image image;

    private void Update()
    {
        if(image.fillAmount > 0)
        {
            image.fillAmount -= Time.deltaTime / coolDown;
        }
    }

    public void Reload(float coolDown)
    {
        this.coolDown = coolDown;
        image.fillAmount = 1;
    }
}
