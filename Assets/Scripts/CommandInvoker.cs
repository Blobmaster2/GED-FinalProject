using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private readonly Queue<ICommand> commandQueue = new Queue<ICommand>();
    
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        commandQueue.Enqueue(command);
    }

    public void ClearCommandQueue()
    {
        commandQueue.Clear();
    }
}