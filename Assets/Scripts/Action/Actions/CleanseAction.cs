using Command.Commands;
using Command.Input;
using Command.Player;
using Command.Main;
using UnityEngine;

namespace Command.Actions
{
    public class CleanseAction : IAction
    {
        private const float hitChance = 0.2f;
        private UnitController actorUnit;
        private UnitController targetUnit;
        private bool isSuccessfull;
        public TargetType TargetType  => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit,bool isSuccessfull)
        {
            this.actorUnit = actorUnit;
            this.targetUnit = targetUnit;
            this.isSuccessfull = isSuccessfull;

            actorUnit.PlayBattleAnimation(CommandType.Cleanse, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.CLEANSE);

            if (isSuccessfull)
                targetUnit.ResetStats();
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}
