using Command.Commands;
using Command.Input;
using Command.Main;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public class AttackAction : IAction
    {
        private UnitController actorUnit;
        private UnitController targetUnit;
        private bool isSuccessfull;
        public TargetType TargetType => TargetType.Enemy;

        public void PerformAction(UnitController actorUnit, UnitController targetUnit,bool isSuccessfull)
        {
            this.actorUnit = actorUnit;
            this.targetUnit = targetUnit;
            this.isSuccessfull = isSuccessfull;
            
            actorUnit.PlayBattleAnimation(CommandType.Attack, CalculateMovePosition(targetUnit), OnActionAnimationCompleted);
        }

        public void OnActionAnimationCompleted() 
        {
            PlayAttackSound();

            if (isSuccessfull)
                targetUnit.TakeDamage(actorUnit.CurrentPower);
            else
                GameService.Instance.UIService.ActionMissed();
        }

        public Vector3 CalculateMovePosition(UnitController targetUnit) => targetUnit.GetEnemyPosition();

        private void PlayAttackSound()
        {
            switch(actorUnit.UnitType)
            {
                case UnitType.WIZARD:
                    GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.MAGIC_BALL);
                    break;
                case UnitType.SWORD_MASTER:
                    GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.KNIFE_SLASH);
                    break;
                case UnitType.MAGE:
                    GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.FIRE_ATTACK);
                    break;
                case UnitType.BERSERKER:
                    GameService.Instance.SoundService.PlaySoundEffects(Sound.SoundType.SWORD_SLASH);
                    break;
                default:
                    break;
            }
        }
    }
}