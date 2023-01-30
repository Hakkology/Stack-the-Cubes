using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // List of cubes
    ListofCubes _listofCubes;

    // Position of the last cube
    Vector3 _lastSpawnPosition;

    // Number of last cube index
    int _previousIndex;

    // difference between two cubes behind the player
    float _difference;

    // level of cubes
    int _cubes;

    // wave follow speed
    [SerializeField]
    float speed;

    // points earned per cube
    public int Points;

    // cubes to attach on script as levels increase
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    // Start is called before the first frame update
    void Start()
    {
        // Initial Instantiate level
        _cubes= 1;

        // Starting points
        Points = 0;

        // Access the List of cubes script
        _listofCubes = FindObjectOfType<ListofCubes>();

        // previous Index Call
        _previousIndex = _listofCubes.CubeTower.Count - 2;

        // difference between cubes
        _difference = _listofCubes.coinSpace;

        // starting cube state
        CubeState();
    }

    // Update is called once per frame
    void Update()
    {
        // update spawn positions
        if (_previousIndex>=0) {
            _lastSpawnPosition = _listofCubes.CubeTower[_previousIndex].transform.position;
        }

        // move cubes accordingly
        transform.position = Vector3.Lerp (transform.position, _lastSpawnPosition + new Vector3 (0, _difference, 0), speed*Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other) {

        // when passing through a curtain
        if (other.gameObject.tag == "Curtain+" && _cubes <= 3) {

            _cubes++;
            FindObjectOfType<AudioAssets>().PlaySound(SoundNames.CurtainSound);
            CubeState();
        }
        else if (other.gameObject.tag == "Curtain-" && _cubes >= 1) {

            _cubes--;
            FindObjectOfType<AudioAssets>().PlaySound(SoundNames.CurtainSound);
            CubeState();
        }

    }

    void CubeState() {

        // switch statement to change the cube gameobject
        switch(_cubes) {
            case 1:
                cube1.SetActive(true);
                cube2.SetActive(false);
                cube3.SetActive(false);
                Points = 5;
                break;
            case 2:
                cube1.SetActive(false);
                cube2.SetActive(true); 
                cube3.SetActive(false);
                Points = 10;
                break;
            case 3:
                cube1.SetActive(false);
                cube2.SetActive(false);
                cube3.SetActive(true);
                Points = 15;
                break;
            default: break;
        }
    }
}
