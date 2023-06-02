using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText; // Reference to the UI timer

    private int waveIndex = 0;

    private void Update()
    {
        countdown -= Time.deltaTime; // Reduce countdown by 1 every seconds
        waveCountdownText.text = Mathf.Floor(countdown + 1).ToString(); // Display the text without decimal rounded down

        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves; // If countdown reached 0, spawn the wave and make it equal to the time between waves
        }
    }

    private IEnumerator SpawnWave() // We use IEnumerator to create a subroutine (need to using System.Collections;)
    {
        Debug.Log("wave incoming");
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); // Subroutine to make the enemies spawn every half seconds instead of all at once
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}