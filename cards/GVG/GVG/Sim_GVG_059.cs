using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_059",
  "name": [
    "齿轮光锤",
    "Coghammer"
  ],
  "text": [
    "<b>战吼：</b>随机使一个友方随从获得<b>圣盾</b>和<b>嘲讽</b>。",
    "<b>Battlecry:</b> Give a random friendly minion <b>Divine Shield</b> and <b>Taunt</b>."
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2027
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    internal class Sim_GVG_059 : SimTemplate //Coghammer
    {
        //   Battlecry: Give a random friendly minion Divine Shield and Taunt;.
        private SimCard w = CardIds.Collectible.Paladin.Coghammer;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            if (temp.Count <= 0) return;
            Minion m = p.searchRandomMinion(temp, SearchMode.LowHealth);
            if (m != null)
            {
                m.divineshild = true;
                if (!m.taunt)
                {
                    m.taunt = true;
                    if (m.own) p.anzOwnTaunt++;
                    else p.anzEnemyTaunt++;
                }
            }
        }
    }
}