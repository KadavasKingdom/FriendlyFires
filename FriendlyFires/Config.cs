using PlayerRoles;
using System.ComponentModel;

namespace FriendlyFires;

public sealed class Config
{
    [Description("Enabling all damage should do friendly fire")]
    public bool AllDamageFriendlyFire { get; set; }

    [Description("Enable Friendly fire for this roles")]
    public List<RoleTypeId> FriendlyFireRoles { get; set; } = [];

    [Description($"Enable check for {nameof(CanFriendlyFire)}.")]
    public bool EnableDictionaryCheck { get; set; }

    [Description("KeyValues to enable FF for certain roles to can hurt a list of roles.")]
    public Dictionary<RoleTypeId, List<RoleTypeId>> CanFriendlyFire { get; set; } = new()
    {
        {
            RoleTypeId.ClassD,
            [
                RoleTypeId.ClassD,
                RoleTypeId.ChaosRepressor
            ]
        }
    };

    [Description("Damage should state it is a FF. (127 does not get XP, Death screen look 'teamkilled' instead of 'killed')")]
    public bool AsFriendlyFire { get; set; }
}
