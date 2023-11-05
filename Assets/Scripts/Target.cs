using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    private Rigidbody targetRb;
    private float minSpeed = 14.0f;
    private float maxSpeed = 17.0f;
    private float maxTorque = 10.0f;
    private float rangeX = 4.0f;
    private float spawnPosY = 3.0f;
    void Start() {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos() {
        return new Vector3(Random.Range(-rangeX, rangeX), -spawnPosY);
    }
    void Update() {
        
    }
}
