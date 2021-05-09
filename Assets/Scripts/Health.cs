using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private Level level;
    private Sprite health;
    private List<Sprite> healthSprites;
    public int lives;
    private Vector3 levelOnePos;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        levelOnePos = transform.position;
        int healthCount = FindObjectsOfType<Health>().Length;
        if (healthCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        healthSprites = new List<Sprite>(Resources.LoadAll<Sprite>("Health"));
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            transform.position = new Vector3(-0.5f, 9.3f, transform.rotation.z);
        }
        else
        {
            transform.position = levelOnePos;
        }

        if (SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "Lose" || SceneManager.GetActiveScene().name == "Menu")
        {
           ResetHealth(); 
        }
        else
        {
            UpdateHealth();
        }
    }

    void UpdateHealth()
    {
        switch (lives)
        {
            case 1:
                health = healthSprites.Single(sprite => sprite.name == "LowHealth");
                gameObject.GetComponent<SpriteRenderer>().sprite = health;
                break;

            case 2:
                health = healthSprites.Single(sprite => sprite.name == "MidHealth");
                gameObject.GetComponent<SpriteRenderer>().sprite = health;
                break;

            case 3:
                health = healthSprites.Single(sprite => sprite.name == "FullHealth");
                gameObject.GetComponent<SpriteRenderer>().sprite = health;
                break;
        }
    }

    public void ResetHealth()
    {
        Destroy(gameObject);
    }
}
