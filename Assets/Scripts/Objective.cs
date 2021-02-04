using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public int point = 1;
    public GameManager gm;
    public float RotationalSpeed = 50.0f;
    public Vector3 DirectionalRotation = new Vector3(-1.5f, 0.5f, 0.3f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(DirectionalRotation * RotationalSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            this.gameObject.SetActive(false);
            gm.ObtainPoints(point);
        }
    }
}
