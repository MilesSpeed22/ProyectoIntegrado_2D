using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameManager Instance;

    public int maxPlayerHealth;
    public int playerHealth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            playerHealth = maxPlayerHealth;
        }
        else Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDamage(int damage)
    {
        playerHealth -= damage;
        playerHealth = Mathf.Clamp(playerHealth, 0, maxPlayerHealth);

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
