using System;
using CaronixTest.Enums;
using CaronixTest.Save;
using CaronixTest.ScriptableObjects;
using Zenject;

namespace CaronixTest.Services
{
    public class ResultService
    {
        [Inject] private FightService _fightService;
        [Inject] private IntervalsConfig _intervalsConfig;
        [Inject] private SaveDataMediator _saveDataMediator;

        public event Action Started;
        public event Action Ended;

        public void StartWork()
        {
            Started?.Invoke();
        }
        
        public int GetReward()
        {
            var reward = _intervalsConfig.Get(ValueTypes.Money);
            _saveDataMediator.AddMoney(reward);

            return reward;
        }

        public void End()
        {
            Ended?.Invoke();
        }
    }
}