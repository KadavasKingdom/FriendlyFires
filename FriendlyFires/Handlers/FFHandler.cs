using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using PlayerRoles;
using PlayerStatsSystem;

namespace FriendlyFires.Handlers;

internal sealed class FFHandler : CustomEventsHandler
{
    public override void OnPlayerHurting(PlayerHurtingEventArgs ev)
    {
        if (ev.DamageHandler is not AttackerDamageHandler attackerDamageHandler)
            return;

        if (Main.Instance == null || Main.Instance.Config == null)
            return;
        RoleTypeId AttackerRole = attackerDamageHandler.Attacker.Role;
        RoleTypeId PlayerRole = ev.Player.Role;
        if (
                // Check if has AllFF
                Main.Instance.Config.AllDamageFriendlyFire 
            ||
            (
                // Check if we have dic check enabled, and inside the dictionary.
                Main.Instance.Config.EnableDictionaryCheck && 
                Main.Instance.Config.CanFriendlyFire.TryGetValue(AttackerRole, out var roleTypeIds) && 
                roleTypeIds.Contains(PlayerRole)
            )
            ||
                // Simple check
                Main.Instance.Config.FriendlyFireRoles.Contains(AttackerRole)
            )
        {
            attackerDamageHandler.ForceFullFriendlyFire = true;
            attackerDamageHandler.IsFriendlyFire = Main.Instance.Config.AsFriendlyFire;
        }
    }
}
