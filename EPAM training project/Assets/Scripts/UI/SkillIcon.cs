using UnityEngine;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour
{
    [SerializeField] private Image image;
    private float _coolDown;

    private void Update()
    {
        if(image.fillAmount > 0)
        {
            image.fillAmount -= Time.deltaTime / _coolDown;
        }
    }

    public void Reload(float coolDown)
    {
        this._coolDown = coolDown;
        image.fillAmount = 1;
    }
}
