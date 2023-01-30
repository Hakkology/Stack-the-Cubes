using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    // reference to other scripts
    ListofCubes _listofCubes;
    PlayerMovement _playerMovement;

    // count for the cubes
    int _count;

    // Has the game ended ?
    bool _endofGame;

    // Time required for each cubes to be destroyed at the end
    float _timetoDestroy;

    // Chapter State Variable
    int _chapterState;

    void Start()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _listofCubes = FindObjectOfType<ListofCubes>();

        // initially, game is not over
        _endofGame = false;

        // time interval between cubes dying
        _timetoDestroy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_endofGame && _count > 0 && _timetoDestroy < Time.time) {

            // Destroy the list, but based on _timetoDestroy
            Destroy(_listofCubes.CubeTower[_count].gameObject);

            // Increment Points based on cube colour
            FindObjectOfType<Manager>().Points += _listofCubes.CubeTower[_count].gameObject.GetComponent<CoinScript>().Points;

            // _timetoDestroy set as 0.5f
            _timetoDestroy = Time.time + 0.5f;

            // Each time a cube is destroyed, count is decremented
            _count--;
        }
        else if (_endofGame && _count == 0) {

            // Get to Next Chapter
            FindObjectOfType<Manager>().ChapterState++;

            // Access GameState function
            FindObjectOfType<Manager>().GameState();

            // Enable Panel Controls
            FindObjectOfType<Manager>().UIPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {

            // Play Audio
            FindObjectOfType<AudioAssets>().PlaySound(SoundNames.EndofChapter);

            // end the game, stop the movement.
            _playerMovement.GameState = false;

            // count is reset back to beginning.
            _count = _listofCubes.CubeTower.Count - 1;

            // end of game.
            _endofGame= true;


        }
    }
}
