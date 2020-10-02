using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemySpawner : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The different types of enemies that should be spawned and their corresponding spawn information.")]
    private EnemySpawnInfo[] m_EnemyTypes;
    #endregion

    #region Non-Editor Variables
    private float[] m_EnemySpawnTimers;
    private Vector3 m_Bounds;
    #endregion

    #region First Time Initialization and Set Up
    private void Awake()
    {
        // Initialize the spawn timers using the FirstSpawnTime variable
        m_EnemySpawnTimers = new float[m_EnemyTypes.Length];
        m_Bounds = new Vector3(6f, 4f, 0f);
        for (int i = 0; i < m_EnemyTypes.Length; i++)
        {
            Debug.Log(m_EnemyTypes[i]);
            m_EnemySpawnTimers[i] = m_EnemyTypes[i].FirstSpawnTime;
        }
    }
    #endregion

    #region Main Updates
    private void Update()
    {
        for (int i = 0; i < m_EnemyTypes.Length; i++)
        {
            if (m_EnemySpawnTimers[i] <= 0)
            {
                Vector3 spawnPos = transform.position;
                if (Random.value < .8)
                    Instantiate(m_EnemyTypes[i].EnemyPrefab, spawnPos, new Quaternion(0,0,0,1));
                m_EnemySpawnTimers[i] = 1.0f / m_EnemyTypes[i].SpawnRate;
            }
            m_EnemySpawnTimers[i] -= Time.deltaTime;
        }
    }
    #endregion
}

[System.Serializable]
public struct EnemySpawnInfo
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("The enemy prefab to spawn. This is what will be instantiated each time.")]
    private GameObject m_EnemyPrefab;

    [SerializeField]
    [Tooltip("The time we should wait before the first enemy is spawned.")]
    private float m_FirstSpawnTime;

    [SerializeField]
    [Range(0, 100)]
    [Tooltip("How many enemies should spawn per second.")]
    private float m_SpawnRate;
    #endregion

    #region Accessors and Mutators
    public GameObject EnemyPrefab
    {
        get { return m_EnemyPrefab; }
    }

    public float FirstSpawnTime
    {
        get { return m_FirstSpawnTime; }
    }

    // Doing (1 / SpawnRate) might be more useful than directly using SpawnRate
    public float SpawnRate
    {
        get { return m_SpawnRate; }
    }
    #endregion
}
