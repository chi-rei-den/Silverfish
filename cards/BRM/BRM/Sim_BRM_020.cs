

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_020",
  "name": [
    "龙人巫师",
    "Dragonkin Sorcerer"
  ],
  "text": [
    "每当<b>你</b>以该随从为目标施放一个法术时，便获得+1/+1。",
    "Whenever <b>you</b> target this minion with a spell, gain +1/+1."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2306
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_020 : SimTemplate //* Dragonkin Sorcerer
    {
        // Whenever you target this minion with a spell, gain +1/+1.
        // handled in public void playACard
    }
}