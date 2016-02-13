# <font color='red'>WARNING! This project has been migrated to <a href='https://github.com/AgentMC/power8/wiki/KnownIssues'>GitHub</a> </font> #
# Introduction #

This is a list of known product issues.

This list is maintained internally, if you want to report an issue that is not on list, please use [Issues](http://code.google.com/p/power8/issues/list) tab of the project.

To do: convert to issues tab.

# The list of issues #

## Planned to be fixed in upcoming release ##

## Other known ##

### Block ###
### High ###
### Medium ###
  1. W8RTM: no transparency (should think twice before fixing... window may be not in Windows style after fix);
  1. No error message may be shown when user has no right to do power action;
  1. XP: Menu from menu-button may show in inappropriate position;
  1. 7/8: seems sometimes something bad happens in unmanaged code, and heap corruption occurs in CLR. No STR yet, must investigate. Not reproduced for half a year
### Low ###
  1. 8/7<sup>Classic</sup>/XP<sup>Classic</sup>: Menu-button's MTLH is repainted improperly on hover
  1. In case there's common Start menu shortcut X and then the same X is created as user's one and then user's X is renamed to Y - then there will be only Y present in tree
  1. 7/8: Menu item loses selection when context menu is shown
  1. When Classic Start Menu option is on, layout manager may scroll long menu when it is not reqired;
  1. 7/8?: Cannot display properties of a Computer object
  1. XP: buttons are 3px lower than menu-buttons
  1. Unneeded right margin in menu items
  1. W8RTM: when changing menu items size only to 12 (W8 feature) the negative icon margin isn't applied proper way;
  1. (?) Some W8 immersive links aren't run properly - have to investigate

## Done => goes to next release ##