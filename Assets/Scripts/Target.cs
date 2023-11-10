using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour {
    private Rigidbody targetRb;
    public float minSpeed = 14.0f;
    private float maxSpeed = 17.0f;
    private float maxTorque = 10.0f;
    private float rangeX = 4.0f;
    private float spawnPosY = 3.0f;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    private AudioSource audioClick;
    void Awake() {
        audioClick = GetComponent<AudioSource>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioClick.Stop();
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
    private void OnMouseDown() {
        StartCoroutine(PlayAudioAndDestroy());
    }
    
    private IEnumerator PlayAudioAndDestroy() {
        audioClick.Play();
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
        // Ждем некоторое время перед уничтожением объекта
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }

    void Update() {
        if(gameManager.score == gameManager.finalScore || gameManager.gameOverText.gameObject.activeSelf) {
            Destroy(gameObject);
        }
    }
}
