using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int points = 0;
    public List<Transform> spawnPoints;
    public GameObject playerSpawn;

    public GameObject Arena;
    public GameObject Player;
    public GameObject TemplateObjective;
    public GameObject SpawnParent;
    public GameObject Score;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        SpawnObjective();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsPlayerOutOfBounds()
    {
        return (
            Player.transform.position.y > Arena.transform.position.y + 25 || 
            Player.transform.position.y < Arena.transform.position.y - 25 ||
            Player.transform.position.x > Arena.transform.position.x + 25 ||
            Player.transform.position.x < Arena.transform.position.x - 25
            );
    }

    void FixedUpdate()
    {
        if (IsPlayerOutOfBounds())
        {
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Player.transform.SetPositionAndRotation(playerSpawn.transform.position, Quaternion.identity);
        }
    }

    public void ObtainPoints(int x)
    {
        points = points + x;
        UpdateScore();
        Debug.Log("Current points: " + points.ToString());
    }

    void SpawnObjective()
    {
        foreach(var spawnPoint in spawnPoints)
        {
            GameObject objective = Instantiate(TemplateObjective);
            objective.transform.position = spawnPoint.position;
            objective.GetComponent<Objective>().point = Random.Range(1, 1000);
            objective.GetComponent<Objective>().gm = this;
            objective.transform.parent = SpawnParent.transform;
        }
    }

    void UpdateScore()
    {
        Score.GetComponent<TextMesh>().text = "Points: " + points.ToString();
    }
}
