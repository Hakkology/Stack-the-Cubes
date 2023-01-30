using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectibleScript : MonoBehaviour
{
    // rotation speed for the coin
    [SerializeField]
    float _rotationSpeed= 90;

    void Update()
    {
        // coin rotates around itself
        transform.Rotate(0, _rotationSpeed * Time.deltaTime , 0);
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {

            // Call Increment Cube function from List of Cubes
            FindObjectOfType<ListofCubes>().IncrementCubes();

            // Call Camera Movement function
            Camera.main.GetComponent<CameraPositioning>().moveCamera();

            // Play Sound
            FindObjectOfType<AudioAssets>().PlaySound(SoundNames.CoinCollect);

            // Add the coin to the pool
            FindObjectOfType<Manager>().CoinPool.Add(gameObject);

            // destroy coin
            gameObject.SetActive(false);

        }
    }
}
