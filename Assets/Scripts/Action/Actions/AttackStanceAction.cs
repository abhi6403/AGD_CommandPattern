using Command.Commands;
using Command.Player;
using Command.Input;
using Command.Main;
using UnityEngine;

namespace Command.Actions
{
    public class AttackStanceAction : IAction
    {
        private UnitController actorUnit;
        private UnitController targetUnit;
        private bool isSuccessfull;
        TargetType IAction.TargetType { get => TargetType.Self; }

        public void PerformAction(UnitController actorUnit, UnitController targetUnit,bool isSuccessfull)
        {
            this.actorUnit = actorUnit;
            this.targetUnit = targetUnit;
            this.isSuccessfull = isSuccessfull;

            actorUnit.PlayBattleAnimation(CommandType.AttackStance, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted()
        {
            GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.ATTACK_STANCE);

            if (isSuccessfull)
                targetUnit.CurrentPower += (int)(targetUnit.CurrentPower * 0.2f);
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();
    }
}