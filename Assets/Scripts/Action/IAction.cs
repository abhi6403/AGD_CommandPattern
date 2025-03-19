using Command.Input;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    /// <summary>
    /// An interface indicating a unit action.
    /// </summary>
    public interface IAction
    {
        public TargetType TargetType { get; }

        public void PerformAction(UnitController actorUnit, UnitController targetUnit,bool isSuccessfull);

        public Vector3 CalculateMovePosition(UnitController targetUnit);
    } 
}