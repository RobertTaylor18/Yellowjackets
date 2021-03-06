using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    private Health healthScript;
    public List<int> burnTickTimers = new List<int>();
    public List<int> bleedTickTimers = new List<int>();
    public List<int> slowTickTimers = new List<int>();

    public RandomFlyer randomFlyer;
    public float idleSpeed;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponent<Health>();
        if (gameObject.GetComponent<RandomFlyer>() != null)
        {
            randomFlyer = gameObject.GetComponent<RandomFlyer>();
        }
        idleSpeed = randomFlyer.idleSpeed;
        turnSpeed = randomFlyer.turnSpeed;
    }

    public void ApplyBurn(int ticks)
    {
        if(burnTickTimers.Count <= 0)
        {
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnTickTimers.Add(ticks);
        }
    }
    
    public void ApplyBleed(int ticks)
    {
        if (bleedTickTimers.Count <= 0)
        {
            bleedTickTimers.Add(ticks);
            StartCoroutine(Bleed());
        }
        else
        {
            bleedTickTimers.Add(ticks);
        }
    }
    public void ApplySlow(int ticks)
    {
        if (slowTickTimers.Count <= 0)
        {
            slowTickTimers.Add(ticks);
            StartCoroutine(Slow());
        }
        else
        {
            slowTickTimers.Add(ticks);
        }
    }

    IEnumerator Burn()
    {
        while (burnTickTimers.Count > 0)
        {
            for(int i = 0; i < burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }
            healthScript.OnDamage(5);
            burnTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    } 
    
    IEnumerator Bleed()
    {
        while (bleedTickTimers.Count > 0)
        {
            for(int i = 0; i < bleedTickTimers.Count; i++)
            {
                bleedTickTimers[i]--;
            }
            if (bleedTickTimers.Count > 10)
            {
                healthScript.OnDamage(30);
            }
            else if (bleedTickTimers.Count > 3)
            {
                healthScript.OnDamage(10);
            }
            else 
            { 
                healthScript.OnDamage(3);
            }
            bleedTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }

    IEnumerator Slow()
    {
        while (slowTickTimers.Count > 0)
        {
            for (int i = 0; i < slowTickTimers.Count; i++)
            {
                slowTickTimers[i]--;
            }

            //do some slow things
            if (gameObject.GetComponent<RandomFlyer>() != null)
            {
                randomFlyer.idleSpeed = randomFlyer.idleSpeed / 2;
                randomFlyer.turnSpeed = randomFlyer.turnSpeed / 2;
            }


            slowTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(1.5f);
        }


        /*infinite loop breaks game
         while (slowTickTimers.Count == 0)
        {
            if (gameObject.GetComponent<RandomFlyer>() != null)
            {
                randomFlyer.idleSpeed = idleSpeed;
                randomFlyer.turnSpeed = turnSpeed;
            }
        }*/
    }
}
