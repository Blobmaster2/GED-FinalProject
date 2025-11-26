using UnityEngine;

public class Powerup : MonoBehaviour, ICommand
{
    public PowerupType type;
    public bool isInstant { get; private set; } = false;

    public void Execute()
    {
        switch (type)
        {
            case PowerupType.PlayerSpeed:

                Player.GetPlayer().speedMultiplier *= 2;

                break;

            case PowerupType.ShootingSpeed:

                Player.GetPlayer().TotalBulletCooldown /= 2;

                break;

            case PowerupType.XP:

                isInstant = true;

                break;

            case PowerupType.Heal:

                isInstant = true;

                break;
        }
    }

    public void Undo()
    {
        switch (type)
        {
            case PowerupType.PlayerSpeed:

                Player.GetPlayer().speedMultiplier /= 2;

                break;

            case PowerupType.ShootingSpeed:

                Player.GetPlayer().TotalBulletCooldown *= 2;

                break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerupController.Instance.ApplyPowerup(this);

        gameObject.SetActive(false);
    }
}
