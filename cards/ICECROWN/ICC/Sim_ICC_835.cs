

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_835",
  "name": [
    "哈多诺克斯",
    "Hadronox"
  ],
  "text": [
    "<b>亡语：</b>召唤所有你在本局对战中死亡的，并具有<b>嘲讽</b>的随从。",
    "<b>Deathrattle:</b> Summon your <b>Taunt</b> minions that\ndied this game."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43439
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_835 : SimTemplate //* Hadronox
    {
        public override void onDeathrattle(Playfield p, Minion m)
        {
            var pos = m.own ? p.ownMinions.Count : p.enemyMinions.Count;
            var kids = 7 - pos;
            if (kids > 0)
            {
                foreach (var e in Probabilitymaker.Instance.ownCardsOut)
                {
                    var kid = e.Key;
                    if (kid.Taunt)
                    {
                        for (var i = 0; i < e.Value; i++)
                        {
                            p.callKid(kid, pos, m.own);
                            kids--;
                            if (kids < 1)
                            {
                                break;
                            }
                        }

                        if (kids < 1)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}