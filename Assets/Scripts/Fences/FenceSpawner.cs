using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSpawner : MonoBehaviour
{

    public List <Transform> firstFences= new List <Transform> ();
    public GameObject FencePrefab;

    public GameObject allFences;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFence();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFence() {

        for (int i = 0; i < 50; i++) {

            GameObject leftfence = Instantiate(FencePrefab, (firstFences[0].transform.position + Vector3.forward * (i + 1) * 2.5f), Quaternion.identity);
            leftfence.transform.SetParent(allFences.transform, false);

            GameObject rightfence = Instantiate(FencePrefab, (firstFences[1].transform.position + Vector3.forward * (i + 1) * 2.5f), Quaternion.identity);
            rightfence.transform.SetParent(allFences.transform, false);
        }
    }

    public void MoveFences(List<GameObject> Chapters, int i) {

        allFences.transform.SetParent(Chapters[i].transform, false);

    }
}
