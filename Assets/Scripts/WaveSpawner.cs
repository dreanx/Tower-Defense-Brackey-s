using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab; // Reference of the prefab of the enemy to spawn

    public Transform spawnPoint; // Reference to the point where the enemy spawns

    public float timeBetweenWaves = 5f; // Time between each wave
    private float countdown = 2f; // Countdown timer

    public TextMeshProUGUI waveCountdownText; // Reference to the UI text for displaying countdown

    private int waveIndex = 0; // Index to keep track of the current wave

    private void Update()
    {
        countdown -= Time.deltaTime; // Reduce the countdown by the time passed since the last frame
        waveCountdownText.text = Mathf.Floor(countdown + 1).ToString(); // Update the UI text to display the countdown without decimal places (rounded down)

        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave()); // If the countdown reaches zero, start spawning a wave
            countdown = timeBetweenWaves; // Reset the countdown to the time between waves
        }
    }

    private IEnumerator SpawnWave()
    {
        Debug.Log("Wave incoming!");
        waveIndex++; // Increment the wave index for the current wave

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy(); // Spawn an enemy
            yield return new WaitForSeconds(0.5f); // Wait for half a second before spawning the next enemy
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); // Instantiate an enemy at the spawn point
    }
}