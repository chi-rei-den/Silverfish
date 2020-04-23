

/* _BEGIN_TEMPLATE_
{
  "id": "AT_129",
  "name": [
    "光明邪使菲奥拉",
    "Fjola Lightbane"
  ],
  "text": [
    "每当<b>你</b>以该随从为目标施放一个法术时，便获得<b><b>圣盾</b>。</b>",
    "Whenever <b>you</b> target this minion with a spell, gain <b><b>Divine Shield</b>.</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2748
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_129 : SimTemplate //* Fjola Lightbane
    {
        //Whenever you target this minion with a spell, gain Divine Shield.
        // handled in public void playACard
    }
}