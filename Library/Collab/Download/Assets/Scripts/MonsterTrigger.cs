using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    private GameObject monster;
    private Transform spawnPoint;
    public GameObject particles;

    private void Start()
    {
        spawnPoint = GameObject.Find("monster_trigger_zone").transform;
        monster = GameObject.Find("Monster");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            monster.transform.position = spawnPoint.position;
            monster.transform.eulerAngles = spawnPoint.eulerAngles;
            particles.GetComponent<ParticleSystem>().Play();
        }
    }
}
