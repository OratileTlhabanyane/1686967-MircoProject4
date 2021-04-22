using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpitBacteria : MonoBehaviour
{
    public Transform bacteriaSpitPos;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, bacteriaSpitPos.position, bacteriaSpitPos.rotation);
        }

    }
}
