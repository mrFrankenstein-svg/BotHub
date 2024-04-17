using UnityEngine;
public interface IBotSlave
{
    void BotSubscribtorOnDelegate();
    void BotDescriptorOnDelegate();
    void BotBehaviorController(IBotMaster master, BotComands comand);
    void BotPrepperForWork();
}
public interface IBotMaster
{
    void SetComandToBots(IBotMaster BotMaster, BotComands comand);
}
public abstract class BotPrepperForWork : MonoBehaviour
{
    public abstract void PrepperForWork(IBotSlave needsToBePrepared);
}
public abstract class BotComandFollow : MonoBehaviour
{
    public abstract void FollowComand(IBotSlave waitingForCommand);
}
public abstract class BotComandInteract : MonoBehaviour
{
    public abstract void InteractComand(IBotSlave waitingForCommand);
}
public abstract class BotComandAction : MonoBehaviour
{
    public abstract void ActionComand(IBotSlave waitingForCommand);
}
public enum BotComands
{
    Follow,
    Interact,
    Action
}
namespace Bots
{
    public static class BotHub 
    {
        public delegate void BotBehaviorDelegate(IBotMaster master, BotComands comand);
        public static BotBehaviorDelegate behavior;
    }  
}