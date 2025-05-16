using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public GameObject Hati;
    public float batasX, batasY;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnHati());
    }

    IEnumerator SpawnHati()
    {
        yield return new WaitForSeconds(10);

        Instantiate(Hati, new Vector2(Random.Range(-batasX, batasX), batasY), Quaternion.identity);

        StartCoroutine(SpawnHati());
    }
}
