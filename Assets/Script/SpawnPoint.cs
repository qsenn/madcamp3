using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject player;
    public GameObject EnterPanel;
    private Vector3 respawnLocation;

    public InputField inputField;

    void Awake() {
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
    void Start() {
        
    }

    void Update() {

    }

    public void SpawnPlayer() {
        EnterPanel.SetActive(false);

        player = (GameObject) Resources.Load("character", typeof(GameObject));

        respawnLocation = player.transform.position;

        int spawn = Random.Range(0, spawnLocations.Length);
        GameObject.Instantiate(player, spawnLocations[spawn].transform.position, Quaternion.identity);
    }

    public void SetUsername()
    {
        // InputField inputField = inputFieldObject.GetComponent<InputField>();
         // string value = inputField.text;
        // Debug.Log(inputField.text);
        string value = inputField.text;
        player.GetComponentInChildren<TextMesh>().text = value;
        // Debug.Log(player.GetComponentInChildren<TextMesh>().text);
    }
}
