using UnityEngine;

namespace Bots
{
    public class Bot_Slave : MonoBehaviour, IBotSlave
    {
        //«десь показываетс€ на кого сейчас ориентируетс€ в поведении этот бот.
        //
        //It shows who this bot is currently targeting in behavior.")]

        [SerializeField] IBotMaster myMaster;

        [Space]
        [Tooltip("—крипт, в который нужно будет написать всЄ, что должно быть подготовлено дл€ работы бота." +
            "\n" +
            "A script in which you will need to write everything that needs to be prepared for the bot to work.")]

        [SerializeField] private BotPrepperForWork PrepperForWork;

        [Space]
        [Tooltip("—юда поставл€ютс€ скрипты, а которых должно быть прописано поведение определЄнного типа, которое ожидаетс€ от бота." +
            "\n" +
            "Scripts are supplied here, and which should specify the behavior of a certain type that is expected from the bot.")]

        [SerializeField] private BotComandFollow FollowComandScript;
        [SerializeField] private BotComandInteract InteractComandScript;
        [SerializeField] private BotComandAction ActionComandScript;

        private void Start()
        {
            BotPrepperForWork();
        }
        public void BotPrepperForWork()
        {
            PrepperForWork.PrepperForWork(this);
        }
        public void BotBehaviorController(IBotMaster master, BotComands comand)
        {
            if (master == myMaster)
            {
                switch (comand)
                {
                    case BotComands.Follow:
                        FollowComandScript.FollowComand(this);
                        break;
                    case BotComands.Interact:
                        InteractComandScript.InteractComand(this);
                        break;
                    case BotComands.Action:
                        ActionComandScript.ActionComand(this);
                        break;
                    default:
                        Debug.LogError(this + " the bot cannot execute or execute the command " + comand);
                        break;
                }
            }
        }

        public void BotDescriptorOnDelegate()
        {
            BotHub.behavior -= BotBehaviorController;
        }

        public void BotSubscribtorOnDelegate()
        {
            BotHub.behavior += BotBehaviorController;
        }
    }
}
