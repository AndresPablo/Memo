using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void GameTickAction(float time);
    public delegate void EmptyVoidAction();
    public static event GameTickAction OnTick;
    public static event EmptyVoidAction OnTimeOver;

    [SerializeField]float maxTime;
    float time;

    public void Start()
    {
        time = maxTime;
        StartCoroutine(Countdown());
    }

    public void Stop()
    {
        StopCoroutine(Countdown());
    }

    public void AddTime()
    {
        time++;

        if (OnTick != null)
        {
            OnTick(time);
        }
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);

        time--;

        if(OnTick != null)
        {
            OnTick(time);
        }

        if(time < 0)
        {
            if (OnTimeOver != null)
            {
                OnTimeOver();
            }
        }else
            StartCoroutine(Countdown());
    }


}
