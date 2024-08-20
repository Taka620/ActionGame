using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public const float PLAYERORIGINALHP = 7;
    public float HP {get; private set;} = PLAYERORIGINALHP;
    public float OHP {get; private set;} = PLAYERORIGINALHP;
    [SerializeField] private GameObject damageScreen;
    private float lastTime;
    private float flashTime; 
    private bool isTakeDamage;


    [SerializeField] private PopUpMessage damagePop;

    private void Start() 
    {
        lastTime = 0;
        flashTime = 0.15f;    
        isTakeDamage = false;
        damageScreen.SetActive(false);
    }

    public void TakeDamage(float demage)
    {
        HP -= demage;
        damagePop.DmgPopUp();
        GameManager.Instance.UpdatePlayerHP();
        if(HP <= 0)
        {
            GameManager.Instance.GameOver();
        }

        damageScreen.SetActive(true);
        lastTime = Time.time;
        isTakeDamage = true;
    }

    private void Update() 
    {
        if(Time.time - lastTime >= flashTime && isTakeDamage)    
        {
            damageScreen.SetActive(false);
            isTakeDamage = false;
            lastTime = Time.time;
        }
    }
}
