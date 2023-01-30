using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListofCubes : MonoBehaviour
{
    // Collected Coins
    public GameObject Coin;

    // Coin Spawn Locations
    public Transform SpawnPosition;

    // Space between coins
    [SerializeField]
    public float coinSpace;
    
    // List for stacking cubes
    public List<GameObject> CubeTower = new List<GameObject>();

    // Counter for cubes
    [SerializeField]
    public int numberofCubes=0;

    void Start()
    {
        // counting number of Cubes for Tower of cubes
        numberofCubes = CubeTower.Count;
    }

    public void IncrementCubes() {

        // Increase number of cubes for int
        numberofCubes++;

        // Instantiate new cubes as coins are picked up
        GameObject newCube = Instantiate(Coin, SpawnPosition.position + new Vector3(0, numberofCubes * coinSpace, 0), SpawnPosition.rotation);

        // Add newly added cube to the list of tower
        CubeTower.Add(newCube);

        // Add the new cube to Player tree so that it would follow the player
        newCube.transform.SetParent(gameObject.transform);

        // Giving cubes name
        newCube.name = (numberofCubes-1).ToString();
    }
}
