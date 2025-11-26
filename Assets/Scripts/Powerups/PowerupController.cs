using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{
    [SerializeField] private GameObject powerupPrefab;

    [SerializeField] private float powerupTickRate = 10;
    [SerializeField] private float powerupSpawnChance = 30;

    [SerializeField] private float powerupTime = 30;

    [SerializeField] private float minSpawnLocation = -48;
    [SerializeField] private float maxSpawnLocation = 48;

    private List<GameObject> powerupPool = new List<GameObject>();
    private int maxPowerupCount = 10;

    private class TimedCommand
    {
        public ICommand Command;
        public float EndTime;
    }

    private List<TimedCommand> activeCommands = new List<TimedCommand>();

    private float tickTimer = 0;

    public static PowerupController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;

        if (tickTimer >= powerupTickRate)
        {
            tickTimer = 0;

            RollForPowerup();
        }

        for (int i = activeCommands.Count - 1; i >= 0; i--)
        {
            if (Time.time >= activeCommands[i].EndTime)
            {
                activeCommands[i].Command.Undo();
                activeCommands.RemoveAt(i);
            }
        }
    }

    private void RollForPowerup()
    {
        if (Random.Range(0, 100) < powerupSpawnChance)
        {
            var powerup = CreatePowerup();

            if (GameManager.DoPooling)
            {
                powerupPool.Add(powerup);

                if (powerupPool.Count > maxPowerupCount)
                {
                    Destroy(powerupPool[0]);
                    powerupPool.RemoveAt(0);
                }
            }
        }
    }

    private GameObject CreatePowerup()
    {
        var x = Random.Range(minSpawnLocation, maxSpawnLocation);
        var y = Random.Range(minSpawnLocation, maxSpawnLocation);

        var powerup = Instantiate(powerupPrefab, new Vector3(x, y), Quaternion.identity);

        switch (Random.Range(0, 4))
        {
            case 0:

                powerup.GetComponent<Powerup>().type = PowerupType.PlayerSpeed;
                powerup.GetComponent<SpriteRenderer>().color = Color.cyan;

                break;

            case 1:

                powerup.GetComponent<Powerup>().type = PowerupType.ShootingSpeed;
                powerup.GetComponent<SpriteRenderer>().color = Color.green;

                break;

            case 2:

                powerup.GetComponent<Powerup>().type = PowerupType.XP;
                powerup.GetComponent<SpriteRenderer>().color = Color.blue;

                break;

            case 3:

                powerup.GetComponent<Powerup>().type = PowerupType.Heal;
                powerup.GetComponent<SpriteRenderer>().color = Color.red;

                break;
        }

        return powerup;
    }

    public void ApplyPowerup(Powerup powerup)
    {
        powerup.Execute();

        if (powerup.isInstant)
        {
            Destroy(powerup.gameObject);
            return;
        }

        //remove from pool so it isn't deleted before undoing command.
        powerupPool.Remove(powerup.gameObject); 

        activeCommands.Add(new TimedCommand
        {
            Command = powerup,
            EndTime = Time.time + powerupTime
        });
    }
}

public enum PowerupType
{
    PlayerSpeed,
    ShootingSpeed,
    XP,
    Heal,
}
