using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class EnemyCooldown : MonoBehaviour
{
    [SerializeField] private EnemyAttacks enemyAttacks;
    private const float COOLTIMELV1 = 6.0f;
    private const float COOLTIMELV2 = 5.0f;
    private const float COOLTIMELV3 = 4.0f;
    private const float COOLTIMELV4 = 2.0f;
    private const float COOLTIMELV5 = 1.5f;
    private int maxMeteor;
    private int minMetero;
    private int maxFire;
    private int minFire;
    private int maxValue;
    private float lastAttackTime;
    private Animator animator;
    [SerializeField] private float CoolTime;

    private void Start() 
    {
        animator = GetComponentInChildren<Animator>();
        lastAttackTime = -4;  
        CoolTime = COOLTIMELV1;
        maxMeteor = 25;
        minMetero = 20;
        maxFire = 8;
        minFire = 5;
        maxValue = 101;
    }

    private void Update()
    {
        if(Time.time - lastAttackTime >= CoolTime && !GameManager.Instance.IsDead)
        {
            animator.Play("attack_01_horse");
            lastAttackTime = Time.time;
            Invoke(nameof(AttackTiming), 1.3f);
        }
    }

    private void AttackTiming()
    {
        int rand = UnityEngine.Random.Range(1,maxValue);
        int value = 0;

        if(rand >= 1 && rand <= 55)
        {
            value = UnityEngine.Random.Range(minFire, maxFire);
            enemyAttacks.Attack_FireBall(value);
        }
        if(rand >= 47 && rand <= 80)
        {
            value = UnityEngine.Random.Range(minMetero, maxMeteor);
            enemyAttacks.Attack_Meteo(value);
        }
        if(rand >= 71)
        {
            enemyAttacks.Attack_IcePillar();
        }
    }

    public void CheckEnemyLv(int level)
    {
        switch (level)
        {
            case 1:
                CoolTime = COOLTIMELV1;
                break;
            case 2:
                CoolTime = COOLTIMELV2;
                minMetero = 25;
                maxMeteor = 35;
                break;
            case 3:
                CoolTime = COOLTIMELV3;
                minMetero = 30;
                maxMeteor = 37;
                minFire = 6;
                maxFire = 9;
                break;
            case 4:
                CoolTime = COOLTIMELV4;
                minMetero = 30;
                maxMeteor = 40;
                minFire = 8;
                maxFire = 11;
                break;
            case 5:
                CoolTime = COOLTIMELV5;
                minMetero = 44;
                maxMeteor = 49;
                minFire = 15;
                maxFire = 20;

                // ice なし
                //maxValue = 70;
                break;
            default:
                break;
        }
    }
}
