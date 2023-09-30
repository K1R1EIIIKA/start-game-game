using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hp : MonoBehaviour
{
    [SerializeField] private Image UIHP;
    [SerializeField] private float hpbar;
    [SerializeField] private float delta = 0.005f;
    private static bool timeIsUp = true;
    void Start()
    {
        StartCoroutine(ITimer());
    }

    // Update is called once per frame
    void Update()
    {
        UIHP.fillAmount = hpbar;
    }
    IEnumerator ITimer()
    {
        while (timeIsUp)
        {

            hpbar -= delta;
            yield return new WaitForSeconds(0.1f);
            if (hpbar == 0)
            {
                timeIsUp = false;
            }
        }
    }
}
