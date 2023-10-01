using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberSpawner : MonoBehaviour
{
    public GameObject number;
    public Transform parent;
    public GameObject canvas;

     private List<GameObject> numberList = new List<GameObject>();
   
    public float minx, maxx, miny, maxy;

    [SerializeField] private TextMeshProUGUI Score;
    private TextMeshProUGUI textNumber;
    public GameObject PanelLose;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(ITimer());
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = GlobalThings.countNumbers.ToString() + "/100";
        if (GlobalThings.countNumbers > 100)
        {
            canvas.SetActive(false);
        }
    }
    private void SpawnNumber()
    {

        minx = -880;
        maxx = 848;
        miny = -40;
        maxy = 446;
        var wantedx = Random.Range(minx, maxx);
        var wantedy = Random.Range(miny, maxy);
        var position = new Vector3(wantedx + 960, wantedy + 540);
        GameObject go = Instantiate(number, position, transform.rotation, parent);
        numberList.Add(go);

    }
    public void DeleteNumber()
    {
        for (int i=0;i< numberList.Count; i++)
        {
            Destroy(numberList[i]);
        }

        Time.timeScale = 1;
        PanelLose.SetActive(false);
        GlobalThings.ipGameisOn = true;
    }
    IEnumerator ITimer()
    {
        while (GlobalThings.ipGameisOn)
        {
            SpawnNumber();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
