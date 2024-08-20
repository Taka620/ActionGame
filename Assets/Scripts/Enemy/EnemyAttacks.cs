using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject meteo;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private GameObject IcePillars;
    [SerializeField] private GameObject IcePillarsIndicator;
    [SerializeField] private Transform fireBallSpawnPos;

    private float[] meteoSpawnXTable;
    private float[] meteoSpawnZTable;

    private const float DEFAULT_HEIGHT = 0;

    private void InitializeTable()
    {
        meteoSpawnXTable = new float[7];
        meteoSpawnZTable = new float[7];

        int start = 9;
        for(int i = 0; i < 7; i++)
        {
            meteoSpawnXTable[i] = start;
            meteoSpawnZTable[i] = start;
            start -= 3;
        }


    }
    
    private void setPillar()
    {
        for(int i = 0; i < 8; i++)
        {
            IcePillars.transform.GetChild(i).gameObject.SetActive(true);
        }
        IcePillarsIndicator.SetActive(false);
    }

    private void Start()
    {
        IcePillarsIndicator.SetActive(false);
        for(int i = 0; i < 8; i++)
        {
            IcePillars.transform.GetChild(i).gameObject.SetActive(false);
        }
        InitializeTable();
    }

    public void Attack_Meteo(int value)
    {
        for(int i = 0; i < value; i++)
        {
            int x,z;
            x = UnityEngine.Random.Range(0, 7);
            z = UnityEngine.Random.Range(0, 7);
            
            Instantiate(meteo, new Vector3(meteoSpawnXTable[x], DEFAULT_HEIGHT, meteoSpawnZTable[z]), Quaternion.identity);
        }
    }
    
    public void Attack_FireBall(int value)
    {
        for(int i = 0; i < value; i++)
        {
            Instantiate(fireBall, fireBallSpawnPos.position, Quaternion.identity);
        }
    }

    public void Attack_IcePillar()
    {
        IcePillarsIndicator.SetActive(true);
        Invoke(nameof(setPillar), 0.6f);
    }

}
