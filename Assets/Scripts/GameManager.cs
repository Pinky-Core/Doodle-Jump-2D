using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public float platformSpacing = 1.5f;
    public int initialPlatformCount = 10;
    public float platformRangeX = 5f;
    public float destroyBelowY = -10f;
    public float enemyDestroyBelowY = -9f;

    public GameObject enemyPrefab;
    public float enemySpawnChance = 0.1f; // 10% de chance por plataforma

    private float highestY = 0f;
    private List<GameObject> platforms = new List<GameObject>();
    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        // Generar plataformas iniciales
        for (int i = 0; i < initialPlatformCount; i++)
        {
            float y = i * platformSpacing;
            CreatePlatformAtY(y);
        }

        highestY = initialPlatformCount * platformSpacing;
    }

    void Update()
    {
        // Si el jugador sube cerca del punto más alto, generamos más plataformas
        if (player.position.y + 10f > highestY)
        {
            for (int i = 0; i < 5; i++)
            {
                highestY += platformSpacing;
                CreatePlatformAtY(highestY);
            }
        }

        // Eliminar plataformas que estén muy abajo del jugador
        for (int i = platforms.Count - 1; i >= 0; i--)
        {
            if (platforms[i] != null && platforms[i].transform.position.y < player.position.y + destroyBelowY)
            {
                Destroy(platforms[i]);
                platforms.RemoveAt(i);
            }
        }

        // Eliminar enemigos que estén muy abajo del jugador
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] != null && enemies[i].transform.position.y < player.position.y + enemyDestroyBelowY)
            {
                Destroy(enemies[i]);
                enemies.RemoveAt(i);
            }
        }
    }

    void CreatePlatformAtY(float y)
    {
        float x = Random.Range(-platformRangeX, platformRangeX);
        Vector3 position = new Vector3(x, y, 0);
        GameObject platform = Instantiate(platformPrefab, position, Quaternion.identity);
        platforms.Add(platform);

        // Spawnear enemigo con probabilidad
        if (Random.value < enemySpawnChance)
        {
            Vector3 enemyPos = new Vector3(position.x, position.y + 0.5f, 0); // Un poco encima de la plataforma
            GameObject enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity);
            enemies.Add(enemy); // Añadir el enemigo a la lista
        }
    }
}
