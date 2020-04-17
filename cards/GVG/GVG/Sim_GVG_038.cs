using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_038",
  "name": [
    "连环爆裂",
    "Crackle"
  ],
  "text": [
    "造成$3到$6点伤害，<b>过载：</b>（1）",
    "Deal $3-$6 damage. <b>Overload:</b> (1)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2006
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_038 : SimCard //Crackle
    {

        //    Deal $3-$6 damage.Overload: (1)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
            p.minionGetDamageOrHeal(target, dmg);
            if(ownplay) p.ueberladung++;
        }


    }

}