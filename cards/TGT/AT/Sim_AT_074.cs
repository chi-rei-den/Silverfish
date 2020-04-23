

/* _BEGIN_TEMPLATE_
{
  "id": "AT_074",
  "name": [
    "英勇圣印",
    "Seal of Champions"
  ],
  "text": [
    "使一个随从获得+3攻击力和\n<b>圣盾</b>。",
    "Give a minion\n+3 Attack and <b>Divine Shield</b>."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2717
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_074 : SimTemplate //* Seal of Champions
    {
        //Give a minion +3 Attack and Divine Shield.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 0);
            target.divineshild = true;
        }
    }
}