using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float timerTime;
    [SerializeField] private Text objectiveText;
    [SerializeField] private string text;

    private void OnEnable()
    {
        StartCoroutine(StartTimer(timerTime));
    }

    private IEnumerator StartTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Effect();
    }

    private void Effect()
    {
        GameLoop.Instance.objective = true;
        objectiveText.text = text;
    }
}
