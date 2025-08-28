# Friendly Fires
Changing friendly fire based on classes.

### Example config
```yml
# Enabling all damage should do friendly fire
all_damage_friendly_fire: false
# Enable Friendly fire for this roles
friendly_fire_roles:
- Tutorial
# Enable check for CanFriendlyFire.
enable_dictionary_check: true
# KeyValues to enable FF for certain roles to can hurt a list of roles.
can_friendly_fire:
  ClassD:
  - ClassD
  - ChaosRepressor
# Damage should state it is a FF. (127 does not get XP, Death screen look 'teamkilled' instead of 'killed')
as_friendly_fire: false
```
