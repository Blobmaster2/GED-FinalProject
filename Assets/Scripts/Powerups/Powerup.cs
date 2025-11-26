using UnityEngine;

public class Powerup : MonoBehaviour, ICommand
{
    public PowerupType type;

    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
