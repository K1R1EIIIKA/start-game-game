using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskAppear : MonoBehaviour
{
    public GameObject[] tileprefabs;
    public int numberOfTiles = 2;

    //public GameObject canvas;

    private static bool GameIsOn = true;

    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
    }
    void Update()
    {
        while (GameIsOn)
        {
            SpawnTile(Random.Range(0, tileprefabs.Length));
            StartCoroutine(ITimer());
        }
    }
    public void SpawnTile(int tileIndex)
    {
        if (activeTiles[0] == null) 
        {
       // GameObject go = Instantiate(tileprefabs[tileIndex], Vector3(-800, 365, 0), transform.rotation) ;
           // go.parent = canvas;
          //  activeTiles.Add(go);
        }
        else if (activeTiles[1] == null)
        {
          //  GameObject go = Instantiate(tileprefabs[tileIndex], Vector3(-486, 362, 0), transform.rotation);
           // activeTiles.Add(go);
        }


    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    IEnumerator ITimer()
    {
            yield return new WaitForSeconds(15f);
    }
}
